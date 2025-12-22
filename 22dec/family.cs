using System;

// FAMILY CLASS WITH CONSTRUCTOR CHAINING AND LOGGING
namespace Oops
{
    // Family class definition
    public class Family
    {
        // Auto-implemented properties
        public int FamilyId { get; set; }
        public string? HeadName { get; set; }
        public int MembersCount { get; set; }
        public string? LogHistory { get; set; }

        // Default constructor
        // Initializes the object and logs creation time
        public Family()
        {
            LogHistory += $"Family object created on {DateTime.Now}{Environment.NewLine}";
        }

        // Constructor with FamilyId
        // Calls default constructor using constructor chaining
        public Family(int familyId) : this()
        {
            FamilyId = familyId;
            LogHistory += $"Family ID assigned on {DateTime.Now}{Environment.NewLine}";
        }

        // Constructor with FamilyId and HeadName
        // Calls previous constructor
        public Family(int familyId, string headName) : this(familyId)
        {
            // Validation: restrict inappropriate words
            if (headName.ToLower().Contains("idiot"))
            {
                throw new ArgumentException("Invalid head name provided");
            }

            HeadName = headName;
            LogHistory += $"Head name assigned on {DateTime.Now}{Environment.NewLine}";
        }

        // Constructor with FamilyId, HeadName, and MembersCount
        // Calls the previous constructor
        public Family(int familyId, string headName, int membersCount) : this(familyId, headName)
        {
            MembersCount = membersCount;
            LogHistory += $"Members count assigned on {DateTime.Now}{Environment.NewLine}";

            // Print complete log history
            Console.WriteLine(LogHistory);
        }
    }
}
