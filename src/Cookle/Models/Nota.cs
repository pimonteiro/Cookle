using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int Receita { get; set; }
        [Key]
        public int User { get; set; }
        
        [Required]
        [Display(Name = "Descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
        
        [ForeignKey("Receita")]
        public virtual Receita Receitas { get; set; }
        
        [ForeignKey("User")]
        public virtual User Users { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}