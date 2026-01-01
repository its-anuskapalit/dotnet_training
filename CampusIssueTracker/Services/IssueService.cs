using System;
using CampusIssueTracker.Entities;
using CampusIssueTracker.Generics;
using CampusIssueTracker.RegexEngine;
using CampusIssueTracker.Core;
namespace CampusIssueTracker.Services
{
    // Handles creation and management of Issues
    public class IssueService
    {
        private Repository<Issue> repo;
        private IssueValidator validator;

        // Dependency Injection via constructor
        public IssueService(Repository<Issue> repository, IssueValidator issueValidator)
        {
            repo = repository;
            validator = issueValidator;
        }
        public void CreateIssue(int id, string description)
        {
            try
            {
                // Validate description using Regex
                if (!validator.IsValid(description))
                    throw new AppException("Invalid issue description format");

                // Create Issue object
                Issue issue = new Issue(id, description);

                // Add issue to repository
                repo.Add(issue);

                Console.WriteLine("Issue created successfully");
            }
            catch (AppException ex)
            {
                Console.WriteLine("App Error: " + ex.Message);
            }
            finally
            {
                // finally block always executes
                Console.WriteLine("CreateIssue operation finished");
            }
        }
    }
}
