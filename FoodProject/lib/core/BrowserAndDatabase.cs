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

       protected IJavaScriptExecutor jsFirst;
        protected IJavaScriptExecutor jsSecond;
        protected ChromeDriver browserFirst;
        protected ChromeDriver browserSecond;
        
        private ProductRepository productRepository;
        private PriceRepository priceRepository;
        private MarketProductRepository marketProductRepository;

        private TempProductRepository tempProductRepository;
        public BrowserAndDatabase(ChromeDriver browser, IJavaScriptExecutor js)
        {

            productRepository = new ProductRepository();
            priceRepository = new PriceRepository();
            marketProductRepository = new MarketProductRepository();

            tempProductRepository = new TempProductRepository();

            this.browserFirst = browser;
            this.jsFirst = js;
            
        }

        public BrowserAndDatabase(ChromeDriver browserF, IJavaScriptExecutor jsF, ChromeDriver browserS, IJavaScriptExecutor jsS)
        {

            productRepository = new ProductRepository();
            priceRepository = new PriceRepository();
            marketProductRepository = new MarketProductRepository();

            tempProductRepository = new TempProductRepository();

            this.browserFirst = browserF;
            this.jsFirst = jsF;

            this.browserSecond = browserS;
            this.jsSecond = jsS;

        }


        /*Database */
        protected Product addProduct(string Name,string ImageUrl,int CategoryId,string Barcode,bool Status) {

            Product product = new Product();  
            product.Name = Name;
            product.ImageUrl = ImageUrl;
            product.CategoryId = CategoryId;
            product.Barcode = Barcode;
            product.Status = Status;
            Product returnProduct = productRepository.getMatch(Barcode);
            if (returnProduct == null)
            {
                Product temp = productRepository.Add(product);
                return temp;
            }
            return returnProduct;

        }

        protected TempProduct addTempProduct(string Name, string ImageUrl, int CategoryId, string Barcode, bool Status)
        {
            TempProduct product = new TempProduct();
            product.Name = Name;
            product.ImageUrl = ImageUrl;
            product.CategoryId = CategoryId;
            product.Barcode = Barcode;
            product.Status = Status;

            TempProduct returnProduct = tempProductRepository.getMatch(Barcode);

            if (returnProduct == null)
            {
                TempProduct temp = tempProductRepository.Add(product);
                return temp;
            }
            return returnProduct;
        }

        protected MarketProduct addMarketProduct(int MarketId,int ProductId, string URL)
        {

            MarketProduct marketProduct = new MarketProduct();
            marketProduct.MarketId = MarketId;
            marketProduct.ProductId = ProductId;
            marketProduct.Url = URL;
            MarketProduct returnMarketP = marketProductRepository.getMatch(MarketId, ProductId);
            if (returnMarketP == null)
            {
                MarketProduct temp = marketProductRepository.Add(marketProduct);
                return temp;
            }
            return returnMarketP;

        }

        protected ProductPrice addPrice(int MarketProductId, string Price,string Currency,DateTime date) {

            ProductPrice productPrice = new ProductPrice();
            productPrice.marketProcutId = MarketProductId;
            productPrice.Price = Price;
            productPrice.Currency = Currency;
            productPrice.Date = date;
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
