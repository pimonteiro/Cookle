using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cookle.Models
{
    
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nome")]
        [StringLength(45)]
        public string Nome { get; set; }
        
        public IList<PreferenciaIngrediente> PreferenciaIngredientes { get; set; }
        
        public IList<IngredienteReceita>  IngredienteReceitas { get; set; }
        
        public IList<Frigorifico> Frigorificos { get; set; }
        
    }
}