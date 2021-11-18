using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Dtos.Users;
using CGRS.Application.Exceptions;
using CGRS.Commons.Helpers;
using CGRS.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CGRS.Application.Users.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, LoggedInUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticateUserCommandHandler(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public async Task<LoggedInUserResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var userFromDb = await _userRepository.GetByEmailForAuthenticationAsync(request.Email);

            if (userFromDb == null)
            {
                throw new BadRequestException("Invalid password or email!");
            }

            if (!PasswordHelper.VerifyPasswordHash(request.Password, userFromDb.Identity.PasswordHash, userFromDb.Identity.PasswordSalt))
            {
                throw new BadRequestException("Password or user mail is invalid");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userFromDb.Id.ToString()),
                    new Claim(ClaimTypes.Role, userFromDb.Role),
                }),
                Expires = DateTime.Now.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            LoggedInUserResponse response = new LoggedInUserResponse
            {
                Id = userFromDb.Id,
                Email = userFromDb.Email,
                Role = userFromDb.Role,
                Token = tokenString,
            };

            return response;
        }
    }
}
