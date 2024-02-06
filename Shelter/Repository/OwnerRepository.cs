using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Data;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Repository
{
    public class OwnerRepository : IOwner
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pet> GetPetByName(string petName)
        {
            return await _context.Pets.FirstOrDefaultAsync(x=>x.Name==petName);
        }

        public ValueTask<EntityEntry<Owner>> AddOwner(Owner owner)
        {
            return _context.Owners.AddAsync(owner);
        }
        
        public async Task<ICollection<Owner>> GetOwners()
        {
            return await _context.Owners.Include(x=>x.Pets).ToListAsync();
        }

        public async Task<bool> PetHasOwner(string petName)
        {
            Pet pet = await _context.Pets.Include(x=>x.Owner).FirstOrDefaultAsync(x => x.Name == petName);
            if (pet.Owner != null)
                return true;
            else
                return false;
        }
        public async Task<Owner> GetOwner(string name)
        {
            return await _context.Owners.Include(x=>x.Pets).Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Pet> GetPet(string name)
        {
            return await _context.Pets.Include(x=>x.Owner).Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
