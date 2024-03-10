using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using MediatR;


    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId == null || request.User == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        return await _userService.UpdateAsync(request.UserId, request.User);
            
        }
    }

