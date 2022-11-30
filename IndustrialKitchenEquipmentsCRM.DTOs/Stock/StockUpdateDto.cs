using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Stock
{
    public class StockUpdateDto : IUpdateDto
    {
    
        public string StockName { get; set; }
        public string? StockDescription1 { get; set; }
        public string? StockDescription2 { get; set; }
        public int StockCount { get; set; }
        public double Price { get; set; }
        public bool IsAvalible { get; set; }
        public int? CategoryId { get; set; }

    }
}
