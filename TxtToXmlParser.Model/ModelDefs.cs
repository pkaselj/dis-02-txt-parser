namespace TxtToXmlParser.Model
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Person
    {
        public string OIB { get; set; }
        public Gender Gender {get; set;}
        public DateTime DateOfBirth { get; set; } 
    }

    public class Student : Person
    {
        public float AverageGrade { get; set; }
    }

    class Professor : Person
    {
        public float Paycheck { get; set; }
    }
}

