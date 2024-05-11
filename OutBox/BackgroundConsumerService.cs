////using Confluent.Kafka;
////using Message.Kafka;
////using System.Text.Json;

//using Confluent.Kafka;

//namespace OutBox
//{
//    public abstract class BackgroundConsumerService<T> : BackgroundService
//    {
//        private readonly IConfiguration _configuration;
//        private readonly ILogger<BackgroundConsumerService<T>> _logger;
//        private readonly IKafkaConsumer _consumer;
//        private readonly IServiceScopeFactory _serviceScopeFactory;

//        public BackgroundConsumerService(IConfiguration configuration, IKafkaConsumer kafkaConsumer, ILogger<BackgroundConsumerService<T>> logger,
//             IServiceScopeFactory serviceScopeFactory)

//        {
//            _configuration = configuration;
//            _logger = logger;
//            _serviceScopeFactory = serviceScopeFactory;
//            _consumer = kafkaConsumer;
//            //var consumerConfig = new ConsumerConfig
//            //{
//            //    BootstrapServers = _configuration["Kafka:BootstrapServers"],
//            //    GroupId = _configuration["Kafka:GroupId"],
//            //    AutoOffsetReset = AutoOffsetReset.Earliest
//            //};
//            //_consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

//        }
//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            var topic = _configuration["Kafka:Topic"];
//            var gropupId = _configuration["Kafka:GroupId"];
//            var consumerBuilder = await _consumer.CreateConsumerAsync(_configuration, gropupId, topic);
//            consumerBuilder.Subscribe(topic);
//            //  _logger.LogInformation($"event Topic:{_consumer.Name}");
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                await ProcessKafkaMessage(consumerBuilder, stoppingToken);
//                Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
//            }

//            _consumer.Close();
//        }

//        public async Task ProcessKafkaMessage<T>(IConsumer<string, string>? consumer, CancellationToken stoppingToken) where T : class
//        {
//            try
//            {
//                var consumeResult = consumer.Consume(stoppingToken);
//                var message = consumeResult.Message.Value;
//                using (var scope = _serviceScopeFactory.CreateScope())
//                {
//                    T inventoryStock = JsonSerializer.Deserialize<T>(message);
//                    var inventoryService = scope.ServiceProvider.GetRequiredService<IInventoryService>();
//                    await inventoryService.SaveInventoryStockAsync(inventoryStock);
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
