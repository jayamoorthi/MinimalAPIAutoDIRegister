using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Kafka
{
    public class KafkaConsumer<T> : IKafkaConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger logger;
        private readonly IConsumer<string, string> _consumer;
        public KafkaConsumer(IConfiguration configuration, string groupId, string topic, ILogger logger)
        {
            _configuration = configuration;
            this.logger = logger;
            var config = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
           
        }

        public async Task<IConsumer<string, string>> CreateConsumerAsync(IConfiguration configuration, string groupId, string topic) 
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            var _consumerBuilder = new ConsumerBuilder<string, string>(config).Build();
            return await Task.FromResult(_consumerBuilder);
        }
        public Task<IConsumer<string, string>> GetConsumerAsync()
        {
            return Task.FromResult(_consumer);
        }

        public Task GetTopicNameAsync()
        {

            return Task.FromResult(_consumer);
        }

        public async Task<string> GetMessageBodyAsync(IConsumer<string, string> consumer, string topic, CancellationToken stoppingToken)
        {
            string messageBody =string.Empty;
            consumer.Subscribe(topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                  //  await ProcessKafkaMessage(stoppingToken);
                    var result = _consumer.Consume(stoppingToken);

                    if (result != null && !result.IsPartitionEOF)
                    {
                        //var consumeResult = _consumer.Consume(stoppingToken);
                        messageBody = result.Message.Value;
                        //await ConsumeAsync(value, stoppingToken);
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
           
            _consumer.Close();
            return await Task.FromResult(messageBody);
        }


        //public async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    var topic = _configuration["Kafka:Topic"];
        //   // topic = default(typeof(T))
        //    _consumer.Subscribe(topic);

        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        try
        //        {
        //           await ProcessKafkaMessage(stoppingToken);
        //            //var result = _consumer.Consume(stoppingToken);

        //            //if (result != null && !result.IsPartitionEOF)
        //            //{
        //            //    var value = JsonConvert.DeserializeObject<T>(result.Value);
        //            //    await ConsumeAsync(value, stoppingToken);
        //            //}
        //        }
        //        catch (OperationCanceledException)
        //        {
        //            logger.LogInformation("Kafka consumer has been cancelled.");
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.LogError(ex, "An error occurred while consuming messages from Kafka.");
        //        }
        //    }
        //    _consumer.Close();
        //}

        public void Dispose()
        {
           _consumer.Dispose();
        }
        //public async Task ProcessKafkaMessage(CancellationToken stoppingToken)
        //{
        //    try
        //    {
        //        var consumeResult = _consumer.Consume(stoppingToken);
        //        var message = consumeResult.Message.Value;
        //        using (var scope = _serviceScopeFactory.CreateScope())
        //        {
        //            InventoryStock inventoryStock = JsonSerializer.Deserialize<InventoryStock>(message);
        //            var inventoryService = scope.ServiceProvider.GetRequiredService<IInventoryService>();
        //            await inventoryService.SaveInventoryStockAsync(inventoryStock);
        //        }

        //        //
        //        _logger.LogInformation($"Received inventory update: {message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error processing Kafka message: {ex.Message}");
        //    }
        //}
    }
}

