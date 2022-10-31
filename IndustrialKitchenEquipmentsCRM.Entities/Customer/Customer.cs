using IndustrialKitchenEquipmentsCRM.Entities.Interface;

namespace IndustrialKitchenEquipmentsCRM.Entities.Customer
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
            Cards = new List<Card.Card>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Card.Card> Cards{ get; set; }
    }
}
