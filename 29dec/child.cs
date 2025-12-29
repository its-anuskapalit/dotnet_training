using System;

namespace PartialClass
{
    public partial class childParent
    {
        public int Id { get; set; }

        public void Display()
        {
            Console.WriteLine("Id: " + Id);
        }
    }
}
