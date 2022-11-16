using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;

namespace IndustrialKitchenEquipmentsCRM.DTOs.User
{
    public class AppUserListDto:IListDto
    {
        public AppUserListDto()
        {
            Cards = new List<CardListDto>();
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }

        public List<CardListDto> Cards { get; set; }
       
    }
}
