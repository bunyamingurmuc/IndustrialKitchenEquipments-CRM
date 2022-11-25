using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.DTOs
{
    public class StockListDto:IListDto
    {
        public StockListDto()
        {
            Images = new List<ImageListDto>();
            CardItems = new List<CardItemListDto>();
        }
        public string StockName { get; set; }
        public string? StockDescription1 { get; set; }
        public string? StockDescription2 { get; set; }
        public int StockCount { get; set; }
        public double Price { get; set; }
        public bool IsAvalible { get; set; }
        public List<ImageListDto> Images { get; set; }
        public int? CategoryId { get; set; }
        public CategoryListDto? Category { get; set; }
        public List<CardItemListDto> CardItems { get; set; }


    }
}
