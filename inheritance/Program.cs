using System;
// INHERITANCE EXAMPLE PROGRAM
public class Animal
{
    public int id;
    public string name;

    public Animal(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
// Dog class inherits from Animal
public class Dog : Animal
{
    public string breed;

    public Dog(int id, string name, string breed) : base(id, name)
    {
        this.breed = breed;
    }
}
// Cat class inherits from Dog
public class Cat : Dog
{
    public string color;

    public Cat(int id, string name, string breed, string color)
        : base(id, name, breed)
    {
        this.color = color;
    }
}
// Main program to demonstrate inheritance
class Program
{
    static void Main()
    {
        Animal a = new Animal(1, "AnimalBase");
        Dog d = new Dog(2, "Buddy", "Bulldog");
        Cat c = new Cat(3, "Kitty", "Persian", "White");

        Console.WriteLine(GetDetails(a));
        Console.WriteLine(GetDetails(d));
        Console.WriteLine(GetDetails(c));
    }
    // Method to get details based on the type of animal
    static string GetDetails(Animal a)
    {
        if (a is Cat c)
            return $"Id={c.id}, Name={c.name}, Breed={c.breed}, Color={c.color}";
        if (a is Dog d)
            return $"Id={d.id}, Name={d.name}, Breed={d.breed}";
        return $"Id={a.id}, Name={a.name}";
    }
}
