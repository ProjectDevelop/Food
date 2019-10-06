using FoodProject.DAL;
using FoodProject.DAL.Repositories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.lib.core
{
    class BrowserAndDatabase
    {

        protected ChromeDriver browser;
        protected IJavaScriptExecutor js;
        
        private ProductRepository productRepository;
        private PriceRepository priceRepository;

        public BrowserAndDatabase(ChromeDriver browser, IJavaScriptExecutor js)
        {

            productRepository = new ProductRepository();
            priceRepository = new PriceRepository();

            this.browser = browser;
            this.js = js;

        }


        /*Database */
        protected Product addProduct(Product product) {

            Product temp = productRepository.Add(product);
            return temp;

        }
        protected Product addProduct(int MarketId,string Name,string ImageUrl,int CategoryId,bool Status) {

            Product product = new Product();     
            product.MarketId = MarketId;
            product.Name = Name;
            product.ImageUrl = ImageUrl;
            product.CategoryId = CategoryId;
            product.Status = Status;
            Product temp = productRepository.Add(product);
            return temp;

        }

        protected ProductPrice addPrice(ProductPrice productPrice) {

            ProductPrice temp = priceRepository.Add(productPrice);
            return temp;

        }
        protected ProductPrice addPrice(int ProductId, string Price,string Currency) {

            ProductPrice productPrice = new ProductPrice();
            productPrice.ProductId = ProductId;
            productPrice.Price = Price;
            productPrice.Currency = Currency;
            ProductPrice temp = priceRepository.Add(productPrice);
            return temp;

        }
        /////////////////////////////////////////////////

        /* Help Function */
        protected void delay(int second)
        {
            System.Threading.Thread.Sleep(second * 1000);
        }

    }
}
