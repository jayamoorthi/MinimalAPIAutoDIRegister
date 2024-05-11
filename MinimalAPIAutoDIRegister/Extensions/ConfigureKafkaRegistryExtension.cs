using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using MinimalAPIAutoDIRegister.EventHandlers.Events;
using Newtonsoft.Json;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class ConfigureKafkaRegistryExtension
    {
        public static void ConfigureKafkaRegistryService(this ServiceCollection services, IConfiguration configuration)
        {
            var envBootStrapServers = configuration.GetValue<string>("BootstrapServers");
            var schemaRegistryUrl = configuration.GetValue<string>("SchemaRegistryUrl");
            var groupId = configuration.GetValue<string>("GroupId");
            var topicName = configuration.GetValue<string>("Topic");

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = envBootStrapServers
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                // Note: you can specify more than one schema registry url using the
                // schema.registry.url property for redundancy (comma separated list). 
                // The property name is not plural to follow the convention set by
                // the Java implementation.
                Url = schemaRegistryUrl
            };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = envBootStrapServers,
                GroupId = groupId
            };

            // Note: Specifying json serializer configuration is optional.
            var jsonSerializerConfig = new JsonSerializerConfig
            {
                BufferBytes = 100
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            var consumeTask = Task.Run(() =>
            {
                using (var consumer =
                    new ConsumerBuilder<string, CreateUserEvent>(consumerConfig)
                        .SetKeyDeserializer(Deserializers.Utf8)
                        .SetValueDeserializer(new JsonDeserializer<CreateUserEvent>().AsSyncOverAsync())
                        .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                        .Build())
                {
                    consumer.Subscribe(nameof(CreateUserEvent));

                    try
                    {
                        while (true)
                        {
                            try
                            {
                                var cr = consumer.Consume(cts.Token);
                                var user = cr.Message.Value;
                                Console.WriteLine($"Message : {JsonConvert.SerializeObject(user)}");
                            }
                            catch (ConsumeException e)
                            {
                                Console.WriteLine($"Consume error: {e.Error.Reason}");
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
            });

            //using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            //using (var producer =
            //    new ProducerBuilder<string, CreateUserEvent>(producerConfig)
            //        .SetValueSerializer(new JsonSerializer<CreateUserEvent>(schemaRegistry, jsonSerializerConfig))
            //        .Build())
            //{
            //    Console.WriteLine($"{producer.Name} producing on {topicName}. Enter first names, q to exit.");

            //    long i = 1;
            //    string text;
            //    while ((text = Console.ReadLine()) != "q")
            //    {
            //        CreateUserEvent user = new CreateUserEvent();
            //        try
            //        {
            //            await producer.ProduceAsync(topicName, new Message<string, CreateUserEvent> { Value = user });
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine($"error producing message: {e.Message}");
            //        }
            //    }
            //}

            //cts.Cancel();

            using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            {
                // Note: a subject name strategy was not configured, so the default "Topic" was used.
              //  var schema = await schemaRegistry.RegisterSchemaAsync();
                Console.WriteLine("\nThe JSON schema corresponding to the written data:");
              //  Console.WriteLine(schema.SchemaString);
            }

        }
    }
}
