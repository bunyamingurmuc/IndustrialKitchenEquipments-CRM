using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Extensions;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CardService : Service<CardCreateDto, CardListDto,CardUpdateDto, Card>, ICardService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CardCreateDto> _createDtoValidator;
        public readonly IValidator<CardUpdateDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;
        public readonly IStockService _stockService;

        public CardService(IMapper mapper, IValidator<CardCreateDto> createDtoValidator, IUOW uow, IValidator<CardUpdateDto> updateDtoValidator, IndustrialKitchenEquipmentsContext context, IStockService stockService) : base(mapper, createDtoValidator, uow, updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
            _context = context;
            _stockService = stockService;
        }
        public IResponse CreatePdf()
        {
            return new Response(ResponseType.Success);
        }
        public async Task<IResponse<List<CardListDto>>> GetAllWithR()
        {
            var Cards = await _context.Cards
                .Include(x => x.CardItems)
                .Include(x => x.Customer)
                .ToListAsync();
            var mapped = _mapper.Map<List<CardListDto>>(Cards);
            return new Response<List<CardListDto>>(ResponseType.Success, mapped);
        }

        public async Task<IResponse<CardListDto>> GetR(int id)
        {
            var Card = await _context.Cards.Where(i => i.Id == id)
                .Include(x => x.CardItems)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<CardListDto>(Card);
            return new Response<CardListDto>(ResponseType.Success, mapped);
        }
        public async Task<IResponse<CardCreateDto>> CreateR(CardCreateDto dto)
        {
            var totalPrice = 0.0;
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                foreach (var cardItem in dto.CardItems)
                {
                    var stock = _stockService.GetByIdAsync<StockListDto>(cardItem.StockId.Value).Result.Data;
                    double amounth = (stock.Price * cardItem.Quantity);
                    cardItem.Amount = amounth;
                    totalPrice += amounth;
                }
                var newCreated = new CardCreateDto()
                {
                    AppUserId = dto.AppUserId,
                    CardItems = dto.CardItems,
                    CustomerId = dto.CustomerId,
                    CurrencyUnit = dto.CurrencyUnit,
                    TotalPrice = (totalPrice * (100 - dto.Discount)/100),

                };
                await CreateAsync(newCreated);
                return new Response<CardCreateDto>(ResponseType.Success, newCreated);
            }
            return new Response<CardCreateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}
