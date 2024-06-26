﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shelter.DTO;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPet _petRepository;
        private readonly IMapper _mapper;
        public PetController(IPet pet, IMapper mapper)
        {
            _petRepository = pet;
            _mapper = mapper;
        }

        [HttpGet("GetAllPets")]
        public async Task<IActionResult> GetAllPets()
        {
            ICollection<PetDTO> pets = await _petRepository.GetAllPets();

            if (pets != null)
                return Ok(pets);
            else
                return NotFound("There are no pets");
        }


        [HttpGet("GetAllPetsWithoutOwner")]
        public async Task<IActionResult> GetAllPetsWithoutOwner()
        {
            ICollection<PetWhithPetShelterDTO> pets = _mapper.Map<ICollection<PetWhithPetShelterDTO>>(await _petRepository.GetPetsWithoutOwner());

            if (pets != null)
                return Ok(pets);
            else
                return NotFound("No pets without owners");
        }

        [HttpGet("GetPetsInShelterWithoutOwner")]
        public async Task<IActionResult> GetPetsInShelterWithoutOwner(int shelterId)
        {
            if (await _petRepository.ShelterExists(shelterId))
                return NotFound("Shelter with this id doesn't exist");

            ICollection<PetWhithPetShelterDTO> pets = _mapper.Map<ICollection<PetWhithPetShelterDTO>>(await _petRepository.GetShelterPetsWithoutOwner(shelterId));

            if (pets != null)
                return Ok(pets);
            else
                return NotFound("No pets in this shelter without owners");
        }

        [HttpGet("GetAllPetsByBreed")]
        public async Task<IActionResult> GetAllPetsByBreed(string breed)
        {
            ICollection<PetWhithOwnerAndShelterDTO> pets = _mapper.Map<ICollection<PetWhithOwnerAndShelterDTO>>(await _petRepository.GetPetsWithBreed(breed));

            if (pets.Count != 0)
                return Ok(pets);
            else
                return NotFound("No pets with such breed");
        }

        [HttpGet("GetAllPetsByKindOfAnimal")]
        public async Task<IActionResult> GetAllPetsByKindOfAnimal(string kindOfAnimal)
        {
            ICollection<PetDTO> pets = await _petRepository.GetPetsWithKind(kindOfAnimal);

            if (pets.Count != 0)
                return Ok(pets);
            else
                return NotFound("No pets of such kind");
        }

        [HttpPost("AddPet")]
        public async Task<IActionResult> AddPet(string name, int age, char gender, string kind, string breed, int shelterId)
        {
            if (await _petRepository.ShelterExists(shelterId))
                return BadRequest("Shelter with that id doesn't  exist");

            Pet pet = new Pet
            {
                Name = name,
                Age = age,
                Gender = gender,
                KindOfAnimal = kind,
                Breed = breed,
                PetShelter = await _petRepository.GetShelterById(shelterId)
            };

            await _petRepository.AddPet(pet);
            await _petRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPut("UpdatePetName")]
        public async Task<IActionResult> UpdatePetName(int petId, string newName)
        {
            int tablesChanged = await _petRepository.UpdatePetName(petId, newName);
            if (tablesChanged != 0)
                return Ok("Data updated successfully");
            else
                return NotFound("Pet not found");
        }

        [HttpDelete("DeletePet")]
        public async Task<IActionResult> DeletePet(int petId)
        {
            if (await _petRepository.PetExists(petId))
                return NotFound("Pet not found");

            await _petRepository.DeletePet(petId);
            await _petRepository.SaveChanges();
            return Ok("Data deleted successfully");
        }
    }
}
