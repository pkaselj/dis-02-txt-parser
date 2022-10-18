namespace TxtToXmlParser.Model
{

    public class Professor : Person
    {
        public Professor(
            string oIB,
            string name,
            Gender gender,
            DateOnly dateOfBirth,
            decimal paycheck
        )
            : base(oIB, name, gender, dateOfBirth)
        {
            Paycheck = paycheck;
        }

        public decimal Paycheck { get; }
    }
}

