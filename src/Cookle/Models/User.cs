using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public enum Sexo
    {
        F,
        M,
        NA
    }

    public class User : IdentityUser<int>
    {
       
       // [Required]
        [Display(Name = "sexo")]
        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required] [Display(Name = "voz")] public bool Voz { get; set; }
        
        public IList<PreferenciaIngrediente> PreferenciaIngredientes { get; set; }

        public IList<Plano> Planos { get; set; }
        
        public IList<Nota> Notas { get; set; }
        
        public IList<Frigorifico> Frigorificos { get; set; }
        
        public IList<Historico> Historicos { get; set; }
    }

}