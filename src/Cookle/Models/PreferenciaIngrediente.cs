using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class PreferenciaIngrediente
    {
        [Key] public int User { get; set; }

        [Key] public int Ingrediente { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [MaxLength(Int32.MaxValue)]
        public int Tipo { get; set; }

        [ForeignKey("Ingrediente")] public virtual int Ingredientes { get; set; }

        [ForeignKey("User")] public virtual int Users { get; set; }
    }
}