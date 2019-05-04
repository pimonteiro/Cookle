using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class IngredienteReceita
    {
        [Key] public int Receita { get; set; }

        [Key] public int Ingrediente { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        [MaxLength(Int32.MaxValue)]
        public float Quantidade { get; set; }
        
        [Required]
        [Display(Name = "Unidade")]
        [MaxLength(Int32.MaxValue)]
        public int  Unidade { get; set; }

        [ForeignKey("Ingrediente")] public virtual Ingrediente Ingredientes { get; set; }

        [ForeignKey("Receita")] public virtual Receita Receitas { get; set; }
    }
}