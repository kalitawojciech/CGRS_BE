using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Users;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserInfoResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserInfoResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> usersFromDb = await _userRepository.GetAllAsync();

            var response = _mapper.Map<List<UserInfoResponse>>(usersFromDb);
            return response;
        }
    }
}
