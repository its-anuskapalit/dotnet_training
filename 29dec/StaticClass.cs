using System;

namespace StaticClass
{
    public static class GeneralUses
    {
        static int num = 0;

        public static int GetNo()
        {
            num++;
            return num;
        }
    }
}
