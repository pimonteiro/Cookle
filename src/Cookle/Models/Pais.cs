using System.ComponentModel.DataAnnotations;

namespace Cookle.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [Required] 
        [Display(Name = "Name")]
        [StringLength(45)]
        public string Name { get; set; }
    }
}