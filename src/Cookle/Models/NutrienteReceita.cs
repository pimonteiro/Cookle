using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class NutrienteReceita
    {
        [Key] public int ReceitaId { get; set; }

        [Key] public int NutrienteId { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public float Quantidade { get; set; }

        public Nutriente Nutriente { get; set; }

        public Receita Receita { get; set; }
    }
}