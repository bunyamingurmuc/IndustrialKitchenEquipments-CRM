using System.Security.Permissions;
using IndustrialKitchenEquipmentsCRM.Common.Enums;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;

namespace IndustrialKitchenEquipmentsCRM.Entities.Card
{
    public class Card:BaseEntity
    {
        public Card()
        {
            CardItems = new List<CardItem>();
        }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<CardItem> CardItems { get; set; }
        public int TotalPrice { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public int? CustomerId { get; set; }
        public Customer.Customer? Customer { get; set; }
    }
}
