using Domain.BaseDomain.DomainModels;
using MediatR;


    public class DeleteUserCommand : IRequest<User>
    {
        public DeleteUserCommand(Guid userId)
        {
            Id = userId;
        }
        public Guid Id { get; set; }

    
}

