using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.ValidationRules
{
    public class CardLDValidator: AbstractValidator<CardListDto>
    {
        public CardLDValidator()
        {
            RuleFor(x => x.CurrencyUnit).NotEmpty().WithMessage("Para birimi alanı boş geçilemez");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Toplam fiyat alanı geçilemez");
        }
    }
}
