using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Internal.KafkaProducer.Infrastructure.Services
{
    internal class JsonParserService : IJsonParserService
    {
        public async Task<TreeObject> ParseJsonAsync(string fileName)
        {
            JsonReader jsonReader = new JsonTextReader(new StreamReader(File.Open(fileName, FileMode.Open)));
            JObject jsonObject = await JObject.LoadAsync(jsonReader);

            var treeObject = new TreeObject
            {
                Children = new List<TreeNode>()
            };

            foreach (var node in jsonObject)
            {
                var treeNode = new TreeNode
                {
                    Name = node.Key
                };

                if (node.Value != null
                    && node.Value.HasValues)
                {
                    var children = node.Value.Children().ToList();
                }
                
                treeObject.Children.Add(treeNode);
            }

            return treeObject;
        }

        private async Task<TreeObject> ReadJson(JsonReader jsonReader, TreeObject treeObject, TreeNode treeNode = null)
        {
            string propertyName = string.Empty;
            while (await jsonReader.ReadAsync())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.StartObject:
                        if (treeNode != null)
                        {
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                var childTreeNode = new TreeNode
                                {
                                    Name = propertyName,
                                    Children = new List<TreeNode>()
                                };

                                await ReadJson(jsonReader, treeObject, childTreeNode);

                                treeNode.Children.Add(childTreeNode);
                            }

                            await ReadJson(jsonReader, treeObject, treeNode);
                        }
                        else
                        {
                            var node = new TreeNode();
                            treeObject.Children.Add(node);
                            await ReadJson(jsonReader, treeObject, node);
                        }

                        break;
                    case JsonToken.PropertyName:
                        if (treeNode == null)
                        {
                            var node = new TreeNode
                            {
                                Name = jsonReader.Value?.ToString()
                            };
                            treeObject.Children.Add(node);
                            await ReadJson(jsonReader, treeObject, node);
                            break;
                        }

                        if (!string.IsNullOrEmpty(treeNode.Name))
                        {
                            propertyName = jsonReader.Value?.ToString();
                        }
                        else
                        {
                            treeNode.Name = jsonReader.Value?.ToString();
                        }

                        break;
                    case JsonToken.Boolean:
                    case JsonToken.Date:
                    case JsonToken.Float:
                    case JsonToken.Integer:
                    case JsonToken.String:
                        if (treeNode != null)
                        {
                            if (treeNode.Children == null) treeNode.Children = new List<TreeNode>();

                            treeNode.Children.Add(new TreeNode
                            {
                                Name = propertyName,
                                Value = jsonReader.Value?.ToString()
                            });
                        }

                        break;
                    case JsonToken.EndObject:
                        treeNode = null;
                        break;
                }
            }

            return treeObject;
        }
    }
}