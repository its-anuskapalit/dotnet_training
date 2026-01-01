using System;
namespace UniExamPro.Entities
{
    // Session entity class
    public class Session
    {
        //properties
        public int SessionId { get; private set; }
        public string SessionName { get; private set; }
        //constructor
        public Session(int sessionId, string sessionName)
        {
            SessionId = sessionId;
            SessionName = sessionName;
        }
        //method to display session info
        public void DisplayInfo()
        {
            Console.WriteLine($"Session Id: {SessionId}, Session: {SessionName}");
        }
    }
}
