using System;
namespace Oops
{
    public class Father
    {
        public virtual string InterestOn()
        {
            return "I like to play cricket";
        }
    }
    public class Son: Father
    {
        //method overriding (late binding and runtime )
        public override string InterestOn()
        {
            //return base.InterestOn();
            return "I like to play football";

        }
    }

}