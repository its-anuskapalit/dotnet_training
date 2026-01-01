using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace CampusIssueTracker.RegexEngine
{
    public class IssueValidator
    {
        // Pattern: Three uppercase letters followed by a hyphen and four digits (e.g., ABC-1234)
        private readonly string pattern= @"^[A-Z]{3}-\d{4}$";
        public bool IsValid(string description)
        {
            // Validate issue description against the pattern
            return Regex.IsMatch(description, pattern);
        }
    }
}
