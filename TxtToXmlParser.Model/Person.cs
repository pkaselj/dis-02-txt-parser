namespace TxtToXmlParser.Model
{
    public class Person
    {
        public Person(
            string oIB,
            string name,
            Gender gender,
            DateOnly dateOfBirth
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
        public DateOnly DateOfBirth { get; } 
    }
}

