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
        public CategoryListDto Category { get; set; }



    }
}
