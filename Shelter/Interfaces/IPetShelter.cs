using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.DTO;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters();
        Task<PetShelter> GetShelterById(int shelterId);
        Task<ICollection<PetDTO>> PetsInShelter(int shelterId);
        Task<ICollection<Product>> ProductsInShelter(int shelterId);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        ValueTask<EntityEntry<PetShelter>> AddPetShelter(PetShelter pet);
        Task<Pet> GetPetById(int petId);
        Task<bool> ShelterExists(int shelterId);
        Task SaveChanges();
    }
}
