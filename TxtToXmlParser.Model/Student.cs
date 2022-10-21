namespace TxtToXmlParser.Model
{
    public class Student : Person
    {
        // Required by XML Serializer
        public Student()
            : base()
        {
            AverageGrade = -1.00f;
        }
        
        public Student(
            string oIB,
            string name,
            Gender gender,
            DateOnly dateOfBirth,
            float averageGrade
        )
            : base(oIB, name, gender, dateOfBirth)
        {
            AverageGrade = averageGrade;
        }

        public float AverageGrade { get; }
    }
}

