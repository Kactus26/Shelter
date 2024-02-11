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
        Task<EntityEntry<Pet>> DeletePet(int petId);
        Task<PetShelter> GetShelterById(int shelterId);
        Task<int> UpdatePetName(int petId, string newName);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        Task<ICollection<PetDTO>> GetAllPets();
        Task<bool> PetExists(int petId);
        Task<bool> ShelterExists(int shelterId);
        Task SaveChanges();
    }
}
