using System;

namespace PracticalWork_2.Core
{
    public class DecimalToHexadecimal : Conversion
    {
        public DecimalToHexadecimal(string name, string definition) : base(name, definition, new DecimalInputValidator())
        {

        }
        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            if (number == 0) return "0";

            char[] hexChars = "0123456789ABCDEF".ToCharArray();

            string hexString = "";

            while (number > 0)
            {
                int reminder = number % 16;
                hexString = hexChars[reminder] + hexString;
                number /= 16;
            }
            return hexString;

        }

    }
}