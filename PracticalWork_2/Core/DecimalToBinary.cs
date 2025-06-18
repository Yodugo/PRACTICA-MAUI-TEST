using System;

namespace PracticalWork_2.Core
{
    public class DecimalToBinary : Conversion
    {
        public DecimalToBinary(string name, string definition) : base(name, definition, new DecimalInputValidator())
        {

        }
        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            if (number == 0) return "0";

            string binaryString = "";

            while (number > 0)
            {
                int reminder = number % 2;
                binaryString = reminder + binaryString;
                number /= 2;
            }
            return binaryString;

        }

        public override string Change(string input, int bits)
        {
            string binaryString = this.Change(input);

            if (binaryString.Length > bits)
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Number must fit within {bits} bits");
            }
            if (binaryString.Length < bits)
            {
                binaryString = binaryString.PadLeft(bits, '0');
            }

            return binaryString;
        }   

    }
}