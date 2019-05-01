using System.ComponentModel.DataAnnotations;

namespace Cookle.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nome")]
        [StringLength(45)]
        public string Nome { get; set; }
        
    }
}