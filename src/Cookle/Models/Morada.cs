using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class Morada
    {
        [Key]
        public string Rua { get; set; }
        
        [Key]
        public string Cidade { get; set; }
        
        [Key]
        public string CodigoPostal { get; set; }
        
        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual Pais Pais { get; set; }
    }
}