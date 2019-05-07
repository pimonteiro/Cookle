using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? TempoPrep { get; set; }

        [Display(Name = "NumPessoas")]
        public int? NumPessoas { get; set; }
       
        [Display(Name = "Dificuldade")]
        public int? Dificuldade { get; set; }
       
        [Display(Name = "Tipo")]
        public int? Tipo { get; set; }

        [Display(Name = "Imagem")] [StringLength(45)]
        public string Imagem { get; set; }
        
        [Display(Name = "Video")]
        [StringLength(45)]
        public string Video { get; set; }

        public IList<Plano> Planos { get; set; }
        
        [InverseProperty("Receita")]
        public IList<Passo> Passos { get; set; }
        
        public IList<NutrienteReceita> NutrienteReceitas { get; set; }
        
        public IList<Nota> Notas { get; set; }
        
        public IList<IngredienteReceita>  IngredienteReceitas { get; set; }

        public IList<Historico> Historicos { get; set; }
        
        [InverseProperty("SubReceita")]
        public ICollection<Passo> SubReceitas { get; set; }
    }
}