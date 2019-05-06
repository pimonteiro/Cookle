using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cookle.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [Display(Name = "Name")]
        [StringLength(45)]
        public string Name { get; set; }

        public ICollection<Morada> Moradas;
    }
}