using IndustrialKitchenEquipmentsCRM.Common.Enums;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs.User;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardCreateDto: ICreateDto
    {
        public CardCreateDto()
        {
            CardItems = new List<CardItemCreateDto>();
        }
        public CurrencyUnit CurrencyUnit { get; set; }
        public double TotalPrice { get; set; }
        public List<CardItemCreateDto> CardItems { get; set; }
        public int Discount { get; set; }
        public int? CustomerId { get; set; }
        public int? AppUserId { get; set; }
      

    }
}
