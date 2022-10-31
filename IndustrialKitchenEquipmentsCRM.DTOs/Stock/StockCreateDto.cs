using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs
{
    public class StockCreateDto : ICreateDto
    {
        public StockCreateDto()
        {
            Images = new List<ImageCreateDto>();
        }
        public string StockName { get; set; }
        public string StockDescription { get; set; }
        public int StockCount { get; set; }
        public bool IsAvalible { get; set; }
        public List<ImageCreateDto> Images { get; set; }
        public int? CategoryId { get; set; }

    }
}
