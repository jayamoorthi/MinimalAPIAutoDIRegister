using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Kafka
{
    public class KafkaProducer : IKafkaProducer     
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<string,string> _producer;
        public KafkaProducer(IConfiguration configuration)
        {
            _configuration = configuration;
            var config = new ProducerConfig { BootstrapServers = _configuration["Kafka:BootstrapServers"] };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task<IProducer<string, string>> CreateProducerAsync<T>(IConfiguration configuration)
        {
            var config = new ProducerConfig { BootstrapServers = _configuration["Kafka:BootstrapServers"] };
            return await Task.FromResult( new ProducerBuilder<string, string>(config).Build());
        }

        public async Task ProduceAsync<T>(IProducer<string, string> producer, string topic, T value)
        {
            var message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(value)
            };

            await producer.ProduceAsync(topic, message);
        }
        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
