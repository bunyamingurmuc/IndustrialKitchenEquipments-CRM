using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardItemListDto : IListDto
    {
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int? StockId { get; set; }
        public int CardId { get; set; }

    }
}
