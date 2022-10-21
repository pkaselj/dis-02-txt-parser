public static class Constants
{
    public static string ExeName
    {
        get
        {
            return System.AppDomain.CurrentDomain.FriendlyName;
        }
    }

    public static string UsageString
    {
        get
        {
return $@"
=========================================================================
A program to read and parse ';'-separated CSV style file (specified
by -s or --source switch) to XML/JSON file (-d or --destination switch).

The XML or JSON parser is set by -p or --parser options.

-------------------------------------------------------------------------

Usage:
    {ExeName} -s source.dat -d destination.xml  -p XML
    {ExeName} -s source.dat -d destination.json -p JSON

-------------------------------------------------------------------------

Switches:
    -s, --source            Source file (CSV style ';' separated file)
    -d, --destination       Destination file
    -p, --parser            Parser name, valid values: XML, JSON
=========================================================================
";
        }
    } 

}
