namespace CommanLib
{
    public abstract class LoginAbs
    {
        public abstract string Login(string UserName, string PassWord); //can override
        public abstract void Logout(); //must override

        public bool LoginProcess() //cannot override
        {
            return true;
        }

    }
}
