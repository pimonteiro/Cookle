using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class Historico
    {
        [Key]
        public int User { get; set; }
        
        [Key]
        public int Receita { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime UltimaVez { get; set; }
        
        public int Numero { get; set; }
        
        [ForeignKey("User")]
        public virtual User Users { get; set; }
        
        [ForeignKey("Receita")]
        public virtual Receita Receitas { get; set; }
        
    }
}