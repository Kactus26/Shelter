using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<PetDTO>> PetsInShelter(string addres)
        {
            ICollection<PetDTO> pet = await _context.Pets.Include(pet => pet.Owner).Where(x => x.PetShelter.Addres == addres)
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
                OwnerAddres = x.Owner.Addres,
                PetShelterId = x.PetShelter.Id,
                PetShelterAddres = x.PetShelter.Addres
            }).ToListAsync();

            return pet;
        }
    }
}
