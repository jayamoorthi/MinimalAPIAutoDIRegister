using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

public class UpdateUserCommand : LoginUser,IRequest<LoginUser>
{
    //public UpdateUserCommand(User user)
    //{
    //    User = user;
    //}
    //public Guid UserId { get; set; }
    //public User User { get; set; }
}

