// using System;
// namespace MyProject1{
// public class Person
// {
//     public int id{get; set;}
//     public String? name{get; set;}
//      public int age{get; set;}
    
// }
// public class Man: Person
// {
//     public String? playing{get; set;}
// }
// public class Woman: Person
// {
//     public String? PlayingManage{get; set;}
// }

// public class inheritance
// {
//     public static void Main()
//     {
//         inheritance i=new inheritance();
//         Person p=new Person() {id= 1,name= "Anni",age=19};
//         Man m=new Man() {id= 1,name= "Anit",age=20,playing="footbal"};
//         Woman w=new Woman() {id= 1,name= "Anuska",age=21,PlayingManage="footbal and home"};
//         Console.WriteLine(i.GetDetails(p));
//         i.GetDetails(m);
//         i.GetDetails(w);


//     }
//     public string GetDetails(Person p)
//     {
//         return $"Id= {p.id}, Name= {p.name} and age ={p.age}";
//     }
//     public string GetManDetails(Man m)
//     {
//         return $"Id= {m.id}, Name= {m.name} and age ={m.age}, playing={m.playing}";
//     }
// }
// }