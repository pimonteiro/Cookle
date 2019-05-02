using System;
using System.ComponentModel.DataAnnotations;

namespace Cookle.Models
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nome")]
        [StringLength(45)]
        public string Nome { get; set; }
        
        [Required]
        [Display(Name = "Descricao")]
        [StringLength(150)]
        public string Descricao { get; set; }
       
        [Display(Name = "TempoPrep")]
        [MaxLength(Int32.MaxValue)]
        public int? TempoPrep { get; set; }

        [Display(Name = "NumPessoas")]
        [MaxLength(Int32.MaxValue)]
        public int? NumPessoas { get; set; }
       
        [Display(Name = "Dificuldade")]
        [MaxLength(Int32.MaxValue)]
        public int? Dificuldade { get; set; }
       
        [Display(Name = "Tipo")]
        [MaxLength(Int32.MaxValue)]
        public int? Tipo { get; set; }

        [Display(Name = "Imagem")] [StringLength(45)]
        public string Imagem { get; set; }
        
        [Display(Name = "Video")]
        [StringLength(45)]
        public string Video { get; set; }


    }
}