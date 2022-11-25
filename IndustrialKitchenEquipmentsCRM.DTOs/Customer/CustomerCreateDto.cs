using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Customer
{
    public class CustomerCreateDto:ICreateDto
    {
        public CustomerCreateDto()
        {
            Cards = new List<CardCreateDto>();

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<CardCreateDto> Cards { get; set; }
    }
}
