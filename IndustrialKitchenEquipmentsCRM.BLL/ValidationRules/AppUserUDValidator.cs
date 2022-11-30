using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.User;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class AppUserUDValidator: AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUDValidator()
        {
            
        }
    }
}
