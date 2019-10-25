﻿using FoodProject.DAL;
using FoodProject.DAL.Repositories;
using FoodProject.lib.core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.lib
{
    class Oruc : BrowserAndDatabase
    {

        private const int MarketId = 6;

        private string[] Links = {

            "https://www.marul.com/tr/kategori/meyve-ve-sebze-online-siparis-vermek/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/organik-urunler-2/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/sut-urunleri-ve-kahvaltiliklar/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/gida-sekerleme/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/unlu-mamul-tatli/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/et-tavuk-balik-ve-sarkuteri/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/Icecekler/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/atistirmalik/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/dondurulmus-gida/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/bebek-anne-ve-oyuncak/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/temizlik-urunleri/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/saglik-ve-guzellik/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/ev-ve-pet-urunleri/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh",
            "https://www.marul.com/tr/kategori/evcil-hayvan-mamalari/oruc-market-atasehir/318/4888/istanbul-anadolu/atasehir-barbaros-mh"

        };

        List<string> categories;


        public Oruc(ChromeDriver browserF, IJavaScriptExecutor jsF, ChromeDriver browserS, IJavaScriptExecutor jsS) : base(browserF, jsF, browserS, jsS)
        {

            categories = new List<string>();

            categories.Add("Meyve & Sebze");
            categories.Add("Süt & Kahvaltılık");
            categories.Add("Gıda Genel");
            categories.Add("Unlu Mamül & Pasta Malzemeleri");
            categories.Add("Et & Balık");
            categories.Add("İçecek");
            categories.Add("Atıştırmalık");
            categories.Add("Dondurulmuş Gıda");
            categories.Add("Bebek & Anne");
            categories.Add("Temizlik Ürünü");
            categories.Add("Kişisel Bakım");
            categories.Add("Ev Gereçleri");
            categories.Add("Evcil Hayvan Ürünleri");
            categories.Add("Glutensiz Ürünler");
            categories.Add("Diğer");
            categories.Add("Organik Ürünler");
            categories.Add("Gazete & Dergi");

        }

        public void products()
        {
            InfoFormPrice.CurrentProgressBar = 0;
            InfoFormPrice.MaxProgressBar = Links.Count();
            
            foreach (string link in Links)

            {

                browserFirst.Navigate().GoToUrl(link);

                while (true)
                {
                    IWebElement[] boxs = browserFirst.FindElementsByClassName("item-box").ToArray();
                    string category = browserFirst.FindElement(By.XPath("/html/body/div[6]/div[5]/div/div[1]/div/div[2]/ul/li[2]")).Text;
                    foreach (IWebElement box in boxs)
                    {
                        try
                        {
                            string name = "", url = "", image = "", barcode = "", price = "";
                            name = box.FindElement(By.TagName("h2")).Text;
                            image = box.FindElement(By.TagName("img")).GetAttribute("src");
                            int catId = categories.IndexOf(category.Trim()) + 1;
                            url = box.FindElement(By.TagName("a")).GetAttribute("href");
                            barcode = BrowserSecond(url);
                            price = box.FindElement(By.ClassName("actual-price")).Text;
                            InfoFormPrice.CurrentTitle = name + "  --  " + barcode + "  --  " + category;

                            Product product = addProduct(name, image, catId, barcode, true);
                            MarketProduct marketproduct = addMarketProduct(MarketId, product.Id, url);
                            ProductPrice productPrice = addPrice(product.Id, price, "TL", DateTime.Now);

                        }
                        catch(Exception ex)
                        {
                            continue;
                        }

                    }
                    if (browserFirst.FindElementsByClassName("next-page").Count != 0)
                        browserFirst.FindElementByClassName("next-page").Click();
                    else break;
                    delay(2);
                }
                InfoFormPrice.CurrentProgressBar++;
            }
            

        }

        private string BrowserSecond(string link)
        {
            string temp = "";
            browserSecond.Navigate().GoToUrl(link);

            for (int i = 1; i < 6; i++)
            {
                IWebElement[] barkod = browserSecond.FindElements(By.XPath("//*[@id=\"product-details-form\"]/div/div/div[2]/div[" + i.ToString() + "]/div/span[@class=\"value\"]")).ToArray();

                if (barkod.Count() != 0)
                {
                    temp = barkod[0].Text;
                    if (temp != "") break;
                }
            }

            return temp;
        }

    }
}