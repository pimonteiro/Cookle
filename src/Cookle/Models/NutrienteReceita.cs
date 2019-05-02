using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class NutrienteReceita
    {
        [Key] public int Receita { get; set; }

        [Key] public int Nutriente { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        [MaxLength(Int32.MaxValue)]
        public float Quantidade { get; set; }

        [ForeignKey("Nutriente")] public virtual int Nutrientes { get; set; }

        [ForeignKey("Receita")] public virtual int Receitas { get; set; }
    }
}