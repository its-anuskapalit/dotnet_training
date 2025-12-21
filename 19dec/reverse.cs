using System;
//class to Reverse an integer and check if it is a palindrome 
class reverse
{
    public static void num(){
       int n = int.Parse(Console.ReadLine());
       int rev = 0;
       int temp=n;
       while (n > 0)
{
    rev = rev * 10 + n % 10;
    n /= 10;
}

Console.WriteLine(rev);

//to check if number is palindrome
// palidrom num: same number appears after revsering original
Console.WriteLine(temp == rev ? "Palindrome" : "Not Palindrome");

    }
}