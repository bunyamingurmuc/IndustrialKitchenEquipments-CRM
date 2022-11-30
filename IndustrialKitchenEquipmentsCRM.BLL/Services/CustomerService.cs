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
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.Common;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class CustomerService:Service<CustomerCreateDto, CustomerListDto,CustomerUpdateDto, Customer>,ICustomerService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<CustomerCreateDto> _createDtoValidator;
        public readonly IValidator<CustomerUpdateDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;

        public CustomerService(IMapper mapper, IValidator<CustomerCreateDto> createDtoValidator, IUOW uow, IValidator<CustomerUpdateDto> updateDtoValidator, IndustrialKitchenEquipmentsContext context) : base(mapper, createDtoValidator, uow, updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
            _context = context;
        }
        public async Task<IResponse<List<CustomerListDto>>> GetAllWithR()
        {
            var Customers = await _context.Customers
                .Include(x => x.Cards)
                .ToListAsync();
            var mapped = _mapper.Map<List<CustomerListDto>>(Customers);
            return new Response<List<CustomerListDto>>(ResponseType.Success, mapped);

        }

        public async Task<IResponse<CustomerListDto>> GetR(int id)
        {
            var Customer = await _context.Customers.Where(i => i.Id == id)
                .Include(x => x.Cards)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<CustomerListDto>(Customer);
            return new Response<CustomerListDto>(ResponseType.Success, mapped);
        }
    }
}
