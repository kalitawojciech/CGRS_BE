using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Users;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Users.Queries.GetCurrentUserData
{
    public class GetCurrentUserDataQueryHandler : IRequestHandler<GetCurrentUserDataQuery, UserProfileResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetCurrentUserDataQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileResponse> Handle(GetCurrentUserDataQuery request, CancellationToken cancellationToken)
        {
            if (request.User == null)
            {
                throw new BadRequestException("Email cannot be empty!");
            }

            User userFromDb = await _userRepository.GetByIdAsync(Guid.Parse(request.User.Identity.Name));

            var response = _mapper.Map<UserProfileResponse>(userFromDb);
            return response;
        }
    }
}
