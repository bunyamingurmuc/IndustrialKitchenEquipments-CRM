using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class StockCDValidator:AbstractValidator<StockCreateDto>
    {
        public StockCDValidator()
        {

        }
    }
}
