using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;

namespace IndustrialKitchenEquipmentsCRM.Entities.Image
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public int? StockId { get; set; }
        public Stock.Stock? Stock { get; set; }
    }
}
