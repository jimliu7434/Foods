using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Foods.Class
{
    public static class JsonUtility
    {
        public static T Deserialize<T>(string filePath)
        {
            var jsonString = ReadFileText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<T> DeserializeAsync<T>(Stream stream)
        {
            var sr = new StreamReader(stream);
            var jsonString = await sr.ReadToEndAsync();
            sr.Dispose();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string ReadFileText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

    }
}
