namespace Inheritance2
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
            Console.WriteLine("Dog Speaks");
        }
    }
    class Cat: Animal
    {
        public override  void Speak()
        {
            Console.WriteLine("Cat Speaks");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Animal> animals=new List<Animal>()
            {
                new Dog(),
                new Cat()
            };
            foreach(var animal in animals)
            {
                animal.Speak();
            }
        }
    
    }
}