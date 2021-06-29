using System.Threading.Tasks;
using Internal.KafkaProducer.Domain;

namespace Internal.KafkaProducer.Core.Contracts.Services
{
    public interface IJsonLoader
    {
        Task<JsonTree> LoadAsync(string fileName);
    }
}