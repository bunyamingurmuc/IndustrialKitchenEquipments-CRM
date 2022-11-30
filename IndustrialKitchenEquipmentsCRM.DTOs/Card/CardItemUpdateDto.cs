using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardItemUpdateDto: IUpdateDto
    {
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public int? StockId { get; set; }
        public int? CardId { get; set; }
    }
}
