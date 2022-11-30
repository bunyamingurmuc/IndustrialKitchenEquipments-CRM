using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Stock;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class StockUDValidator:AbstractValidator<StockUpdateDto>
    {
        public StockUDValidator()
        {

        }
    }
}
