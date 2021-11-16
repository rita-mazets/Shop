using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Protein { get; set; }
        public float Price { get; set; }
        public float Fat { get; set; }
        public float Carbohydrate { get; set; }
        public string Image { get; set; }
        public int Calories { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
