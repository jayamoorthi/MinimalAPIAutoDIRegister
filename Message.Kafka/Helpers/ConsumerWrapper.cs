using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Kafka.Helpers
{
    public class ConsumerWrapper
    {
        private string _topicName;
        private ConsumerConfig _consumerConfig;
        private IConsumer<string, string> _consumer;
        private static readonly Random rand = new Random();
        public ConsumerWrapper(ConsumerConfig config, string topicName)
        {
            this._topicName = topicName;
            this._consumerConfig = config;
            this._consumer = new ConsumerBuilder<string, string>(this._consumerConfig).Build();
            this._consumer.Subscribe(topicName);
        }
        public string readMessage()
        {
            String message = String.Empty;
            try
            {
                var consumeResult = _consumer.Consume();
                Console.WriteLine($"consumed: {consumeResult.Value}");
                message = consumeResult.Value;

            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"consume error: {e.Error.Reason}");
            }
            finally
            {
                _consumer.Close();
            }
            return message;
        }

    }
}
