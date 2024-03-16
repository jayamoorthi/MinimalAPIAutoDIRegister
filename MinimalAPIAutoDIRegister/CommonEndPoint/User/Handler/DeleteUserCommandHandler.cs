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

        if(request == null || request.Id != Guid.Empty)
            throw new ArgumentNullException(nameof(request));

        var user = await _userService.GetByIdAsync(request.Id);

        if(user == null || user.Id != Guid.Empty)
            throw new ArgumentNullException(nameof(user));

        if (user.IsDeleted)
        {
            throw new ArgumentException($"already id has been deleted {nameof(request.Id)}");
        }

        user.IsDeleted = true;
        return await _userService.DeleteAsync(user);
    }
}



