using System.Text.Json;

namespace TxtToXmlParser.Parser
{
    public class JsonSerializerService : ISerializer
    {
        public void Serialize<T>(string filePath, T data)
        {
            var serializedData = JsonSerializer.Serialize(data);
            var serializedDataBytes = System.Text.Encoding.ASCII.GetBytes(serializedData);

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                fs.Write(serializedDataBytes);
            }
        }
    } 
}