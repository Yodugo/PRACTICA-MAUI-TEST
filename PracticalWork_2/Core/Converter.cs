using System;

namespace PracticalWork_2.Core
{
    public class Converter
    {
        private List <Conversion> operations;
        public Converter()
        {
            this.operations = new List<Conversion>();

            this.operations.Add(new DecimalToBinary("Decimal to binary", "Binary" ));
            this.operations.Add(new DecimalToOctal("Decimal to octal", "Octal" ));
            this.operations.Add(new DecimalToHexadecimal("Decimal to hexadecimal","Hexadecimal" ));
            this.operations.Add(new DecimalToTwoComplement("Decimal to binary (TwoComplement)", "TwoComplememt"));
            this.operations.Add(new BinaryToDecimal( "Binary to decimal", "Decimal"));
            this.operations.Add(new TwoComplementToDecimal("Binary(TwoComplement) to Decimal", "Decimal"));
            this.operations.Add(new OctalToDecimal("Octal to Decimal", "Decimal"));
            this.operations.Add(new HexadecimalToDecimal("Hexadecimal to Decimal", "Decimal"));



        }
        public int Exit()
        {
            return this.operations.Count + 1;
        }
        public int GetNumberOperations()
        {
            return this.operations.Count;
        }
        public int PrintOperations()
        {
            Console.Clear();

                Console.WriteLine("--------------------------------------------");
                for (int i=1 ; i<= this.operations.Count ; i++)
                {
                    Console.WriteLine($" {i}. {this.operations[i-1].GetName()}");
                }
                
                Console.WriteLine($" {this.GetNumberOperations() + 1}. Exit");
                Console.WriteLine("--------------------------------------------");
                string tmp = Console.ReadLine();
                
                if (tmp == "") return this.Exit();

                int option = int.Parse(tmp);

                return (option < 1 || option >this.GetNumberOperations()) ? this.Exit(): option;
        }
        public string PerformConversion(int op, string input)
        {
            this.operations[op-1].validate(input);
            
            if(this.operations[op-1].NeedBitSize())
            {
                Console.Write("How many bits should I use: ");
                int bits = Int32.Parse(Console.ReadLine());

                return this.operations[op - 1].Change(input, bits);
            }
            
            return this.operations[op-1].Change(input);

        }
        public void PrintConversion(int op, string input, string output)
        {
            this.operations[op-1].PrintConversion(input, output);
        }


    }


}