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
        
        public int Pais { get; set; }
        
        [ForeignKey("Pais")]
        public virtual Pais Paises { get; set; }
    }
}