using System;

namespace PracticalWork_2.Core
{
    public class DecimalToOctal : Conversion
    {
        public DecimalToOctal(string name, string definition) : base(name, definition, new DecimalInputValidator())
        {

        }
        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            if (number == 0) return "0";

            string octalString = "";

            while (number > 0)
            {
                int reminder = number % 8;
                octalString = reminder + octalString;
                number /= 8;
            }
            return octalString;

        }

    }
}