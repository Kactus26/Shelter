using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IOwner
    {
        Task SaveChanges();
        Task<Pet> GetPetByName(string petName);
        Task<ICollection<Owner>> GetOwners();
        Task<bool> PetHasOwner(string petName);
        Task<Owner> GetOwner(string name);
        Task<Pet> GetPet(string name);
        ValueTask<EntityEntry<Owner>> AddOwner(Owner owner);
    }
}
