using Domain.BaseDomain.DomainModels;
using MediatR;


public class CreateUserCommand : IRequest<User>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
}

