using System.ComponentModel.DataAnnotations;

namespace DecBatch2025MVCCoreProject.Models
{
    public class Auth
    {
        [Required(ErrorMessage ="Field is Required")]
        [RegularExpression(pattern:"",ErrorMessage ="")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Salary is Required")]
        [Range(minimum:1000,maximum:5000,ErrorMessage ="Salary inbetween 1k-5k")]
        public double Salary { get; set; }
    }
}
