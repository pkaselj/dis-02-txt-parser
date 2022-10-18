namespace TxtToXmlParser.Model
{
    static class DataParserHelper
    {
        public static void AssertIsNotNull(object? obj)
        {
            if (null == obj)
            {
                throw new Exception($"Object is null.");
            }
        }
        public static void AssertTypeIsInstanceOrSubclass(Type? testType, Type referenceType)
        {
            if (null == testType || !referenceType.IsAssignableFrom(testType))
            {
                throw new Exception($"Expected type (or subtype) : \"{referenceType}\", but got: \"{testType}\"");
            }
        }
    }
    interface IFieldParser
    {
        bool IsValid(string value);
        void ParseAndPopulate(string value, ref object destinationObject);
    }

    public class OIBParser : IFieldParser
    {
        public bool IsValid(string value)
        {
            bool isCharacterCountValid = (value.Length == 11);
            bool isEveryCharacterNumber = !( value.Any(character => !Char.IsDigit(character)) );
            return isCharacterCountValid && isEveryCharacterNumber;
        }

        public void ParseAndPopulate(string value, ref object destinationObject)
        {
            DataParserHelper.AssertIsNotNull(destinationObject);            
            DataParserHelper.AssertTypeIsInstanceOrSubclass(destinationObject.GetType(), typeof(Person));

            (destinationObject as Person)!.OIB = value;
        }
    }

    public class GenderParser : IFieldParser
    {
        private Gender? ParseGender(string value)
        {
            switch(value.ToLower())
            {
                case "male": return Gender.Male;
                case "female": return Gender.Female;
                case "other": return Gender.Other;

                default: return null;
            }
        }
        public bool IsValid(string value)
        {
            return ParseGender(value) != null;
        }

        public void ParseAndPopulate(string value, ref object destinationObject)
        {
            DataParserHelper.AssertIsNotNull(destinationObject);            
            DataParserHelper.AssertTypeIsInstanceOrSubclass(destinationObject.GetType(), typeof(Person));

            if(!IsValid(value))
            {
                throw new Exception()
            }

            (destinationObject as Person)!.Gender = ParseGender(value);
        }
    }

    public class DateTimeParser : IFieldParser
    {
        public bool IsValid(string value)
        {
            throw new NotImplementedException();
        }

        public void ParseAndPopulate(string value, ref object destinationObject)
        {
            throw new NotImplementedException();
        }
    }

    public class AverageGradeParser : IFieldParser
    {
        public bool IsValid(string value)
        {
            throw new NotImplementedException();
        }

        public void ParseAndPopulate(string value, ref object destinationObject)
        {
            throw new NotImplementedException();
        }
    }

    public class PaycheckParser : IFieldParser
    {
        public bool IsValid(string value)
        {
            throw new NotImplementedException();
        }

        public void ParseAndPopulate(string value, ref object destinationObject)
        {
            throw new NotImplementedException();
        }
    }
}