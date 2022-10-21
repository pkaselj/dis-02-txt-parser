using TxtToXmlParser.Model;

namespace TxtToXmlParser.Parser
{
    public class TxtParser
    {
        // Constants
        // -- Delimiters
        private const char cellDelimiter = ';';

        // -- Parsing Constants
        private const string TYPE_STUDENT = "Student";
        private const string TYPE_PROFESSOR = "Professor";

        // -- Field Columns
        // Type;OIB;Name;Gender;DateOfBirth;AvgGrade;Paycheck
        private const int COLUMN_TYPE           = 0;
        private const int COLUMN_OIB            = 1;
        private const int COLUMN_NAME           = 2;
        private const int COLUMN_GENDER         = 3;
        private const int COLUMN_DATEOFBIRTH    = 4;
        private const int COLUMN_AVERAGEGRADE   = 5;
        private const int COLUMN_PAYCHECK       = 6;

        // Public fields

        public string FileName { get; }

        // Constructor
        private TxtParser(string fileName)
        {
            FileName = fileName;
        }

        // Private methods

        // -- Model Parsing

        private IEnumerable<Person> GetParsedModels()
        {
            var lines = GetFileContentAsLines();

            // Assert existence of at least two rows (header + one data row)
            if (lines.Count() < 2)
            {
                throw new Exception("Too few lines in source file.");
            }
            
            // Skip header row
            var dataLines = lines.Skip(1);

            List<Person> lstPeople = new List<Person>(dataLines.Count());

            foreach (var line in dataLines)
            {
                var columns = SplitLineIntoCells(line);
                var newPerson = ParseLineColumns(columns);
                lstPeople.Add(newPerson);
            }

            return lstPeople;
        }

        private static Person ParseLineColumns(IEnumerable<string> line)
        {
            var typeString = line.ElementAt(COLUMN_TYPE);

            switch(typeString)
            {
                case TYPE_PROFESSOR:
                    return ParseProfessor(line);
                case TYPE_STUDENT:  
                    return ParseStudent(line);
                default:
                    throw new Exception($"Unknown TYPE: \"{typeString}\"");
            }
        } 

        private static Person ParseStudent(IEnumerable<string> line)
        {
            var oib = ParseOIB(line.ElementAt(COLUMN_OIB));
            var name = ParseName(line.ElementAt(COLUMN_NAME));
            var gender = ParseGender(line.ElementAt(COLUMN_GENDER));
            var dob = ParseDateOfBirth(line.ElementAt(COLUMN_DATEOFBIRTH));
            var avggrade = ParseAverageGrade(line.ElementAt(COLUMN_AVERAGEGRADE));

            return new Student(
                oib, name, gender, dob, avggrade
            );
        }

        private static Person ParseProfessor(IEnumerable<string> line)
        {
            var oib = ParseOIB(line.ElementAt(COLUMN_OIB));
            var name = ParseName(line.ElementAt(COLUMN_NAME));
            var gender = ParseGender(line.ElementAt(COLUMN_GENDER));
            var dob = ParseDateOfBirth(line.ElementAt(COLUMN_DATEOFBIRTH));
            var paycheck = ParsePaycheck(line.ElementAt(COLUMN_PAYCHECK));

            return new Professor(
                oib, name, gender, dob, paycheck
            );
        }

        // -- Data Parsing

        private static string ParseOIB(string value)
        {
            bool isOIBOfCorrectLength = (value.Length == 11);

            if (!isOIBOfCorrectLength)
            {
                throw new Exception($"OIB of invalid length: '{value}' ");
            }

            bool isAnyCharacterInvalid = (value.Any(character => !Char.IsDigit(character)));

            if (isAnyCharacterInvalid)
            {
                throw new Exception($"OIB contains invalid characters: '{value}' ");
            }

            return value;

        }

        private static string ParseName(string value)
        {
            bool isAnyCharacterInvalid = value.Any(
                character => !Char.IsLetterOrDigit(character) && !Char.IsSeparator(character)
            );

            if (isAnyCharacterInvalid)
            {
                throw new Exception($"Name contains illegal characters: '{value}' ");
            }

            return value;
        }

        private static Gender ParseGender(string value)
        {
            bool fIgnoreCase = true;

            return Enum.Parse<Gender>(value, fIgnoreCase);
        }

        private static DateOnly ParseDateOfBirth(string value)
        {
            const string dateFormat = "yyyy/MM/dd"; 

            return DateOnly.ParseExact(value, dateFormat);
        }

        private static float ParseAverageGrade(string value)
        {
            return float.Parse(value);
        }

        private static decimal ParsePaycheck(string value)
        {
            return decimal.Parse(value);
        }

        // -- Txt Manipulation
        private IEnumerable<string> GetFileContentAsLines()
        {
            return File.ReadAllLines(FileName);
        }

        private static IEnumerable<string> SplitLineIntoCells(string line)
        {
            return line.Split(cellDelimiter);
        }

        // Public Methods

        public static IEnumerable<Person> ParseTxtFile(string fileName)
        {
            return new TxtParser(fileName).GetParsedModels();
        }
    }
}