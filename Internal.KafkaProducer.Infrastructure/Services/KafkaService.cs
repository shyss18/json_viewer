using System.Net;
using System.Threading.Tasks;
using Confluent.Kafka;
using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Internal.KafkaProducer.Infrastructure.Services
{
    internal class KafkaService : IKafkaService
    {
        public async Task ProduceAsync(string message, KafkaConfiguration kafkaConfiguration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaConfiguration.KafkaServer,
                ClientId = Dns.GetHostName()
            };

            var jsonObject = JObject.Parse(message);

            IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();
            var kafkaMessage = new Message<Null, string> {Value = JsonConvert.SerializeObject(jsonObject)};

            await producer.ProduceAsync(kafkaConfiguration.TopicName, kafkaMessage);
        }
    }
}