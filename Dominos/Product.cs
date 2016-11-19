using System;
using System.Collections.Generic;

namespace Dominos
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string ComponentStatus { get; set; }
        public string LinkedItem { get; set; }
        public Array Legends { get; set; }
        public bool HalfnHalfEnabled { get; set; }

        public string PizzaData { get; set; }
    }
   
}