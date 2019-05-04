using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Frigorifico
    {
        [Key] public int User { get; set; }

        [Key] public int Ingrediente { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        [MaxLength(Int32.MaxValue)]
        public int Quantidade { get; set; }
        
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        [ForeignKey("Ingrediente")] public virtual Ingrediente Ingredientes { get; set; }

        [ForeignKey("User")] public virtual User Users { get; set; }
    }
}