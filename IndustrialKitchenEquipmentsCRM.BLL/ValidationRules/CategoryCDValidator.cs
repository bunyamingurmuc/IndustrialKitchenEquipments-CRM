using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class CategoryCDValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCDValidator()
        {
        }
    }
}
