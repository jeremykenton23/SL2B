namespace ZooApplicationV2.Data
{
    using Bogus;
    using System.Linq;
    using ZooApplicationV2.Models;

    public static class DbInitializer
    {
        public static void Initialize(ZooContext context)
        {
            context.Database.EnsureCreated();

            if (context.Animals.Any())
            {
                return; // DB has been seeded
            }

            var faker = new Faker("en");

            var categories = new List<Category>
        {
            new Category { Name = "Mammals" },
            new Category { Name = "Birds" },
            new Category { Name = "Reptiles" }
        };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var animals = new List<Animal>
        {
            new Animal
            {
                Name = "Lion",
                Species = "Panthera leo",
                Category = categories[0],
                Size = Size.Large,
                DietaryClass = DietaryClass.Carnivore,
                ActivityPattern = ActivityPattern.Diurnal,
                SpaceRequirement = 400,
                SecurityRequirement = SecurityLevel.High
            },
            new Animal
            {
                Name = "Eagle",
                Species = "Aquila chrysaetos",
                Category = categories[1],
                Size = Size.Medium,
                DietaryClass = DietaryClass.Carnivore,
                ActivityPattern = ActivityPattern.Diurnal,
                SpaceRequirement = 50,
                SecurityRequirement = SecurityLevel.Medium
            }
        };
            context.Animals.AddRange(animals);
            context.SaveChanges();
        }
    }

}
