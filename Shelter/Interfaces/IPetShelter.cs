using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.DTO;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters();
        Task<PetShelter> GetShelterByAddress(string address);
        Task<ICollection<PetDTO>> PetsInShelter(string address);
        Task<ICollection<Product>> ProductsInShelter(string address);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        Task<bool> ShelterExists(string address);
        Task SaveChanges();
    }
}
