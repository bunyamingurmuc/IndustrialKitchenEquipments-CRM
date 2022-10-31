using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.DTOs.Customer
{
    public class CustomerListDto :IListDto
    {
        public CustomerListDto()
        {
            Cards = new List<CardListDto>();
        }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<CardListDto> Cards{ get; set; }
    }
}
