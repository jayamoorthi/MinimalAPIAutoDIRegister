using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly List<User> _users = new List<User>();
        private int _nextProductId = 1;

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Simulate creating a new product
            var user = new User
            {
                Id = _nextProductId++,
                LastName = request.LastName,
                Email = request.Email,
                FullName = request.FullName
                
            };

            // Add the user to the fake data source
            _users.Add(user);

            // Return_ the newly created product's ID
            return user;
        }
    }
}
