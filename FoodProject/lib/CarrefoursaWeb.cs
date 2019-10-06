using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodProject.DAL;
using FoodProject.DAL.Repositories;
using FoodProject.lib.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FoodProject.lib
{
    class CarrefoursaWeb : BrowserAndDatabase
    {

        BarcodeRepository bar;

        private string[] links = {
            "https://www.carrefoursa.com/tr/peynir/c/1318?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/meyve-sebze/c/1014?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/et-balik-kumes/c/1044?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/sut-kahvaltilik/c/1310?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/gida-sekerleme/c/1110?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/icecekler/c/1409?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/bebek-dunyasi/c/1846?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/temizlik-urunleri/c/1556?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/kagit-kozmetik/c/1674?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/elektronik/c/2286?q=%3Arelevance&show=All",
            "https://www.carrefoursa.com/tr/ev-yasam-eglence/c/2188?q=%3Arelevance&show=All"
        };

        public CarrefoursaWeb(ChromeDriver browser, IJavaScriptExecutor js) : base(browser, js)
        {

            bar = new BarcodeRepository();
        }

        public void price()
        {
            InfoFormPrice.CurrentProgressBar = 0;
            InfoFormPrice.MaxProgressBar = links.Count();

            foreach (string link in links)
            {

                browser.Navigate().GoToUrl(link);


                IWebElement[] boxs = browser.FindElementByClassName("product-listing").FindElements(By.TagName("li")).ToArray();

                foreach (IWebElement box in boxs)
                {
                    try
                    {
                        string quantity = "", name = "", priceTag = "", image = "", category = "";
                        if (box.Text == "") continue;
                        name = box.FindElement(By.ClassName("item-name")).Text;
                        priceTag = box.FindElement(By.ClassName("item-price")).Text;
                        if (box.FindElements(By.ClassName("productUnit")).Count != 0)
                            quantity = box.FindElement(By.ClassName("productUnit")).Text;
                        image = box.FindElement(By.TagName("img")).GetAttribute("src");
                        category = box.FindElement(By.XPath("//ol[@class='breadcrumb']/li[@class='active']")).Text;
                        InfoFormPrice.CurrentTitle = name + "--" + priceTag + "--" + quantity + "--" + category;

                        Barcode tem = bar.getMatch(name.Split(' '));

                    }
                    catch(Exception ex)
                    {
                        continue;
                    }

                }
                InfoFormPrice.CurrentProgressBar++;
            }

        }

    }
}