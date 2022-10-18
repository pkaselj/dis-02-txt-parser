namespace TxtToXmlParser.Model
{
    public class Student : Person
    {
        public Student(
            string oIB,
            Gender gender,
            DateOnly dateOfBirth,
            float averageGrade
        )
            : base(oIB, gender, dateOfBirth)
        {
            AverageGrade = averageGrade;
        }

        public float AverageGrade { get; }
    }
}

