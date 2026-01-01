using System;
/// <summary>
/// class representing a base person
/// </summary>
namespace UniExamPro.Core
{
    //base person class
    public abstract class BasePerson
    {
        //properties
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        protected BasePerson(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public abstract void DisplayInfo();
    }
}
