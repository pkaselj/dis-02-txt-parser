using System.Xml;
using System.Xml.Serialization;

namespace TxtToXmlParser.Parser
{
    public class XmlSerializerService : ISerializer
    {
        public void Serialize<T>(string filePath, T data)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            using (var prettyXMLPrinter = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(prettyXMLPrinter, data);
            }
        }
    } 
}