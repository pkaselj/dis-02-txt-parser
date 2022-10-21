using System.Xml.Serialization;

namespace TxtToXmlParser.Model
{
    [Serializable]
    [XmlRoot("Student")]
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
            DateTime dateOfBirth,
            float averageGrade
        )
            : base(oIB, name, gender, dateOfBirth)
        {
            AverageGrade = averageGrade;
        }

        [XmlElement("GPA")]
        public float AverageGrade { get; set; }
    }
}

