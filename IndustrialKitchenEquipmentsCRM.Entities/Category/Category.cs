using IndustrialKitchenEquipmentsCRM.Entities.Interface;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.Entities.Category
{
    public class Category:BaseEntity
    {
        
        public Category()
        {
            Stocks = new List<Entities.Stock.Stock>();
        }
        public string CategoryName { get; set; }
        public List<Stock.Stock>? Stocks { get; set; }
    }
}
