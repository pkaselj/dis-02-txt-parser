namespace TxtToXmlParser.Model
{
    public class Person
    {
        // Required by XML Serializer
        public Person()
        {
            OIB = "<EMPTY>";
            Name = "<EMPTY>";
            Gender = Gender.Other;
            DateOfBirth = DateTime.UnixEpoch;
        }

        public Person(
            string oIB,
            string name,
            Gender gender,
            DateTime dateOfBirth
        )
        {
            OIB = oIB;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public string OIB { get; }
        public string Name { get; }
        public Gender Gender { get; }
        
        // DOB changed from DateOnly to DateTime
        // because DateOnly serialization is not yet
        // supported
        public DateTime DateOfBirth { get; } 
    }
}

