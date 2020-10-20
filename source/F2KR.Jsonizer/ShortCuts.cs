using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace F2KR.Jsonizer
{
    public class ShortCuts
    {
        public static string LoadTextFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public static List<string> GetArray(string json, string stringArrayPropertyName)
        {
            var result = ((JArray) JObject.Parse(json)[stringArrayPropertyName])?.Select(x => x.ToString()).ToList();
            return result;
        }

        public static string GetString(string json, string stringPropertyName)
        {
            var result = (string) JObject.Parse(json)[stringPropertyName];
            return result;
        }

        public static string GetPropertyAsJson(string json, string propertyName)
        {
            var result = JsonConvert.SerializeObject(JObject.Parse(json)[propertyName]);

            return result;
        }

        public static List<string> GetListOfInnerPropertyOfArray(string json, string arrayPropertyName,
            string innerPropertyName)
        {
            var result = ((JArray) JObject.Parse(json)[arrayPropertyName])?.Select(x => x[innerPropertyName]?.ToString())
                .ToList();

            return result;
        }

        public static string Serialize(object pocoObject)
        {
            return JsonConvert.SerializeObject(pocoObject);
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static object DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public static List<JsonField> GetFields(string json, string jsonPath="$.*")
        {
            var result = new List<JsonField>();
            var  tokenList = JObject.Parse(json).SelectTokens(jsonPath).ToList(); 
            
            foreach (var field in tokenList.ToArray())
            {
                var fieldName = field.Path.Substring(field.Path.LastIndexOf(".") + 1);
                var fieldValue = field.ToString();

                var item = new JsonField(fieldName, fieldValue);
               
                result.Add(item);
            }

            return result;
        }
    }
}