using Confluent.Kafka;
using Newtonsoft.Json;

namespace OutBox
{

    public class KafkaConsumer<T> : BackgroundService 
    {
        private readonly ILogger logger;
        private readonly IConsumer<string, string> consumer;
        public KafkaConsumer(string bootstrapServers, string groupId, string topic, ILogger logger)
        {
            this.logger = logger;
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var result = consumer.Consume(stoppingToken);
                    if (result != null && !result.IsPartitionEOF)
                    {
                        var value = JsonConvert.DeserializeObject<T>(result.Value);
                       // await ConsumeAsync(value, stoppingToken);
                    }
                }
                catch (OperationCanceledException)
                {
                    logger.LogInformation("Kafka consumer has been cancelled.");
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while consuming messages from Kafka.");
                }
            }
            consumer.Close();
        }
        public override void Dispose()
        {
            consumer.Dispose();
            base.Dispose();
        }
       // protected abstract Task ConsumeAsync(T value, CancellationToken stoppingToken);
    }
    
}
