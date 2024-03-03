using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User
{
    public class CreateUserCommand: IRequest<User>
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
