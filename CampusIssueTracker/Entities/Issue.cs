using System;
using System.Collections.Generic;
using System.Text;
namespace CampusIssueTracker.Entities
{
    // Issue class representing an issue reported in the system
    public class Issue
    {
        public int IssueId { get; private set; }
        public string Description { get; private set; }
        // Nullable type: Issue may or may not have an assigned technician
        public int? AssignedTechnicianId { get; private set; }
        public string Status { get; private set; }
        public Issue(int id, string desc){
            IssueId = id;
            Description = desc;
            AssignedTechnicianId = null;
        }
        // Method to assign a technician to the issue
        public void AssignTechnician(int techId)
        {
            AssignedTechnicianId = techId;
        }
        // Method to close the issue
        public void CloseIssue()
        {
            Status = "Closed";
        }
    }
}
