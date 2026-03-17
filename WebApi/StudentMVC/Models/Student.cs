using System.ComponentModel.DataAnnotations;

namespace StudentMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public DateTime JoinDate { get; set; }
    }
}