using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Image
{
    public class ImageListDto:IListDto
    {
        public string Url { get; set; }
        public int? StockId { get; set; }
        public StockListDto Stock { get; set; }
    }
}
