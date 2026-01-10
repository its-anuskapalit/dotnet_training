using System;

namespace LearningCSharp
{
    public class AppCustomException : Exception
    {
        public override string Message => HandleBase(base.Message);
        private string HandleBase(string sysMessage)
        {
            Console.WriteLine(sysMessage);
            return "Internal Exception Ocurred. Please contract Admin";
        }
    }
}
