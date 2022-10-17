using TxtToXmlParser.Model;

namespace TxtToXmlParser.Parser
{
    public static class TxtParser
    {
        private const char lineDelimiter = '\n';
        private const char columnDelimiter = ';';
        private static IEnumerable<string> ParseColumnsFromLine(string line)
        {
            if(line.Length > 0)
            {
                return line.Split(columnDelimiter);
            }

            throw new Exception("Cannot parse columns from empty line.");
        }
        private static IEnumerable<string> ParseLinesFromContent(string fileContent)
        {
            if(fileContent.Length > 0)
            {
                return fileContent.Split(lineDelimiter);
            }

            throw new Exception("Cannot parse lines from empty string.");
        }
        private static string ReadFileContent(string fileName)
        {

        }
        public static IEnumerable<Person> ParseTxtFile(string fileName)
        {

        }
    }
}