using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Message.Kafka
{
    public interface IKafkaProducer
    {
        Task<IProducer<string, string>> CreateProducerAsync<T>(IConfiguration configuration);

        Task ProduceAsync<T>(IProducer<string, string> producer, string topic, T value);
    }
}