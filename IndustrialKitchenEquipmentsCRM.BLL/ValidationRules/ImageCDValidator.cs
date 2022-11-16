using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class ImageCDValidator:AbstractValidator<ImageCreateDto>
    {
        public ImageCDValidator()
        {

        }
    }
}
