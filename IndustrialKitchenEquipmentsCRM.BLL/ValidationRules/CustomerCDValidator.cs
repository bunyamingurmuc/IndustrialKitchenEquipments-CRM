using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class CustomerCDValidator: AbstractValidator<CustomerCreateDto>
    {
        public CustomerCDValidator()
        {

        }
    }
}
