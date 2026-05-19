namespace Inheritance
{
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal Speaks");
        }
    }
    class Dog: Animal
    {
        public override  void Speak()
        {
            base.Speak();
            Console.WriteLine("Dog Speaks");
        }
    }
    class Program
    {
        static void Main()
        {
            Animal dog=new Dog();
            dog.Speak();
        }
    
    }
}