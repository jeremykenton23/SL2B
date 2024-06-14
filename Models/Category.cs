namespace ZooApplicationV2.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }

}
