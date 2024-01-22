using Microsoft.EntityFrameworkCore;
using Shelter.Models;

namespace Shelter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PetShelter> PetShelters { get; set; }

    }
}
