using IndustrialKitchenEquipmentsCRM.Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace IndustrialKitchenEquipmentsCRM.Entities.Auth
{
    public class AppRole : BaseEntity
    {
        public string Description { get; set; }
    }
}
