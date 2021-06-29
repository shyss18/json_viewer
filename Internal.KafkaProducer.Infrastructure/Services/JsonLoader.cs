using System.IO;
using System.Threading.Tasks;
using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Internal.KafkaProducer.Infrastructure.Services
{
    internal class JsonLoader : IJsonLoader
    {
        public async Task<JsonTree> LoadAsync(string fileName)
        {
            JsonReader jsonReader = new JsonTextReader(new StreamReader(File.Open(fileName, FileMode.Open)));
            JObject jsonObject = await JObject.LoadAsync(jsonReader);

            return new JsonTree
            {
                Json = jsonObject.ToString()
            };
        }
    }
}