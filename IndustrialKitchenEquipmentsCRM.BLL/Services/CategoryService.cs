using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.Common;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CategoryService:Service<CategoryCreateDto,CategoryListDto,CategoryUpdateDto,Category>,ICategoryService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CategoryCreateDto> _createDtoValidator;
        public readonly IValidator<CardUpdateDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;

        public CategoryService(IMapper mapper, IValidator<CategoryCreateDto> createDtoValidator, IUOW uow, IValidator<CategoryUpdateDto> updateDtoValidator, IValidator<CardUpdateDto> updateDtoValidator2, IndustrialKitchenEquipmentsContext context) : base(mapper, createDtoValidator, uow, updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator2;
            _uow = uow;
            _context = context;
        }
        public async Task<IResponse<List<CategoryListDto>>> GetAllWithR()
        {
            var Categories = await _context.Categories
                .Include(x => x.Stocks)
                .ToListAsync();
            var mapped = _mapper.Map<List<CategoryListDto>>(Categories);
            return new Response<List<CategoryListDto>>(ResponseType.Success, mapped);

        }

        public async Task<IResponse<CategoryListDto>> GetR(int id)
        {
            var Category = await _context.Categories.Where(i => i.Id == id)
                .Include(x => x.Stocks)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<CategoryListDto>(Category);
            return new Response<CategoryListDto>(ResponseType.Success, mapped);
        }

    }
}
