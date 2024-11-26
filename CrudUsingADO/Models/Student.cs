using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name="Branch")]
        public string? Branch { get; set; }
        [Required]
        [Display(Name="Email Id")]
        public string? Email { get; set; }
        [Required]
        [Display(Name="Percentage")]
        public double Percentage { get; set; }
    }
}
