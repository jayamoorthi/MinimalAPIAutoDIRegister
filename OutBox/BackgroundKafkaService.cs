//using Confluent.Kafka;
//using MinimalAPIAutoDIRegister.EventHandlers.Events;
//using Newtonsoft.Json;

//namespace OutBox
//{
//    public class BackgroundKafkaService : BackgroundService
//    {

//        private readonly IConfiguration _configuration;
//        private readonly ILogger<BackgroundKafkaService> _logger;
//        private readonly IConsumer<Ignore, string> _consumer;
//        private readonly IServiceScopeFactory _serviceScopeFactory;

//        public BackgroundKafkaService(IConfiguration configuration, ILogger<BackgroundKafkaService> logger,
//             IServiceScopeFactory serviceScopeFactory)

//        {
//            _configuration = configuration;
//            _logger = logger;
//            _serviceScopeFactory = serviceScopeFactory;
//            var consumerConfig = new ConsumerConfig
//            {
//                BootstrapServers = _configuration["Kafka:BootstrapServers"],
//                GroupId = _configuration["Kafka:GroupId"],
//                AutoOffsetReset = AutoOffsetReset.Earliest
//            };
//            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

//        }
//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            var topic = _configuration["Kafka:Topic"];
//            _consumer.Subscribe(topic);
//            //  _logger.LogInformation($"event Topic:{_consumer.Name}");
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                await ProcessKafkaMessage(stoppingToken);
//                Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
//            }

//            _consumer.Close();
//        }

//        public async Task ProcessKafkaMessage(CancellationToken stoppingToken)
//        {
//            try
//            {
//                var consumeResult = _consumer.Consume(stoppingToken);
//                var message = consumeResult.Message.Value;
//                using (var scope = _serviceScopeFactory.CreateScope())
//                {
//                    var inventoryStock = JsonConvert.DeserializeObject<CreateUserEvent>(message);
//                    //var inventoryService = scope.ServiceProvider.GetRequiredService<IInventoryService>();
//                    //await inventoryService.SaveInventoryStockAsync(inventoryStock);
//                    _logger.LogInformation($"Received inventory update: {message}");
//                }

//                //
//                _logger.LogInformation($"Received inventory update: {message}");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error processing Kafka message: {ex.Message}");
//            }
//        }
//    }
//}
