using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Frigorifico
    {
        [Key] public int UserId { get; set; }

        [Key] public int IngredienteId { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }
        
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        public Ingrediente Ingrediente { get; set; }

        public User User { get; set; }
    }
}