using TxtToXmlParser.Model;

namespace TxtToXmlParser.Parser
{
    public class TxtParser
    {
        private const char lineDelimiter = '\n';
        private const char cellDelimiter = ';';

        public string FileName { get; }

        private TxtParser(string fileName)
        {
            FileName = fileName;
        }

        private IEnumerable<Person> GetParsedModels()
        {
            // TODO
        }

        private string GetFileContent()
        {
            return File.ReadAllText(FileName);
        }

        private IEnumerable<string> SplitStringIntoLines(string content)
        {
            return content.Split(lineDelimiter);
        }

        private IEnumerable<string> SplitLineIntoCells(string line)
        {
            return line.Split(cellDelimiter);
        }

        public static IEnumerable<Person> ParseTxtFile(string fileName)
        {
            return new TxtParser(fileName).GetParsedModels();
        }
    }
}