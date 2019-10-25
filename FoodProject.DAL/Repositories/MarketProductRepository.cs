using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.DAL.Repositories
{
   public class MarketProductRepository
    {
        FoodEntities FoodEntities;
        public MarketProductRepository()
        {
            FoodEntities = new FoodEntities();
        }

        public MarketProduct Add(MarketProduct marketProduct)
        {
            FoodEntities.MarketProducts.Add(marketProduct);
            FoodEntities.SaveChanges();
            return marketProduct;
        }

        public MarketProduct getMatch(int marketId,int productId)
        {
            MarketProduct temp = FoodEntities.MarketProducts.SqlQuery("Select * from MarketProduct where ProductId="+productId.ToString()+ " and MarketId="+ marketId.ToString()).FirstOrDefault();
            return temp;

        }

    }
}
