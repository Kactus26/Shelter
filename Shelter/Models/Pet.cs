namespace Shelter.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public DateOnly? DateOfTaking { get; set; }
        public Owner? Owner { get; set; }
        public PetShelter? PetShelter { get; set; }
    }
}
