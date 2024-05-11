using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Message.Kafka
{
    public interface IKafkaConsumer
    {
        Task<IConsumer<string, string>> GetConsumerAsync();

        Task GetTopicNameAsync();

        Task<IConsumer<string, string>> CreateConsumerAsync(IConfiguration configuration, string groupId, string topic);

        Task<string> GetMessageBodyAsync(IConsumer<string, string> consumer, string topic, CancellationToken stoppingToken);
    }
}