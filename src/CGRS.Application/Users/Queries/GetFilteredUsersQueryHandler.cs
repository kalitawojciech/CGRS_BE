using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Users;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Users.Queries
{
    public class GetFilteredUsersQueryHandler : IRequestHandler<GetFilteredUsersQuery, PagedResponse<UserFullInfoResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetFilteredUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<UserFullInfoResponse>> Handle(GetFilteredUsersQuery request, CancellationToken cancellationToken)
        {
            PagedEntity<User> usersFromDb = await _userRepository.GetFilteredAsync(request.UsersFilter);

            var response = _mapper.Map<PagedResponse<UserFullInfoResponse>>(usersFromDb);
            return response;
        }
    }
}
