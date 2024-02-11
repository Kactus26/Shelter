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
        public async Task<IActionResult> AddOwner(string name, string surname, string address, int petId)
        {
            if (await _ownerRepository.PetHasOwner(petId))
                return BadRequest("Pet is alrety taken");

            Pet pet = await _ownerRepository.GetPetById(petId);
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
        public async Task<IActionResult> AddPetToOwner(int ownerId, int petId) 
        {
            Owner owner = await _ownerRepository.GetOwnerById(ownerId);
            Pet pet = await _ownerRepository.GetPet(petId);

            if (owner == null || pet == null || pet.Owner != null)
                return BadRequest("Owner or pet with this id doesn't exist");

            owner.Pets.Add(pet);

            await _ownerRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPut("UpdateOwnerAddress")]
        public async Task<IActionResult> UpdateOwnerAddress(int ownerId, string newAddress)
        {
            Owner owner = await _ownerRepository.GetOwnerById(ownerId);
            if (owner==null)
                return BadRequest("Owner with such id doesn't exist");

            owner.Address = newAddress;
            await _ownerRepository.SaveChanges();
            return Ok("Data changed successfully");

        }
    }
}
