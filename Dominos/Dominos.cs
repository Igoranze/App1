using System;
using System.Collections.Generic;

namespace Dominos
{
    public class PizzaApp
    {

        public object SubMenuProdcts { get; set; }
        

        public class MenuPages
        {
            public class SubMenus
            {
                public List<Product> Products { get; set; }
            }
        }
        public void Initialize()
        {
            //Products = GetProducts();
        }

        private List<Product> GetProducts()
        {
            //string json = JsonConvert.SerializeObject(product);
            throw new NotImplementedException();
        }
    }
} 

