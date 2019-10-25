using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.DAL.Repositories
{
   public class ProductRepository
    {
        FoodEntities FoodEntities;
        public ProductRepository()
        {
            FoodEntities = new FoodEntities();
        }

        public Product Add(Product product)
        {
            FoodEntities.Products.Add(product);
            FoodEntities.SaveChanges();
            return product;
        }

        public Product getMatch(string Barcode)
        {
            Product temp = FoodEntities.Products.SqlQuery("Select * from Product where Barcode='" + Barcode+"'").FirstOrDefault();
            return temp;

        }

    }
}
