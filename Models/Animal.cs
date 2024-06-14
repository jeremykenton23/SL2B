namespace ZooApplicationV2.Models
{
    using System.Collections.Generic;

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public Category Category { get; set; }
        public Size Size { get; set; }
        public DietaryClass DietaryClass { get; set; }
        public ActivityPattern ActivityPattern { get; set; }
        public List<Animal> Prey { get; set; }
        public Enclosure Enclosure { get; set; }
        public double SpaceRequirement { get; set; }
        public SecurityLevel SecurityRequirement { get; set; }
    }

    public enum Size { Microscopic, VerySmall, Small, Medium, Large, VeryLarge }
    public enum DietaryClass { Carnivore, Herbivore, Omnivore, Insectivore, Piscivore }
    public enum ActivityPattern { Diurnal, Nocturnal, Cathemeral }
    public enum SecurityLevel { Low, Medium, High }
}

