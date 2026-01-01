using System;
using System.Collections.Generic;
using System.Text;

namespace CampusIssueTracker.Core
{
    public class LogManager
    {
        // Log file path
        private string logFile = "system_log.txt";
        public void WriteLog(string message)
        {
            // Append log message with timestamp to log file
            File.AppendAllText(logFile, DateTime.Now + " : " + message + Environment.NewLine);
        }
    }
}
