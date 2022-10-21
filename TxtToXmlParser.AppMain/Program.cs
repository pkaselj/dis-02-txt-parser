using System.Linq;
using TxtToXmlParser;
using TxtToXmlParser.Parser;

public class Program
{
    private static void ThrowIfFileNotFound(string filePath)
    {
        if (false == System.IO.File.Exists(filePath))
        {
            throw new Exception($"File '{filePath}' not found!");
        }
    }

    // Returns a Dictionary of Key-Value pairs formed from arguments
    // by taking even args as keys and odd args as values
    private static Dictionary<string, string> ParseArguments(string[] args)
    {
        var argsLookupTable = new Dictionary<string, string>();

        for (int i = 0; i < args.Length; i += 2)
        {
            argsLookupTable.Add(args[i], args[i+1]);
        }

        return argsLookupTable;
    }

    // Assumes correct number of args (see ThrowIfNotEnoughArgs(...)) 
    private static string GetSourceFileFromArgs(Dictionary<string, string> args)
    {
        string? sourceFilePath;

        bool fSuccess = false;

        fSuccess = args.TryGetValue("-s", out sourceFilePath);
        if (fSuccess && null != sourceFilePath)
        {
            return sourceFilePath;
        }

        fSuccess = args.TryGetValue("--source", out sourceFilePath);
        if (fSuccess && null != sourceFilePath)
        {
            return sourceFilePath;
        }

        throw new Exception($"Argument for source file not found (-s, --source)!");
    }

    // Assumes correct number of args (see ThrowIfNotEnoughArgs(...)) 
    private static string GetDestinationFileFromArgs(Dictionary<string, string> args)
    {
        string? destFilePath;

        bool fSuccess = false;

        fSuccess = args.TryGetValue("-d", out destFilePath);
        if (fSuccess && null != destFilePath)
        {
            return destFilePath;
        }

        fSuccess = args.TryGetValue("--destination", out destFilePath);
        if (fSuccess && null != destFilePath)
        {
            return destFilePath;
        }

        throw new Exception($"Argument for destination file not found (-d, --destination)!");
    }

    private static string GetParserStringFromArgs(Dictionary<string, string> args)
    {
        string? parserString;

        bool fSuccess = false;

        fSuccess = args.TryGetValue("-p", out parserString);
        if (fSuccess && null != parserString)
        {
            return parserString;
        }

        fSuccess = args.TryGetValue("--parser", out parserString);
        if (fSuccess && null != parserString)
        {
            return parserString;
        }

        throw new Exception($"Argument for parser not found (-p, --parser)!");
    }

    // Assumes correct number of args (see ThrowIfNotEnoughArgs(...)) 
    private static ISerializer GetParserFromArgs(Dictionary<string, string> args)
    {
        string parserString = GetParserStringFromArgs(args);

        string parserStringUpper = parserString.ToUpper();

        switch (parserStringUpper)
        {
            case "XML":
                return new XmlSerializerService();

            case "JSON":
                return new JsonSerializerService();

            default:
                throw new Exception($"Invalid parser argument value: '{parserString}', expected: JSON or XML");
        }
    }

    private static void DisplayUsageString()
    {
        System.Console.WriteLine(Constants.UsageString);
    }
    private static void ThrowIfNotEnoughArgs(string[] args)
    {
        const int requiredNumberOfArgs = 2 + 2 + 2;

        if (args.Length < requiredNumberOfArgs)
        {
            DisplayUsageString();
            throw new Exception($"Expected {requiredNumberOfArgs} arguments, got: {args.Length}");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            ThrowIfNotEnoughArgs(args);

            var argsLookupTable = ParseArguments(args);

            var sourceFile = GetSourceFileFromArgs(argsLookupTable);
            var destinationFile = GetDestinationFileFromArgs(argsLookupTable);
            var serializer = GetParserFromArgs(argsLookupTable);

            ThrowIfFileNotFound(sourceFile);

            var parsedModels = TxtParser.ParseTxtFile(sourceFile);

            serializer.Serialize(destinationFile, parsedModels);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Program encountered an error:");
            System.Console.WriteLine(ex.Message);

            return;
        }
    }
}