using Microsoft.EntityFrameworkCore;
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
        public async Task SeedDataContext()
        {
            var pendingMigrations = await dataContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await dataContext.Database.MigrateAsync();
            }

            if (dataContext.PetShelters.Any())
            {
                return;
            }

            
            Owner twoPetsOwner = new Owner { Name = "Yurik", SurName = "Bury", Address = "9 Willow Avenue" };
            Product twoSheltersProducts = new Product { Name = "Cat house", Description = "Big fun house for your little friend", Manufacturer = "HousesCompany", Value = 125.99F };

            var PetShelters = new List<PetShelter>()
            {
                new PetShelter()
                {
                    Address = "ul. Berserka 35",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Aki", Age = 2, Gender = 'M', KindOfAnimal = "Dog", Breed = "Haski"},
                        new Pet { Name = "Miku", Age = 1, Gender = 'F', KindOfAnimal = "Cat", Breed = "British", DateOfTaking = new DateOnly(2024,01,01),
                            Owner = new Owner{ Name = "Alex", SurName = "Baginsky", Address = "13 Maple Street"}},
                        new Pet { Name = "Pirozok", Age = 0, Gender = 'M', KindOfAnimal = "Hamster", Breed = "Jungaryk", DateOfTaking = new DateOnly(2023,03,28),
                            Owner = new Owner{ Name = "Yaroslav", SurName = "Yanovich", Address = "21 Pine Road"}}
                    },
                    Products = new List<Product>()
                    {
                        new Product { Name = "Cat food", Description = "Delicious dainty for kittys", Manufacturer = "Food & co", Value = 2.59F},
                        twoSheltersProducts
                    }
                },
                new PetShelter()
                {
                    Address = "ul. Mrkanova 2",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Bella", Age = 3, Gender = 'F', KindOfAnimal = "Dog", Breed = "Labrador"},
                        new Pet { Name = "Whiskers", Age = 2, Gender = 'M', KindOfAnimal = "Cat", Breed = "Siamese",
                            DateOfTaking = new DateOnly(2023,10,15), Owner = twoPetsOwner},
                        new Pet { Name = "Nibbles", Age = 1, Gender = 'M', KindOfAnimal = "Hamster", Breed = "Syrian",
                            DateOfTaking = new DateOnly(2023,10,15), Owner = twoPetsOwner}
                    },
                    Products = new List<Product>()
                    {
                        new Product { Name = "Dog food", Description = "Delicious dainty for puppies", Manufacturer = "Food & co", Value = 1.99F},
                        twoSheltersProducts
                    }
                }
            };
            dataContext.PetShelters.AddRange(PetShelters);
            dataContext.SaveChanges();
        }
    }
}
