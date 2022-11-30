using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Category
{
    public class CategoryUpdateDto : IUpdateDto
    {
        public string CategoryName { get; set; }    
    }
}
