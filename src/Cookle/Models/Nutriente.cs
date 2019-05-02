using System;
using System.ComponentModel.DataAnnotations;
using SQLitePCL;

namespace Cookle.Models
{
    public class Nutriente
    {
        [Key]
        public int Id{ get; set; }

        [Required] [Display(Name = "Nome")] [StringLength(45)]
        public string Nome { get; set; }

        [Required] [Display(Name = "Unidade")] [MaxLength(Int32.MaxValue)]
        public int Unidade { get; set; }
    }
}