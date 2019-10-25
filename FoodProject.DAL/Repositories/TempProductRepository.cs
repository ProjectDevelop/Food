using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.DAL.Repositories
{
   public class TempProductRepository
    {
        FoodEntities FoodEntities;
        public TempProductRepository()
        {
            FoodEntities = new FoodEntities();
        }

        public TempProduct Add(TempProduct product)
        {
            FoodEntities.TempProducts.Add(product);
            FoodEntities.SaveChanges();
            return product;
        }

        public TempProduct getMatch(string Name)
        {
            TempProduct temp = FoodEntities.TempProducts.SqlQuery("Select * from Product where Name='" + Name + "'").FirstOrDefault();
            return temp;

        }

    }
}
