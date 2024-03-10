using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

public class UpdateUserCommand : IRequest<User>
{
    public UpdateUserCommand(Guid userId, User user)
    {
        UserId = userId;
        User = user;
    }
    public Guid UserId { get; set; }
    public User User { get; set; }
}

