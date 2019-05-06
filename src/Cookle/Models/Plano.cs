using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class Plano
    {
        [Key] public int UserId { get; set; }

        public virtual User User { get; set; }

        [Key] public int ReceitaId { get; set; }

        public virtual Receita Receita { get; set; }
    }
}