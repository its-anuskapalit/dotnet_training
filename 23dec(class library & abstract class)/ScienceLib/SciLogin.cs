using System;
using CommanLib;

//ScienceLib namespace
namespace ScienceLib
{
    public class SciLogin : LoginAbs
    {
        //overriding abstract methods from LoginAbs class
        public override string Login(string UserName,string PassWord)
        {
            return UserName + PassWord;
        }
        //must override
        public override void Logout()
        {
               
        }

    }
}
