using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.DAL.Repositories
{
    public class PriceRepository
    {
        FoodEntities FoodEntities;
        public PriceRepository()
        {
            FoodEntities = new FoodEntities();
        }

        public ProductPrice Add(ProductPrice price)
        {
            FoodEntities.ProductPrices.Add(price);
            FoodEntities.SaveChanges();
            return price;
        }

    }
}
