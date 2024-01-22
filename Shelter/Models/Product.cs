﻿namespace Shelter.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public ICollection<PetShelter> PetShelters { get; set;}
    }
}
