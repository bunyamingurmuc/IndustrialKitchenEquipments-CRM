using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs
{
    public class StockListDto:IListDto
    {
        public StockListDto()
        {
            Images = new List<ImageListDto>();
        }
        public string StockName { get; set; }
        public string? StockDescription { get; set; }
        public int StockCount { get; set; }
        public bool IsAvalible { get; set; }
        public List<ImageListDto> Images { get; set; }
        public int? CategoryId { get; set; }



    }
}
