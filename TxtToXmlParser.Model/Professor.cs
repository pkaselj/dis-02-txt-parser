namespace TxtToXmlParser.Model
{

    class Professor : Person
    {
        public Professor(
            string oIB,
            Gender gender,
            DateOnly dateOfBirth,
            decimal paycheck
        )
            : base(oIB, gender, dateOfBirth)
        {
            Paycheck = paycheck;
        }

        public decimal Paycheck { get; }
    }
}

