using System;
// VISITOR CLASS WITH CONSTRUCTOR CHAINING AND LOGGING
namespace Oops
{
    // Visitor class definition
    public class Visitor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Requirement { get; set; }
        public string? LogHistory { get; set; }

        // Default constructor
        public Visitor()
        {
            LogHistory+=$"Object created on {DateTime.Now.ToString()}      {Environment.NewLine}";
        
            
        }
        public Visitor(int id):this()
        {
            LogHistory+=$"ID created on {DateTime.Now.ToString()}      {Environment.NewLine}";
            this.Id = id;
        }

        public Visitor(int id, string name): this(id)
        {
           // this.Id = id;
            if (name.ToLower().Contains("idiot"))
            {
                throw new ArgumentException("Dont type like this idiot");
            }
            LogHistory+=$"Name created on {DateTime.Now.ToString()}      {Environment.NewLine}";
            this.Name = name;
        }

        public Visitor(int id, string name, string requirement): this(id,name)
        {
            // this.Id = id;
            // this.Name = name;
            this.Requirement = requirement;
            LogHistory+=$"Requirement created on {DateTime.Now.ToString()}      {Environment.NewLine}";
            Console.WriteLine(LogHistory);
        }
        // public int Num1{ get; set; }
        // public int Num2{ get; set; } //only set properties
        // public int Result { get;}
        // public Visitor(int a ,int b)
        // {
        //     Result = Num1+ Num2; //in construtor get properties can set the value
        // } 

    }
}
