using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Data;
using Shelter.DTO;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Repository
{
    public class PetRepository : IPet
    {
        private readonly DataContext _context;
        public PetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> ShelterExists(string address)
        {
            PetShelter shelter = await _context.PetShelters.Where(x => x.Address == address).FirstOrDefaultAsync();
            if (shelter == null)
                return true;
            else
                return false;
        }

        public async Task<ICollection<PetDTO>> GetAllPets()
        {
            return await _context.Pets.Include(pet => pet.Owner)
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
        }

        public async Task<ICollection<Pet>> GetPetsWithoutOwner() 
        {
            return await _context.Pets.Where(pet => pet.Owner == null).Include(pet => pet.PetShelter).ToListAsync();
        }
        
        public async Task<ICollection<Pet>> GetShelterPetsWithoutOwner(string address)
        {
            return await _context.Pets.Where(pet => pet.Owner == null && pet.PetShelter.Address == address).ToListAsync();
        }

        public async Task<ICollection<Pet>> GetPetsWithBreed(string breed)
        {
            return await _context.Pets.Where(pet => pet.Breed == breed).Include(pet => pet.PetShelter).Include(pet => pet.Owner).ToListAsync();
        }

        public async Task<ICollection<PetDTO>> GetPetsWithKind(string kindOfAnimal)
        {
            return await _context.Pets.Where(pet => pet.KindOfAnimal == kindOfAnimal).Include(pet => pet.PetShelter).Include(pet => pet.Owner)
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
        }
    }
}
