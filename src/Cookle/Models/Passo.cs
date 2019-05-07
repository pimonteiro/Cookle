using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookle.Models
{
    public class Passo
    {
        [Key] public int Numero { get; set; }
        
        [Key] 
        public int ReceitaId { get; set; }
        
        public int? SubReceitaId { get; set; }
                
        [Required, StringLength(200)]
        public string Descricao { get; set; }
        
        public virtual Receita SubReceita { get; set; }
        
        public Receita Receita { get; set; }
    }
}