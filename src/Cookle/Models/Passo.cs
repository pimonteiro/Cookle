using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Passo
    {
        [Key]
        public int Numero { get; set; }
        [Key]
        public int Ingrediente { get; set; }
        
        public int? SubReceita { get; set; }
        
        [Display(Name = "Descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
        
        [ForeignKey("Ingrediente")]
        public virtual float Ingredientes { get; set; }
    }
}