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
    }
}
