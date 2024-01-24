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

        public async Task<ICollection<PetShelter>> AllPets()
        {
            return await _context.PetShelters.ToListAsync();
        }
    }
}
