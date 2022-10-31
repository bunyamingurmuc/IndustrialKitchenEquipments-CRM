using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CardItemService:Service<CardItemCreateDto, CardItemListDto, CardItem>,ICardItemService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CardItemCreateDto> _createDtoValidator;
        public readonly IValidator<CardItemListDto> _updateDtoValidator;
        public readonly IUOW _uow;

        public CardItemService(IMapper mapper, IValidator<CardItemCreateDto> createDtoValidator, IValidator<CardItemListDto> updateDtoValidator, IUOW uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }
    }
}
