using Shelter.Models;
using System.Diagnostics.Metrics;

namespace Shelter.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PetShelters.Any())
            {
                var petShelter = new PetShelter()
                {
                    Addres = "test"
                };
                dataContext.PetShelters.Add(petShelter);
                dataContext.SaveChanges();
            } 
        }
    }
}
