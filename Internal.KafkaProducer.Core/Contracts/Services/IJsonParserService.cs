using System.Threading.Tasks;
using Internal.KafkaProducer.Domain;

namespace Internal.KafkaProducer.Core.Contracts.Services
{
    public interface IJsonParserService
    {
        Task<TreeObject> ParseJsonAsync(string fileName);
    }
}