using IndustrialKitchenEquipmentsCRM.Common.Enums;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Card
{
    public class CardUpdateDto: IUpdateDto
    {
        public List<CardItemUpdateDto> CardItems { get; set; }
        public int Discount { get; set; }
        public double TotalPrice { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
    }
}
