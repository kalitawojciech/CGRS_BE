using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Commons.Enumerables;
using CGRS.Commons.Helpers;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            await _userRepository.AddAsync(new User()
            {
                Id = Guid.NewGuid(),
                Nick = request.Nick,
                Email = request.Email,
                IsAdult = true,
                BirthDate = request.BirthDate,
                Identity = new Identity()
                {
                    Id = Guid.NewGuid(),
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = UserRole.User,
                },
            });

            return Unit.Value;
        }

        private async Task Validate(RegisterUserCommand request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new BadRequestException("Email cannot be empty!");
            }

            if (string.IsNullOrEmpty(request.Nick))
            {
                throw new BadRequestException("Nick cannot be empty!");
            }

            if ((await _userRepository.GetByEmailAsync(request.Email)) != null)
            {
                throw new BadRequestException("This email is already used!");
            }

            if ((await _userRepository.GetByEmailAsync(request.Nick)) != null)
            {
                throw new BadRequestException("This nick is already used!");
            }
        }
    }
}
