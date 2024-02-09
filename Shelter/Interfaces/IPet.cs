using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.DTO;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPet
    {
        Task<ICollection<Pet>> GetPetsWithoutOwner();
        Task<ICollection<Pet>> GetShelterPetsWithoutOwner(int shelterId);
        Task<ICollection<Pet>> GetPetsWithBreed(string breed);
        Task<ICollection<PetDTO>> GetPetsWithKind(string kindOfAnimal);
        Task<PetShelter> GetShelterById(int shelterId);
        Task<int> UpdatePetName(int petId, string newName);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        Task<ICollection<PetDTO>> GetAllPets();
        Task<bool> ShelterExists(int shelterId);
        Task SaveChanges();
    }
}
