using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStoreWebApp.Models;
using EStoreWebApp.Repositories;

namespace EStoreWebApp.Services
{
    public class ProductService
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Title = "Shivam", Quantity = 100, UnitPrice = 1200 });
            products.Add(new Product { Id = 2, Title = "Chirag", Quantity = 120, UnitPrice = 1000 });
            products.Add(new Product { Id = 1, Title = "Manisha", Quantity = 150, UnitPrice = 200 });
            products.Add(new Product { Id = 1, Title = "shailesh", Quantity = 170, UnitPrice = 10 });
            ProductRepository mgr = new ProductRepository();
            // string fileName = "Products";
            // mgr.Serialize(products, "Products");
            Console.WriteLine("done...!##############################");
            mgr.Serialize(products, "filename");
            // products = mgr.DeSerialize(fileName);
            return products;
        }
        public void AddProduct(Product p)
        {

        }
    }
}