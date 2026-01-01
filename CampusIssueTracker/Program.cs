using System;
using CampusIssueTracker.Entities;
using CampusIssueTracker.Generics;
using CampusIssueTracker.Services;
using CampusIssueTracker.RegexEngine;
using CampusIssueTracker.Indexers;
using CampusIssueTracker.Diagnostics;
using CampusIssueTracker.Core;

namespace CampusIssueTracker
{
    class Program
    {
        static void Main()
        {
            var issueRepo = new Repository<Issue>();
            var validator = new IssueValidator();
            var issueService = new IssueService(issueRepo, validator);
            var issueIndexer = new IssueIndexer();
            var memoryTracker = new MemoryTracker();
            var logger = new LogManager();

            // Creating Issues
            issueService.CreateIssue(1, "Wifi not working in lab");
            issueService.CreateIssue(2, "Projector screen broken");

            // Add issues to indexer
            foreach (var issue in issueRepo.GetAll())
                issueIndexer.AddIssue(issue);

            // Accessing issue using indexer
            var selectedIssue = issueIndexer[1];
            Console.WriteLine("Fetched Issue: " + selectedIssue.Description);

            // Logging activity
            logger.WriteLog("Fetched issue with ID 1");

            // Display memory usage
            memoryTracker.ShowMemoryUsage();
        }
    }
}
