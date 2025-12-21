// using System;
// using MyProject1;
// class Program
// {
//     public static void main()
//     {
//         //Student.Main();
//         //                 OR
//         // Student s1 = new Student("Anuska", 21, 12206089);
//         // s1.DisplayInfo();
        
        
//     }
// }

//========================================================================================================
// using System;
// public class Person
// {
//     // public Person()
//     // {
//     //     id=0;
//     //     name=string.Empty;
//     //     age=0;
//     // }
//     public Person()
//     {
//         id=0;
//         name=string.Empty;
//         age=0;
//     }
//     public int id{get; set;}
//     public String? name{get; set;}
//      public int age{get; set;}
    
// }
// public class Man: Person
// {
//     public Man()
//     {
//         id=0;
//         name=string.Empty;
//         age=0;
//         playing="";
//     }
//     public String? playing{get; set;}
// }
// public class Woman: Person
// {
//     public Woman()
//     {
//         id=0;
//         name=string.Empty;
//         age=0;
//         PlayingManage="";
//     }
//     public String? PlayingManage{get; set;}
// }

// public class Program
// {
//     public static void Main()
//     {
//         Program i=new Program ();
//         Person p=new Person() {id= 1,name= "Anni",age=19};
//         Man m=new Man() {id= 1,name= "Anit",age=20,playing="football "};
//         Man m1=new Man();

//         Woman w=new Woman() {id= 1,name= "Anuska",age=21,PlayingManage="footbal and home"};
//         Console.WriteLine(i.GetDetails(p));
//         Console.WriteLine(i.GetDetails(m));
//         Console.WriteLine(i.GetDetails(m1)); //constructors
//         Console.WriteLine(i.GetDetails(w));


//     }
//     public string GetDetails(Person p)
//     {
//         if(p is Man)
//         {
//             Man m=(Man)p;
//             return $"Id= {m.id}, Name= {m.name} and age ={m.age}, playing={m.playing}";
//             }
//         if(p is Woman)
//         {
//           Woman m=(Woman)p;
//             return $"Id= {m.id}, Name= {m.name} and age ={m.age}, playing={m.PlayingManage}";
//             }   
//         return $"Id= {p.id}, Name= {p.name} and age ={p.age}";
        
//         }

//     // public string GetDetails(Person p)
//     // {
//     //     return $"Id= {p.id}, Name= {p.name} and age ={p.age}";
//     // }
//     // public string GetManDetails(Man m)
//     // {
//     //     return $"Id= {m.id}, Name= {m.name} and age ={m.age}, playing={m.playing}";
//     // }
// }

//===================================================================================================================
using System;

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

public class Dog : Animal
{
    public string breed;

    public Dog(int id, string name, string breed) : base(id, name)
    {
        this.breed = breed;
    }
}

public class Cat : Dog
{
    public string color;

    public Cat(int id, string name, string breed, string color)
        : base(id, name, breed)
    {
        this.color = color;
    }
}

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

    static string GetDetails(Animal a)
    {
        if (a is Cat c)
            return $"Id={c.id}, Name={c.name}, Breed={c.breed}, Color={c.color}";
        if (a is Dog d)
            return $"Id={d.id}, Name={d.name}, Breed={d.breed}";
        return $"Id={a.id}, Name={a.name}";
    }
}
