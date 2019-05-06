using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class Historico
    {
        [Key]
        public int UserId { get; set; }
        
        [Key]
        public int ReceitaId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime UltimaVez { get; set; }
        
        public int Numero { get; set; }
        
        public User User { get; set; }
        
        public Receita Receita { get; set; }
        
    }
}