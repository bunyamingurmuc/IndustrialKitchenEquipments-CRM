﻿using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class CardItemCDValidator: AbstractValidator<CardItemCreateDto>
    {
        public CardItemCDValidator()
        {
            RuleFor(i => i.Quantity).NotEmpty().WithMessage("Adet alanı boş geçilemez");

        }
    }
}
