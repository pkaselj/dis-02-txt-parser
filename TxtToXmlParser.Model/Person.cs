using System.Xml.Serialization;

namespace TxtToXmlParser.Model
{
    // Please the XML serializer gods
    // https://stackoverflow.com/a/13529088
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Professor))]
    [XmlRoot("Person")]
    [Serializable]
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

        [XmlElement("OIB")]
        public string OIB { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Gender")]
        public Gender Gender { get; set; }

        // DOB changed from DateOnly to DateTime
        // because DateOnly serialization is not yet
        // supported
        [XmlElement("DOB")]
        public DateTime DateOfBirth { get; set; } 
    }
}

