using System.ComponentModel.DataAnnotations;

namespace Cookle.Models

{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "email")]
        [StringLength(45)]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "password")]
        [StringLength(45)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        [StringLength(45)]
        public string Name { get; set; }
    }
}