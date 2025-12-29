using System;
namespace LearningCSharp
{
    //static class StringExtensions
    public static class StringExtensions
    {
        //static extension method WordCount
        public static int WordCount(this string str)
        {
            //method logic
            char[] chars= str.ToCharArray();
            int count = 1;
            foreach (var item in chars)
            {
                if (item.Equals(' '))
                    count++;
            }
            return count;
        }
    }
}