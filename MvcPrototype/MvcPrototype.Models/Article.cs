using System.Collections.Generic;
using System.Drawing;

namespace MvcPrototype.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Image> Pictures { get; set; }
    }
}
