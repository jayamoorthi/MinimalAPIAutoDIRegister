using Domain.BaseDomain.DomainModels;
using MediatR;


    public class DeleteUserCommand : IRequest<User>
    {
        public DeleteUserCommand(Guid userId, User user )
        {
            Id = userId;
            User = user;
        }
        public Guid Id { get; set; }

    public User User { get; set; }
}

