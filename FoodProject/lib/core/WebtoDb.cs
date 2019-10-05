using FoodProject.DAL;
using FoodProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.lib.core
{
    class WebtoDb
    {

        ProductRepository productRepository;
        PriceRepository priceRepository;

        public WebtoDb()
        {
            productRepository = new ProductRepository();
            priceRepository = new PriceRepository();
        }

        protected Product addProduct(Product product) { return null; }
        protected Product addProduct(int MarketId,string Name,string ImageUrl,int CategoryId,bool Status) { return null; }

        protected ProductPrice addPrice(ProductPrice productPrice) { return null;}
        protected ProductPrice addPrice(int ProductId, string Price,string Currency) { return null;}


    }
}
