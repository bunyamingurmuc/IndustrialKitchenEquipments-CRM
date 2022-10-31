using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Image
{
    public class ImageCreateDto : ICreateDto
    {
        public string Url { get; set; }
        public int? StockId { get; set; }
      
    }
}
