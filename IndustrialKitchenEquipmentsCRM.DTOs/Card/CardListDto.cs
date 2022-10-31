using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common.Enums;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardListDto:IListDto
    {
        public CardListDto()
        {
            CardItems = new List<CardItemListDto>();
        }
        public int? AppUserId { get; set; }
        public List<CardItemListDto> CardItems { get; set; }
        public int TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }

    }
}
