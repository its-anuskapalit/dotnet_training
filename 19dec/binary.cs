using System;
// BINARY TO DECIMAL CONVERSION PROGRAM
class BinaryToDecimal
{
    public static void Run()
    {
        //input parse
        try
        {
            Console.Write("Enter Binary Number: ");
            string Binary = Console.ReadLine();

            int Decimal = 0;
            int Power = 1;
            //conversion logic
            for (int i = Binary.Length - 1; i >= 0; i--)
            {
                if (Binary[i] == '1')
                    Decimal += Power;

                Power *= 2;
            }

            Console.WriteLine("Decimal Value: " + Decimal);
        }
        //error 
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
