using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject.DAL.Repositories
{
    public class BarcodeRepository
    {
        FoodEntities FoodEntities;
        public BarcodeRepository()
        {
            FoodEntities = new FoodEntities();
        }

        public Barcode Add(Barcode barcode)
        {
            FoodEntities.Barcodes.Add(barcode);
            FoodEntities.SaveChanges();
            return barcode;
        }

        public Barcode getMatch(params string[] keyWords) {

            Barcode temp = FoodEntities.Barcodes.SqlQuery(matchquery(keyWords)).FirstOrDefault<Barcode>();
            return temp;

        }


        private string matchquery(params string[] keyWords)
        {

            string temp = "select * from Barcode where";
            foreach (string word in keyWords)
            {
                
                temp += "ProductName like '%" + word + "%' and ";
            }
            temp = temp.Substring(0, temp.Length - 4);
            return temp;
        }

    }
}
