namespace TxtToXmlParser
{
    public interface ISerializer
    {
        void Serialize<T>(string filePath, T data);
    }
}