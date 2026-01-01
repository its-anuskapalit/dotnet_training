using System;
using System.Collections.Generic;
using System.Text;

namespace CampusIssueTracker.Core
{
    // Base class for different types of persons in the system
    public abstract class Person
    {
        // Unique identifier for the person
        public int Id { get; protected set; }
        // Name of the person
        public string Name { get; protected set; }
        // Constructor to initialize common properties
        protected Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public abstract void DisplayInfo();

        
    }
}
