using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.API.Extension.Token;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class AppUserService: Service<AppUserCreateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserListDto> updateDtoValidator, IUOW uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }

        public async Task<IResponse<AppUserCreateDto>> CreateUser(CCreateAccountDto dto)
        {
            var appusers = GetAllAsync();
            var appusersmail = appusers.Result.Data.Select(i => i.Email);
            if (appusersmail.Contains(dto.Email))
            {
                return new Response<AppUserCreateDto>(ResponseType.ValidationError, "Bu mail daha önce alındı");
            }
            if (dto.ConfirmPassword != dto.Password)
            {
                return new Response<AppUserCreateDto>(ResponseType.ValidationError, "Şifre ve Parola eşleşmiyor");
            }
            AppUserCreateDto createDto = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                SurName = dto.Surname,
                Adress = dto.Adress,
                Password = dto.Password
            };
            var result = await CreateAsync(createDto);
            return new Response<AppUserCreateDto>(ResponseType.Success, result.Data);
        }

       
    }
}
