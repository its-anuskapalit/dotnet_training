using System;
using System.Collections.Generic;
using System.Text;

namespace CampusIssueTracker.Core
{
    public class AppException: Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}
