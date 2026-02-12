
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string a = "AB12C03Z9";
//         string b = "pollu@45ai5//";

//         // ExtractDigits(a);
//         // ValidatePassword(b);
//         // RemoveExceptLettersAndSpaces("Hello@ 123 World!!");
//        // LetterOrDigit("pollu@45ai5//#");
//        CountLowerUpperSpaceSymbol("ValidateP assword(b)");
//     }
//     static void CountLowerUpper(string input)
//     {
//         int l=0;
//         int u=0;
//         int space=0;
//         int sym=0;
//         int pun=0;
//         for(int i = 0; i < input.Length; i++)
//         {
//             if(char.IsLower(input[i])) l++;
//             if(char.IsUpper(input[i])) u++;
//             if(char.IsWhiteSpace(input[i])) space++;
//             if(char.IsSymbol(input[i])) sym++;
//             if(char.IsPun(input[i])) pun++;
//         }
//         Console.WriteLine($"Number of lowercase {l} and uppercase {u}");
//     }
//     static void LetterOrDigit(string input)
//     {
//         string result="";
//         for(int i =0; i < input.Length; i++)
//         {
//             if (char.IsLetterOrDigit(input[i]))
//             {
//                 result+=input[i];
//             }
//         }
//         Console.WriteLine(result);
//     }

//     //=============== Extract digits and convert to integer list ===============
//     static void ExtractDigits(string input)
//     {
//         List<int> arr = new List<int>();

//         for (int i = 0; i < input.Length; i++)
//         {
//             if (char.IsDigit(input[i]))
//             {
//                 arr.Add(input[i] - '0');
//             }
//         }

//         Console.WriteLine("Extracted Digits:");
//         foreach (var i in arr)
//         {
//             Console.WriteLine(i);
//         }
//     }

//     //=============== Validate password contains at least 5 alphabetic characters ===============
//     static void ValidatePassword(string password)
//     {
//         int count = 0;

//         for (int i = 0; i < password.Length; i++)
//         {
//             if (char.IsLetter(password[i]))
//             {
//                 count++;
//             }
//         }

//         if (count >= 5)
//         {
//             Console.WriteLine("Valid Password");
//         }
//         else
//         {
//             Console.WriteLine("Not Valid Password");
//         }
//     }

//     //=============== Remove everything except letters and spaces ===============
//     static void RemoveExceptLettersAndSpaces(string input)
//     {
//         string result = "";

//         for (int i = 0; i < input.Length; i++)
//         {
//             if (char.IsLetter(input[i]) || input[i] == ' ')
//             {
//                 result += input[i];
//             }
//         }

//         Console.WriteLine("Filtered String:");
//         Console.WriteLine(result);
//     }
// }
