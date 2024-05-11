using Confluent.Kafka;
using MediatR;
using MinimalAPIAutoDIRegister.EventHandlers.Events;
using Newtonsoft.Json;
using System.Text;

namespace MinimalAPIAutoDIRegister.EventHandlers
{
    public class ConsumerUserEventHandler : INotificationHandler<CreateUserEvent>
    {
        private readonly IConfiguration _configuration;
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<ConsumerUserEventHandler> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConsumerUserEventHandler(ILogger<ConsumerUserEventHandler> logger, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = _configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }
        public async Task Handle(CreateUserEvent notification, CancellationToken stoppingToken)
        {
            var topic = _configuration["Kafka:Topic"];
            _consumer.Subscribe(topic);
            //  _logger.LogInformation($"event Topic:{_consumer.Name}");
            while (!stoppingToken.IsCancellationRequested)
            {
                 await ProcessKafkaMessageAsync(stoppingToken);
                Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _consumer.Close();

            _logger.LogInformation("Email sent");
            
        }

        private Task ProcessKafkaMessageAsync(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);
                var message = consumeResult.Message.Value;
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    CreateUserEvent inventoryStock = JsonConvert.DeserializeObject<CreateUserEvent>(message);
                   // var inventoryService = scope.ServiceProvider.GetRequiredService<IInventoryService>();
                   // await inventoryService.SaveInventoryStockAsync(inventoryStock);
                }

                //
                _logger.LogInformation($"Received inventory update: {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
            }
            return Task.CompletedTask;
        }

        //public Task Handle(CreateUserEvent notification, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
