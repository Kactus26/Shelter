using Microsoft.EntityFrameworkCore;
using Shelter.Data;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Repository
{
    public class PetShelterRepository : IPetShelter
    {
        private readonly DataContext _context;
        public PetShelterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PetShelter>> PetShelters()
        {
            return await _context.PetShelters.ToListAsync();
        }

        public async Task<bool> ShelterExists(string addres)
        {
            PetShelter shelter = await _context.PetShelters.Where(x=>x.Addres == addres).FirstOrDefaultAsync();
            if (shelter == null)
                return true;
            else
                return false;
        }

        public async Task<ICollection<Product>> ProductsInShelter(string addres)
        {
            PetShelter petShelter = await _context.PetShelters.Include(shelter => shelter.Products).Where(x => x.Addres == addres).FirstOrDefaultAsync();
            return petShelter.Products;
        }

        public async Task<ICollection<Pet>> PetsInShelter(string addres)
        {
            PetShelter petShelter = await _context.PetShelters.Include(shelter => shelter.Pets).Where(x => x.Addres == addres).FirstOrDefaultAsync();
            return petShelter.Pets;
        }
    }
}
