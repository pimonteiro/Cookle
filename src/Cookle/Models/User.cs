using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public enum Sexo
    {
        F,
        M,
        NA
    }

    public class User
    {
        [Key] public int Id { get; set; }

        [Required]
        [Display(Name = "email")]
        [StringLength(45)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "username")]
        [StringLength(45)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "password")]
        [StringLength(45)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "sexo")]
        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required] [Display(Name = "voz")] public bool Voz { get; set; }

        [Required] [Display(Name = "Morada")] public int Morada { get; set; }

        [ForeignKey("Morada")] public virtual Morada Moradas { get; set; }
    }

}