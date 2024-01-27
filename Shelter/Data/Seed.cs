using Shelter.Models;
using System.Diagnostics.Metrics;

namespace Shelter.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (dataContext.PetShelters.Any())
            {
                dataContext.RemoveRange(dataContext.Owners);
                dataContext.RemoveRange(dataContext.Pets);
                dataContext.RemoveRange(dataContext.PetShelters);
                dataContext.SaveChanges();
            }

            if (!dataContext.PetShelters.Any())
            {
                Owner twoPetsOwner = new Owner { Name = "Yurik", SurName = "Bury", Addres = "9 Willow Avenue" };
                Product twoSheltersProducts = new Product { Name = "Cat house", Description = "Big fun house for your little friend", Value = 125.99F };

                var PetShelters = new List<PetShelter>()
                {
                    new PetShelter()
                    {
                        Addres = "ul. Berserka 35",
                        Pets = new List<Pet>
                        {
                            new Pet { Name = "Aki", Age = 2, Gender = 'M', KindOfAnimal = "Dog", Breed = "Haski"},
                            new Pet { Name = "Miku", Age = 1, Gender = 'F', KindOfAnimal = "Cat", Breed = "British",
                                Owner = new Owner{ Name = "Alex", SurName = "Baginsky", Addres = "13 Maple Street"}},
                            new Pet { Name = "Pirozok", Age = 0, Gender = 'M', KindOfAnimal = "Hamster", Breed = "Jungaryk",
                                Owner = new Owner{ Name = "Yaroslav", SurName = "Yanovich", Addres = "21 Pine Road"}}
                        },
                        Products = new List<Product>()
                        {
                            new Product { Name = "Cat food", Description = "Delicious dainty for kittys", Value = 2.59F},
                            twoSheltersProducts
                        }
                    },
                    new PetShelter()
                    {
                        Addres = "ul. Mrkanova 2",
                        Pets = new List<Pet>
                        {
                            new Pet { Name = "Bella", Age = 3, Gender = 'F', KindOfAnimal = "Dog", Breed = "Labrador"},
                            new Pet { Name = "Whiskers", Age = 2, Gender = 'M', KindOfAnimal = "Cat", Breed = "Siamese", Owner = twoPetsOwner},
                            new Pet { Name = "Nibbles", Age = 1, Gender = 'M', KindOfAnimal = "Hamster", Breed = "Syrian", Owner = twoPetsOwner}
                        },
                        Products = new List<Product>()
                        {
                            new Product { Name = "Dog food", Description = "Delicious dainty for puppies", Value = 1.99F},
                            twoSheltersProducts
                        }
                    }
                };
                dataContext.PetShelters.AddRange(PetShelters);
                dataContext.SaveChanges();
            }
        }
    }
}
