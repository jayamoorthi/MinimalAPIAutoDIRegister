using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
