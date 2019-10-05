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

        public Barcode[] getMatch(params string[] keyWords) {
            FoodEntities.Barcodes.SqlQuery(matchquery(keyWords));
            return null;|
        }


        private string matchquery(params string[] keyWords)
        {

            string temp = "select * from Barcode where";
            foreach (string word in keyWords)
            {
                temp += "ProductName like '%" + word + "%' ";
            }

            return temp;
        }

    }
}
