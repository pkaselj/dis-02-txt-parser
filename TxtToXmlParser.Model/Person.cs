namespace TxtToXmlParser.Model
{
    public class Person
    {
        public Person(string oIB, Gender gender, DateOnly dateOfBirth)
        {
            OIB = oIB;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public string OIB { get; }
        public Gender Gender { get; }
        public DateOnly DateOfBirth { get; } 
    }
}

