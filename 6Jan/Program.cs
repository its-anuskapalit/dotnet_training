// using System.Xml.Serialization;
// using System.IO;
// using System.Text;
// public class Person
// {
//     public int ID { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         var person = new Person
//         {
//             ID = 42,
//             FirstName = "Anuska",
//             LastName = "Palit",      
//         };
//         string xmlOutput = XmlHelper.SerializeToXml(person);
//         Console.WriteLine(xmlOutput);

//     }
// }


//===============================================================================================
//using System;
// using System.IO;
// using System.Text;
// using System.Xml.Serialization;

// public class Person
// {
//     public int ID { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         Person person = new Person
//         {
//             ID = 42,
//             FirstName = "Anuska",
//             LastName = "Palit"
//         };

//         XmlSerializer serializer = new XmlSerializer(typeof(Person));
//         string xmlOutput;

//         using (StringWriter writer = new StringWriter())
//         {
//             serializer.Serialize(writer, person);
//             xmlOutput = writer.ToString();
//         }

//         Console.WriteLine(xmlOutput);

//     }
// }

//======================================================================================================================

using System;
using System.Text.Json;
using System.Xml.Serialization;
using System.Collections.Generic;
public class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   [XmlArray("Scores")]
   [XmlArrayItem("Score")]
   public int[] Scores { get; set; }
   [XmlArray("Subjects")]
   [XmlArrayItem("Names")]
   public string[] Subjects {get;set ;}
    [XmlArray("Hobbies")]
    [XmlArrayItem("Hobby")]
    public List<string> Hobbies { get; set; }
    }
class Program
{
    static void Main()
    {
        Person person = new Person
        {
            ID = 42,
            FirstName = "Anuska",
            LastName = "Palit",
            Scores= new int[] {41,56,42},
            Subjects= new string[] {"Maths","Hindi"},
            Hobbies = new List<string> { "Reading", "Coding", "Reading" }
        };
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        serializer.Serialize(Console.Out, person);
         Console.WriteLine("\n---------------- JSON ----------------");
        string json=JsonSerializer.Serialize(person, new JsonSerializerOptions {WriteIndented =  true});
        Console.WriteLine(json);
    }
}
