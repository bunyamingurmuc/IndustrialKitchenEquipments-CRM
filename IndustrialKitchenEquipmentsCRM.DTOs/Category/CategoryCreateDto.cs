using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Category
{
    public class CategoryCreateDto : ICreateDto
    {
        public CategoryCreateDto()
        {
            Stocks = new List<StockCreateDto>();
        }
       
        public string CategoryName { get; set; }
        public List<StockCreateDto> Stocks { get; set; }

    }
}
