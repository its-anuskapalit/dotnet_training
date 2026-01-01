using CampusIssueTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace CampusIssueTracker.Indexers
{
    public class IssueIndexer
    {
        // Internal list to store issues
        private List<Issue> issues = new List<Issue>();
        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
        }
        // Indexer to access issues by their IssueId
        public Issue this[int id]
        {
            get
            {
                foreach(var issue in issues)
                {
                    if (issue.IssueId == id)
                    {
                        return issue;
                    }
                }
                return null;
            }
        }
    }
}
