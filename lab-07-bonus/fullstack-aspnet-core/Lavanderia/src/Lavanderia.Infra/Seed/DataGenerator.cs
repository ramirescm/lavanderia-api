using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lavanderia.Infra.Seed
{
    public class DataGenerator
    {
        //https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LavanderiaContext(
                serviceProvider.GetRequiredService<DbContextOptions<LavanderiaContext>>()))
            {
                // Look for any board games.
                if (context.Usuarios.Any())
                {
                    return;   // Data was already seeded
                }

                context.Usuarios.AddRange(
                    new Usuario
                    {
                        Id = 1,
                        Login = "Candy Land",
                        Senha = "Hasbro",
                    },
                    new Usuario
                    {
                        Id = 2,
                        Login = "Sorry!",
                        Senha = "Hasbro",
                    },
                    new Usuario
                    {
                        Id = 3,
                        Login = "Ticket to Ride",
                        Senha = "Days of Wonder",
                    },
                    new Usuario
                    {
                        Id = 4,
                        Login = "The Settlers of Catan (Expanded)",
                        Senha = "Catan Studio",
                    },
                    new Usuario
                    {
                        Id = 5,
                        Login = "Carcasonne",
                        Senha = "Z-Man Games",
                    },
                    new Usuario
                    {
                        Id = 6,
                        Login = "Sequence",
                        Senha = "Jax Games",
                    });

                context.SaveChanges();
            }
        }
    }
}
