using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

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

    }
}
