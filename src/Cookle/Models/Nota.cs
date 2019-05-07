using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        
        public int ReceitaId { get; set; }
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "Descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
        
        public Receita Receita { get; set; }
        
        public User User { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}