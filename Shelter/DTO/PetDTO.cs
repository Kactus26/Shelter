using Shelter.Models;

namespace Shelter.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public DateOnly? DateOfTaking { get; set; }
        public int? OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerSurName { get; set; }
        public string? OwnerAddres { get; set; }
        public int PetShelterId { get; set; }
        public string PetShelterAddres { get; set; }
    }
}
