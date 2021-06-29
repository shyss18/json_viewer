using System.Threading.Tasks;
using Internal.KafkaProducer.Domain;

namespace Internal.KafkaProducer.Core.Contracts.Services
{
    public interface IKafkaService
    {
        Task ProduceAsync(string message, KafkaConfiguration kafkaConfiguration);
    }
}