using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Helper;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using System.Text;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CardService:Service<CardCreateDto,CardListDto,Card>,ICardService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CardCreateDto> _createDtoValidator;
        public readonly IValidator<CardListDto> _updateDtoValidator;
        public readonly IUOW _uow;
       

        public CardService(IMapper mapper, IValidator<CardCreateDto> createDtoValidator, IValidator<CardListDto> updateDtoValidator, IUOW uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        
        }


        public IResponse CreatePdf()
        {
            
            return new Response(ResponseType.Success);
        }
    }
}
