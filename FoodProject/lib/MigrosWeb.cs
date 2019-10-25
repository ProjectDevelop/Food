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
    class MigrosWeb : BrowserAndDatabase
    {

        private string[] links = {
            "https://www.migros.com.tr/meyve-c-65",
            "https://www.migros.com.tr/sebze-c-66",
            "https://www.migros.com.tr/kirmizi-et-c-68",
            "https://www.migros.com.tr/kumes-hayvanlari-c-69",
            "https://www.migros.com.tr/balik-deniz-urunleri-c-6a",
            "https://www.migros.com.tr/et-sarkuteri-c-6b",
            "https://www.migros.com.tr/sut-c-6c",
            "https://www.migros.com.tr/peynir-c-6d",
            "https://www.migros.com.tr/yogurt-c-6e",
            "https://www.migros.com.tr/tereyag-margarin-c-6f",
            "https://www.migros.com.tr/yumurta-c-70",
            "https://www.migros.com.tr/zeytin-c-71",
            "https://www.migros.com.tr/dondurma-c-41b",
            "https://www.migros.com.tr/sutlu-tatli-krema-c-72",
            "https://www.migros.com.tr/kahvaltiliklar-c-73",
            "https://www.migros.com.tr/bakliyat-makarna-c-74",
            "https://www.migros.com.tr/sivi-yaglar-c-76",
            "https://www.migros.com.tr/tuz-baharat-harc-c-77",
            "https://www.migros.com.tr/corba-ve-bulyonlar-c-75",
            "https://www.migros.com.tr/cikolata-gofret-c-78",
            "https://www.migros.com.tr/biskuvi-cerez-c-79",
            "https://www.migros.com.tr/sakiz-sekerleme-c-7a",
            "https://www.migros.com.tr/seker-c-ac",
            "https://www.migros.com.tr/sekersiz-tatlandiricili-urunler-c-7b",
            "https://www.migros.com.tr/dondurulmus-gida-c-7c",
            "https://www.migros.com.tr/hazir-yemek-konserve-salca-c-7d",
            "https://www.migros.com.tr/meze-c-44e",
            "https://www.migros.com.tr/unlu-mamul-tatli-c-7e",
            "https://www.migros.com.tr/saglikli-yasam-urunleri-c-7f",
            "https://www.migros.com.tr/gazli-icecekler-c-80",
            "https://www.migros.com.tr/gazsiz-icecekler-c-81",
            "https://www.migros.com.tr/cay-kahve-c-82",
            "https://www.migros.com.tr/gunluk-icecek-c-83",
            "https://www.migros.com.tr/sular-c-84",
            "https://www.migros.com.tr/maden-sulari-c-85",
            "https://www.migros.com.tr/camasir-yikama-c-86",
            "https://www.migros.com.tr/bulasik-yikama-c-87",
            "https://www.migros.com.tr/ev-temizlik-urunleri-c-88",
            "https://www.migros.com.tr/ev-temizlik-gerecleri-c-89",
            "https://www.migros.com.tr/banyo-gerecleri-c-8b",
            "https://www.migros.com.tr/camasir-gerecleri-c-8a",
            "https://www.migros.com.tr/kagit-urunleri-c-8d",
            "https://www.migros.com.tr/hijyenik-pedler-c-96",
            "https://www.migros.com.tr/agiz-bakim-urunleri-c-8e",
            "https://www.migros.com.tr/sac-bakim-c-8f",
            "https://www.migros.com.tr/dus-banyo-sabun-c-92",
            "https://www.migros.com.tr/tiras-malzemeleri-c-90",
            "https://www.migros.com.tr/agdalar-tuy-dokuculer-c-91",
            "https://www.migros.com.tr/vucut-cilt-bakim-c-93",
            "https://www.migros.com.tr/parfum-deodorant-c-97",
            "https://www.migros.com.tr/gunes-bakim-c-94",
            "https://www.migros.com.tr/makyaj-ve-sus-urunleri-c-95",
            "https://www.migros.com.tr/saglik-urunleri-c-98",
            "https://www.migros.com.tr/bebek-urunleri-c-9b",
            "https://www.migros.com.tr/bebek-bezi-c-ab",
            "https://www.migros.com.tr/anne-urunleri-c-9a",
            "https://www.migros.com.tr/oyuncaklar-c-9e",
            "https://www.migros.com.tr/mutfak-esya-gerecleri-c-9f",
            "https://www.migros.com.tr/kisisel-ilgi-eglence-c-a1",
            "https://www.migros.com.tr/ev-ofis-bahce-dekorasyon-c-a4",
            "https://www.migros.com.tr/kitap-dergi-kirtasiye-c-a5",
            "https://www.migros.com.tr/tekstil-giyim-aksesuar-c-a3",
            "https://www.migros.com.tr/pet-urunleri-c-a0",
            "https://www.migros.com.tr/elektrik-elektronik-c-a6",
            "https://www.migros.com.tr/altin-c-1118a"
        };

        public MigrosWeb(ChromeDriver browser, IJavaScriptExecutor js) : base(browser, js)
        {

        }


        public void price()
        {
            InfoFormPrice.CurrentProgressBar = 0;
            InfoFormPrice.MaxProgressBar = links.Count();

            foreach (string link in links)
            {

                browserFirst.Navigate().GoToUrl(link);

                while (true)
                {

                    IWebElement[] boxs = browserFirst.FindElementsByClassName("list").ToArray();

                    foreach (IWebElement box in boxs)
                    {
                        try
                        {
                            string quantity = "", name = "", priceTag = "", image = "", category = "";
                            if (box.Text == "") continue;
                            name = box.FindElement(By.TagName("h5")).Text;
                            priceTag = box.FindElement(By.ClassName("price-tag")).Text;
                            quantity = box.FindElement(By.ClassName("select")).FindElement(By.TagName("label")).Text;
                            image = box.FindElement(By.TagName("img")).GetAttribute("src");
                            category = box.FindElements(By.XPath("//ul[@class='breadcrumb']/li"))[1].Text;
                            InfoFormPrice.CurrentTitle = name + "--" + priceTag + "--" + quantity + "--" + category;

                            TempProduct pro = addTempProduct(name, image, 1, "", true);

                        }
                        catch
                        {
                            continue;
                        }

                    }
                    if (browserFirst.FindElementsByClassName("pag-next").Count != 0)
                        browserFirst.FindElementByClassName("pag-next").Click();
                    else break;
                    delay(2);
                }
                InfoFormPrice.CurrentProgressBar++;
            }
        }


    }
}