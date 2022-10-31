using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CustomerService:Service<CustomerCreateDto, CustomerListDto, Customer>,ICustomerService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CustomerCreateDto> _createDtoValidator;
        public readonly IValidator<CustomerListDto> _updateDtoValidator;
        public readonly IUOW _uow;

        public CustomerService(IMapper mapper, IValidator<CustomerCreateDto> createDtoValidator, IValidator<CustomerListDto> updateDtoValidator, IUOW uow):base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }
    }
}
