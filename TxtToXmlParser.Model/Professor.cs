namespace TxtToXmlParser.Model
{

    public class Professor : Person
    {
        // Required by XML Serializer
        public Professor()
            : base()
        {
            Paycheck = -1.00m;
        }

        public Professor(
            string oIB,
            string name,
            Gender gender,
            DateTime dateOfBirth,
            decimal paycheck
        )
            : base(oIB, name, gender, dateOfBirth)
        {
            Paycheck = paycheck;
        }

        public decimal Paycheck { get; }
    }
}

