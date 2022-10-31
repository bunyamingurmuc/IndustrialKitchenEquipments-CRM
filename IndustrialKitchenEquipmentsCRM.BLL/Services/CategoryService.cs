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

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CategoryService:Service<CategoryCreateDto,CategoryListDto,Category>,ICategoryService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CategoryCreateDto> _createDtoValidator;
        public readonly IValidator<CategoryListDto> _updateDtoValidator;
        public readonly IUOW _uow;

        public CategoryService(IMapper mapper, IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryListDto> updateDtoValidator, IUOW uow): base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }


    }
}
