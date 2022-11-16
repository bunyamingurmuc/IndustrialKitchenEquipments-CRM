using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class StockService:Service<StockCreateDto,StockListDto,Stock>,IStockService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<StockCreateDto> _createDtoValidator;
        public readonly IValidator<StockListDto> _updateDtoValidator;
        public readonly IUOW _uow;

        public StockService(IMapper mapper, IValidator<StockCreateDto> createDtoValidator, IValidator<StockListDto> updateDtoValidator, IUOW uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }



        public async Task<IResponse<List<StockListDto>>> GetAllStocksWithR()
        {
            var query =await _uow.GetRepository<Stock>().GetQuery();

           var stocks= query.Include(i => i.CardItems).Include(i => i.Category).Include(i => i.Images).ToList();
            var mapped = _mapper.Map<List<StockListDto>>(stocks);
            return new Response<List<StockListDto>>(ResponseType.Success, mapped);

        }
    }
}
