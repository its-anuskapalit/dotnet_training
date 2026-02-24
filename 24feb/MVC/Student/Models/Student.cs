using System.ComponentModel.DataAnnotations;
namespace Employee.Models
{
    public class Student
    {
        public int ID   { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
    }
}
