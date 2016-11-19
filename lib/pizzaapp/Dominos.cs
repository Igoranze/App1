using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Dominos
// Dominos.PizzaApp
// Dominos.PizzaApp.MenuPages
// Dominos.PizzaApp.MenuPages.SubMenus
// Dominos.PizzaApp.MenuPages.SubMenus.Products

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

