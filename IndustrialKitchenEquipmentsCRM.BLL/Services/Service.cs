using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using System.Net.Http.Headers;
using IndustrialKitchenEquipmentsCRM.BLL.Extensions;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class Service<CreateDto, ListDto, UpdateDto, T> : IService<CreateDto, ListDto,UpdateDto, T>
     where CreateDto : ICreateDto, new()
     where ListDto : IListDto, new()
     where UpdateDto:IUpdateDto,new ()
     where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUOW _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IUOW uow, IValidator<UpdateDto> updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _uow = uow;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
           return new Response<List<ListDto>>(ResponseType.Success, dto);    
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsycn(x => x.Id == id);
            if (data==null)
            {
                return new Response<IDto>(ResponseType.NotFound, "Data bulunamadı");
            }
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsycn();
                dto.Id=createdEntity.Id;
                return new Response<CreateDto>(ResponseType.Success, dto);
            }

            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());


        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepository<T>().FindAsync(dto.Id);
                if (unchangedData==null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, "data bulunamadı");
                }
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, unchangedData);

                await _uow.SaveChangesAsycn();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);
            if (data==null)
            {
                return new Response(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");

            }
            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChangesAsycn();
            return new Response(ResponseType.Success);

        }
    }
}
