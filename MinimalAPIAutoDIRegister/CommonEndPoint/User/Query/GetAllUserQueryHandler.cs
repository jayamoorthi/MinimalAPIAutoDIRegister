using Domain.Interfaces;
using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User.Query
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryCommand, List<GetUserInfoQueryResponse>>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<List<GetUserInfoQueryResponse>> Handle(GetAllUserQueryCommand request, CancellationToken cancellationToken)
        {
            var allUsers = await _userService.GetAllAsync();

            if (allUsers == null)
            {
                throw new NotFoundException($"users not found.");
            }

           var users = allUsers.Select(x => new GetUserInfoQueryResponse { Email = x.Email, Id = x.Id, FullName = x.FullName, LastName = x.LastName }).ToList();

            return await Task.FromResult(users);
        }
    }
}
