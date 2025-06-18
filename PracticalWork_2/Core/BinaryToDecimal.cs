using System;

namespace PracticalWork_2.Core
{
    public class BinaryToDecimal : Conversion
    {
        public BinaryToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {

        }
        public override string Change(string input)
        {
            int decimalValue = 0;
            int baseValue = 1;

             for (int i = input.Length - 1; i >= 0; i--)
             {
                if (input[i] == '1')
                {
                    decimalValue += baseValue;
                }

                baseValue *= 2; 

             }

            return decimalValue.ToString();
        }
    
    }
}