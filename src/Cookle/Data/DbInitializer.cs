using Cookle.Models;
using System;
using System.Linq;
using Cookle.Data;

namespace Cookle.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CookleContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new[]
            {
            new User{Email =  "Alexander@puta.db", Username = "Alex", Password = "ola", Sexo = Sexo.M, DataNascimento = DateTime.Parse("2002-09-01"), Voz = true},
            new User{Email =  "werexander@puta.db", Username = "Awerx", Password = "olwerwe", Sexo = Sexo.NA, DataNascimento = DateTime.Parse("2012-09-01"), Voz = false}

            };
            foreach (var s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

        }
    }
}