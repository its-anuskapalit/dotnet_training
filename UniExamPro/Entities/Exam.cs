using System;
namespace UniExamPro.Entities
{
    // Exam entity class
    public class Exam
    {
        //properties
        public int ExamId { get; private set; }
        public int CourseId { get; private set; }
        public int SessionId { get; private set; }
        public int? ExaminerId { get; private set; }
        //constructor
        public Exam(int examId, int courseId, int sessionId)
        {
            ExamId = examId;
            CourseId = courseId;
            SessionId = sessionId;
            ExaminerId = null;
        }
        //method to allocate examiner
        public void AllocateExaminer(int examinerId)
        {
            ExaminerId = examinerId;
        }
        //method to display exam info
        public void DisplayInfo()
        {
            Console.WriteLine($"ExamId: {ExamId}, CourseId: {CourseId}, SessionId: {SessionId}, ExaminerId: {ExaminerId}");
        }
    }
}
