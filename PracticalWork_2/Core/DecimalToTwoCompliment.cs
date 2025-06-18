using System;

namespace PracticalWork_2.Core
{
    public class DecimalToTwoComplement  : Conversion
    {
        private int size = 16;
        public DecimalToTwoComplement(string name, string definition) : base(name, definition, new DecimalInputValidator())
        {

        }
        public void SetSize(int size)
        {
            this.size = size;
        }
        public override string Change(string input)
        {
            int number = Int32.Parse(input);
            int minval = -(1<<(size-1));
            int maxVal = (1<<(size - 1) - 1);

            if (number < minval || number > maxVal)
                throw new ArgumentOutOfRangeException(nameof(input), $"Number fit within {size} bits.");

            uint unsignedValue = (uint) number & ((1u << size) - 1);
            string binaryString = Convert.ToString(unsignedValue, 2).PadLeft(size, '0');
            return binaryString.PadLeft(size, '0');
        }
        public override string Change(string input, int bits)
        {
            int number = Int32.Parse(input);

            int minVal = -(1 << (bits - 1));
            int maxVal = (1 << (bits - 1)) - 1;

            if (number < minVal || number > maxVal)
                throw new ArgumentOutOfRangeException(nameof(input), $"Number must fit within {bits} bits");

                uint unsignedValue = (uint) number & ((1u << bits) - 1);

                string binaryString = Convert.ToString(unsignedValue, 2).PadLeft(bits, '0');

                return binaryString.PadLeft(bits, '0');
        }

    }
}