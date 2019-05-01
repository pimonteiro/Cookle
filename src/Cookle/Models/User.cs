using System;
using System.ComponentModel.DataAnnotations;
namespace Cookle.Models
{
    public enum Sexo
    {
        F, M, NA
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Sexo Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public bool Voz;
        //falta morada como chave estrangeira
    }
    
}