using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CardItemService:Service<CardItemCreateDto, CardItemListDto, CardItem>,ICardItemService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CardItemCreateDto> _createDtoValidator;
        public readonly IValidator<CardItemListDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;

        public CardItemService(IMapper mapper, IValidator<CardItemCreateDto> createDtoValidator, IValidator<CardItemListDto> updateDtoValidator, IUOW uow, IndustrialKitchenEquipmentsContext context) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
            _context = context;
        }

        public async Task<IResponse<List<CardItemListDto>>> GetAllWithR()
        {
            var CardItems = await _context.CardItems
                .Include(x => x.Stock)
                .Include(x => x.Card)
                .ToListAsync();
            var mapped = _mapper.Map<List<CardItemListDto>>(CardItems);
            return new Response<List<CardItemListDto>>(ResponseType.Success, mapped);

        }

        public async Task<IResponse<CardItemListDto>> GetR(int id)
        {
            var CardItem = await _context.CardItems.Where(i=>i.Id==id)
                .Include(x => x.Stock)
                .Include(x => x.Card)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<CardItemListDto>(CardItem);
            return new Response<CardItemListDto>(ResponseType.Success, mapped);
        }
    }
}
