// using System;
// using System.Collections.Generic;
// using System.Collections.ObjectModel;
// using System.IO;
// using System.Threading.Tasks;
// using Internal.KafkaProducer.Desktop.ViewModels.JsonTree;
// using Newtonsoft.Json;
//
// namespace Internal.KafkaProducer.Desktop.Infrastructure
// {
//     public class JsonParserService
//     {
//         public List<TreeNodeViewModel> Parse(string fileName)
//         {
//             var jsonReader = new JsonTextReader(new StreamReader(new FileStream(fileName, FileMode.Open)));
//             var treeNodes = new List<TreeNodeViewModel>();
//
//             ReadJson(jsonReader, treeNodes);
//
//             return treeNodes;
//         }
//
//         private void ReadJson(JsonReader jsonReader, List<TreeNodeViewModel> items)
//         {
//             bool complete = false;
//             string propertyName = string.Empty;
//
//             while (!complete && jsonReader.Read())
//             {
//                 switch (jsonReader.TokenType)
//                 {
//                     case JsonToken.PropertyName:
//                         propertyName = jsonReader.Value?.ToString();
//                         break;
//                     case JsonToken.Float:
//                     case JsonToken.Integer:
//                     case JsonToken.Boolean:
//                     case JsonToken.Date:
//                     case JsonToken.String:
//                         items.Add(new TreeNodeViewModel
//                         {
//                             Name = propertyName,
//                             Value = Convert.ToString(jsonReader.Value)
//                         });
//                         break;
//                     case JsonToken.StartObject:
//                         var children = new List<TreeNodeViewModel>();
//                         items.Add(new TreeObjectViewModel
//                         {
//                             Name = propertyName,
//                             Children = new ObservableCollection<TreeNodeViewModel>(children)
//                         });
//                         ReadJson(jsonReader, children);
//                         break;
//                     case JsonToken.EndObject:
//                         complete = true;
//                         break;
//                 }
//             }
//         }
//     }
// }