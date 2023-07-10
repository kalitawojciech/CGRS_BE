using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Commons.Helpers;
using CGRS.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace CGRS.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IOptions<AppSettings> _appSettings;

        public ChangePasswordCommandHandler(IIdentityRepository identityRepository, IOptions<AppSettings> appSettings)
        {
            _identityRepository = identityRepository;
            _appSettings = appSettings;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userIdentityFromDb = await _identityRepository.GetByUserIdAsync(Guid.Parse(request.User.Identity.Name));

            if (userIdentityFromDb == null)
            {
                throw new BadRequestException("User does not exist!");
            }

            if (!PasswordHelper.VerifyPasswordHash(request.OldPassword, userIdentityFromDb.PasswordHash, userIdentityFromDb.PasswordSalt))
            {
                throw new BadRequestException("Old password is invalid");
            }

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

            userIdentityFromDb.PasswordSalt = passwordSalt;
            userIdentityFromDb.PasswordHash = passwordHash;

            await _identityRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
