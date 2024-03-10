using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.DeleteAsync(request.User);
    }
}



