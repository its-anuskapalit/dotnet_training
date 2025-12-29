using System;

namespace indexer
{
    public class Student
    {
        public int Rno { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        string[] books = new string[4];

        public string this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }
    }
}
