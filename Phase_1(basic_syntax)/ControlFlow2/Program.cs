using System;
using System.Collections.Generic;

namespace LoopMastery
{
    enum LogLevel
    {
        Info,
        Warning,
        Error,
        Critical
    }

    class Log
    {
        public LogLevel Level;
        public int RetryCount;
        public bool IsCorrupted;
    }

    class Program
    {
        static int ProcessLogs(List<Log> logs)
        {
            int processCount = 0;

            foreach (var log in logs)
            {
                if (log.IsCorrupted)
                {
                    continue;
                }

                switch (log.Level)
                {
                    case LogLevel.Info:
                        processCount++;
                        break;

                    case LogLevel.Warning:
                        HandleWarning(log);
                        break;

                    case LogLevel.Error:
                        if (!RetryProcessing(log))
                        {
                            return processCount;
                        }
                        processCount++;
                        break;

                    case LogLevel.Critical:
                        return processCount;
                }
            }

            return processCount;
        }

        static void HandleWarning(Log log)
        {
            for (int i = 0; i < log.RetryCount; i++)
            {
                Console.WriteLine("Warning retry...");
            }
        }

        static bool RetryProcessing(Log log)
        {
            int attempts = 0;

            while (attempts < log.RetryCount && attempts < 2)
            {
                attempts++;
            }

            return attempts < 3;
        }

        static void Main()
        {
            var logs = new List<Log>
            {
                new Log { Level = LogLevel.Info, RetryCount = 0, IsCorrupted = false },
                new Log { Level = LogLevel.Error, RetryCount = 2, IsCorrupted = false },
                new Log { Level = LogLevel.Warning, RetryCount = 1, IsCorrupted = true },
                new Log { Level = LogLevel.Critical, RetryCount = 3, IsCorrupted = false }
            };

            int processed = ProcessLogs(logs);
            Console.WriteLine(processed);
        }
    }
}
