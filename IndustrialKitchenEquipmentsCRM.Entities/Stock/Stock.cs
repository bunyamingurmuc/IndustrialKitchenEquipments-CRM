using IndustrialKitchenEquipmentsCRM.Entities.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;
using IndustrialKitchenEquipmentsCRM.Entities;
namespace IndustrialKitchenEquipmentsCRM.Entities.Stock
{
    public class Stock:BaseEntity
    {
        public Stock()
        {
            Images = new List<Image.Image>();
            CardItems = new List<CardItem>();
        }
        public string StockName { get; set; }
        public string? StockDescription { get; set; }
        public int StockCount { get; set; }
        public bool IsAvalible { get; set; }
        public List<Image.Image>? Images { get; set; }
        public List<CardItem>? CardItems { get; set; }
        public int? CategoryId { get; set; }
        public Category.Category? Category{ get; set; }

    }
}
