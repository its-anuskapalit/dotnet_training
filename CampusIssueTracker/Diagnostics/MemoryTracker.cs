using System;
using System.Collections.Generic;
using System.Text;

namespace CampusIssueTracker.Diagnostics
{
    public class MemoryTracker
    {
        public void ShowMemoryUsage()
        {
            // Get memory usage before garbage collection
            long before = GC.GetTotalMemory(false);
            Console.WriteLine("Memore befor GC: "+before);

            // Force garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Get memory usage after garbage collection
            long after = GC.GetTotalMemory(true);
            Console.WriteLine("Memory after GC: " + after);
        }
    }
}
