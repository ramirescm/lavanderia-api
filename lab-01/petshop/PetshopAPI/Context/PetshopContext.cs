using Microsoft.EntityFrameworkCore;
using PetshopAPI.Models;

namespace PetshopAPI.Context
{
    public class PetshopContext : DbContext
    {
        public PetshopContext(DbContextOptions<PetshopContext> options)
            : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
    }
}
