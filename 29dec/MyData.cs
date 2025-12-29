using System;

namespace indexer
{
    public class MyData
    {
        string[] languages = new string[3];

        public string this[int index]
        {
            get
            {
                return languages[index];
            }
            set
            {
                languages[index] = value;
            }
        }
    }
}
