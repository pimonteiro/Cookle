using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class IngredienteReceita
    {
        [Key] public int ReceitaId { get; set; }

        [Key] public int IngredienteId { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public float Quantidade { get; set; }
        
        [Required]
        [Display(Name = "Unidade")]
        public int  Unidade { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public Receita Receita { get; set; }
    }
}