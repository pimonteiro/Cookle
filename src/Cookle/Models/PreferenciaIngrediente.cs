using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public enum Tipo
    {
    Pref,
    Evitar
    }
    public class PreferenciaIngrediente
    {
        [Key] public int UserId { get; set; }

        [Key] public int IngredienteId { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [EnumDataType(typeof(Tipo))]
        public Tipo Tipo { get; set; }

         public  Ingrediente Ingrediente { get; set; }

         public User User { get; set; }
    }
}