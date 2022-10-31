using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardItemCreateDto : ICreateDto
    {
       
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int? StockId { get; set; }
        public int CardId { get; set; }


    }
}
