using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using MediatR;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly List<User> _users = new List<User>();
    private readonly IUserService _userService;
    private int _nextProductId = 1;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

           
            // Simulate creating a new product
            var user = new User
            {
                Id = request.Id,
                LastName = request.LastName,
                Email = request.Email,
                FullName = request.FullName
                
            };

            return await _userService.InsertAsync(user);
            // Return_ the newly created product's ID
           
        }
    }

