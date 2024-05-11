using MediatR;

namespace MinimalAPIAutoDIRegister.EventHandlers.Events
{
    public class CreateUserEvent : INotification
    {
        public CreateUserCommand User { get; private set; }
        public CreateUserEvent(CreateUserCommand user)
        {
            User = user;
        }
    }
}
