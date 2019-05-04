using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class Plano
    {
        [Key] public int User { get; set; }

        [ForeignKey("User")] public virtual User Users { get; set; }

        [Key] public int Receita { get; set; }

        [ForeignKey("Receita")] public virtual Receita Receitas { get; set; }
    }
}