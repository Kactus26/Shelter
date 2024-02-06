using Microsoft.AspNetCore.Mvc;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerConrtoller : Controller
    {
        private readonly IOwner _ownerRepository;
        public OwnerConrtoller(IOwner ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet("GetAllOwners")]
        public async Task<IActionResult> GetAllOwners()
        {
            ICollection<Owner> owners = await _ownerRepository.GetOwners();
            return Ok(owners);
        }

        [HttpPost("AddOwner")]
        public async Task<IActionResult> AddOwner(string name, string surname, string address, string petName)
        {
            if (await _ownerRepository.PetHasOwner(petName))
                return BadRequest("Pet is alrety taken");

            Pet pet = await _ownerRepository.GetPetByName(petName);
            pet.DateOfTaking = DateOnly.FromDateTime(DateTime.Now);

            Owner owner = new Owner
            {
                Name = name,
                SurName = surname,
                Address = address,
                Pets = new List<Pet> { pet }
            };

            await _ownerRepository.AddOwner(owner);
            await _ownerRepository.SaveChanges();
            return Ok(owner);
        }

        [HttpPost("AddPetToOwner")]
        public async Task<IActionResult> AddPetToOwner(string ownerName, string petName) 
        {
            Owner owner = await _ownerRepository.GetOwner(ownerName);
            Pet pet = await _ownerRepository.GetPet(petName);

            if (owner == null || pet == null || pet.Owner != null)
                return BadRequest("Owner or pet with this name don't exist");

            owner.Pets.Add(pet);

            await _ownerRepository.SaveChanges();
            return Ok("Data added successfully");
        }

    }
}
