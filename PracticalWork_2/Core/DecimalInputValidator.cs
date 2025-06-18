using System;

namespace  PracticalWork_2.Core
{
    public class DecimalInputValidator : InputValidator
    {
        public override void validate (string input)
        {
            for (int i = 0; i < input.Length ; i++)
            {
                if (input[i] == '-' && i > 0)
                {
                    throw new FormatException("Bad format: input is not a valid integer");
                    
                }
                else if(!char.IsDigit(input[i]))
                {
                    throw new FormatException("Bad format: input is not a valid integer.");
                }
            }
        }
    }
}