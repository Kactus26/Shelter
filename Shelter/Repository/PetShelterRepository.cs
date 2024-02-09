using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Data;
using Shelter.DTO;
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

        public async Task<PetShelter> GetShelterByAddress(string address)
        {
            return _context.PetShelters.FirstOrDefault(x => x.Address == address);
        }

        public async Task<bool> ShelterExists(int shelterId)
        {
            PetShelter shelter = await _context.PetShelters.Where(x=>x.Id == shelterId).FirstOrDefaultAsync();
            if (shelter == null)
                return true;
            else
                return false;
        }

        public async Task<ICollection<Product>> ProductsInShelter(int shelterId)
        {
            PetShelter petShelter = await _context.PetShelters.Include(shelter => shelter.Products).Where(x => x.Id == shelterId).FirstOrDefaultAsync();
            return petShelter.Products;
        }

        public async Task<ICollection<PetDTO>> PetsInShelter(int shelterId)
        {
            ICollection<PetDTO> pets = await _context.Pets.Include(pet => pet.Owner).Where(x => x.PetShelter.Id == shelterId)
            .Select(x => new PetDTO
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender,
                KindOfAnimal = x.KindOfAnimal,
                Breed = x.Breed,
                DateOfTaking = x.DateOfTaking,
                OwnerId = x.Owner.Id,
                OwnerName = x.Owner.Name,
                OwnerSurName = x.Owner.SurName,
                OwnerAddress = x.Owner.Address,
                PetShelterId = x.PetShelter.Id,
                PetShelterAddress = x.PetShelter.Address
            }).ToListAsync();

            return pets;
        }

        public ValueTask<EntityEntry<Pet>> AddPet(Pet pet)
        {
            return _context.Pets.AddAsync(pet);
        }

        public ValueTask<EntityEntry<PetShelter>> AddPetShelter(PetShelter petShelter)
        {
            return _context.PetShelters.AddAsync(petShelter);
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
