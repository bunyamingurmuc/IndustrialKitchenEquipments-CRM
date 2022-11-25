using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardItemListDto : IListDto
    {
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public int? StockId { get; set; }
        public StockListDto? Stock { get; set; }
        public int? CardId { get; set; }
    }
}
