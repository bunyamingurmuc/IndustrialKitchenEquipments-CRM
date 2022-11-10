using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;

namespace IndustrialKitchenEquipmentsCRM.Entities.Card
{
    public class CardItem:BaseEntity
    {
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int? StockId { get; set; }
        public Stock.Stock? Stock { get; set; }
        public int? CardId { get; set; }
        public Card? Card { get; set; }
    }
}
