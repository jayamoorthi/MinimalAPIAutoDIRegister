using Confluent.Kafka;
using MediatR;
using Message.Kafka.Helpers;
using MinimalAPIAutoDIRegister.EventHandlers.Events;
using Newtonsoft.Json;

namespace MinimalAPIAutoDIRegister.EventHandlers
{
    public class UserEventHandler : INotificationHandler<CreateUserEvent>
    {
        private readonly ILogger<UserEventHandler> _logger;
        private readonly ProducerConfig _config;
        public UserEventHandler(ProducerConfig config ,ILogger<UserEventHandler>  logger)
        {
            _config = config;
            _logger = logger;
        }

        //public Task Handle(CreateUserEvent notification, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Handle(CreateUserEvent createUserEvent, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Hanlding event - {nameof(CreateUserEvent)} ");
            //Serialize 
            string serializedUser = JsonConvert.SerializeObject(createUserEvent.User);
            var producer = new ProducerWrapper(_config, nameof(CreateUserEvent));
            await producer.writeMessage(serializedUser);
        }
    }
}
