using System.Linq;
public class Program
{
    // private static string GetSourceFileFromArgs(string[] args)
    // {

    // }

    // private static string GetDestinationFileFromArgs(string[] args)
    // {

    // }

    // private static string GetParserFileFromArgs(string[] args)
    // {

    // }

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
        ThrowIfNotEnoughArgs(args);
    }
}