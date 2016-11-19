using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Dominos
{
    public class Products
    {
        public static List<Product> GetProducts(string json)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);
            dynamic prods = jsonObject["Products"];

            List<Product> listOfProducts = new List<Product>();
            foreach (var p in prods)
            {
                Product pr = new Product();
                pr.Name = p["Name"];
                pr.Image = p["Image"];
                pr.Description = p["Description"];
                pr.HalfnHalfEnabled = p["HalfnHalfEnabled"];
                //pr.Price = p["Price"];
                pr.Status = p["Status"];
                //pr.Legends = p["Legends"];
                //pr.LinkedItem = p["LinkedItem"];
                pr.ComponentStatus = p["ComponentStatus"];
                listOfProducts.Add(pr);
            }
            return listOfProducts;

        }
/*
        public class Products : IEnumerable
        {
            private Products[] _products;
            public Products(Products[] aArray)
            {
                _products = new Products[aArray.Length];

                for (int i = 0; i < aArray.Length; i++)
                {
                    _products[i] = aArray[i];
                }
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public ProductsEnum GetEnumerator()
            {
                return new ProductsEnum(_products);
            }
        }



        // When you implement IEnumerable, you must also implement   IEnumerator. 
        public class ProductsEnum : IEnumerator
        {
            public Products[] _products;

            // Enumerators are positioned before the first element 
            // until the first MoveNext() call. 
            int position = -1;

            public ProductsEnum(Products[] list)
            {
                _products = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _products.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Products Current
            {
                get
                {
                    try
                    {
                        return _products[position];
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        throw new System.InvalidOperationException();
                    }
                }
            }
        }

        */
    }

}
