using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoQueryResponse>
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, LastName = "A",FullName = "Product A", Email = "aproduct@gmail.com" },
            new User { Id = 2, LastName = "B",FullName = "Product B", Email =  "bproduct@gmail.com" },
            // Add more fake user as needed
        };

        public async Task<GetUserInfoQueryResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(x => x.Id == request.UserId);


            if(user == null)
            {
                throw new NotFoundException($"Product with ID {request.UserId} not found.");
            }

            return await Task.FromResult( new GetUserInfoQueryResponse() { Email = user.Email, Id = user.Id, FullName = user.FullName} );
        }


    }
}
