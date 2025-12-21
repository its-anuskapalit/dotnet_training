using System;
//Vowel or Consonant: Use a switch statement to check if a character is a vowel.
class vowel
{
    public static void check()
    {
        Console.WriteLine("Enter the character");
        String? input=Console.ReadLine();
        switch (input)
        {
            case "a":
            Console.WriteLine("This is vowel");
            break;
            case "e":
            Console.WriteLine("This is vowel");
            break;
            case "i":
            Console.WriteLine("This is vowel");
            break;
            case "o":
            Console.WriteLine("This is vowel");
            break;
            case "u":
            Console.WriteLine("This is vowel");
            break;
            default:
            Console.WriteLine("This is Consonant");
            break;

        }
    }
}