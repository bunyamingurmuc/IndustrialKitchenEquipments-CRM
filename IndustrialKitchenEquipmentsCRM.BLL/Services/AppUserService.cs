using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.API.Extension.Token;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class AppUserService: Service<AppUserCreateDto, AppUserListDto, AppUserUpdateDto, AppUser>, IAppUserService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<AppUserCreateDto> _createDtoValidator;
        public readonly IValidator<AppUserUpdateDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IUOW uow, IValidator<AppUserUpdateDto> updateDtoValidator, IndustrialKitchenEquipmentsContext context) : base(mapper, createDtoValidator, uow, updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
            _context = context;
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

        public async Task<IResponse<List<AppUserListDto>>> GetAllWithR()
        {
            var AppUsers =await _context.AppUsers
                .Include(x => x.Cards).ToListAsync();
            var mapped = _mapper.Map<List<AppUserListDto>>(AppUsers);
            return new Response<List<AppUserListDto>>(ResponseType.Success, mapped);



        }

        public async Task<IResponse<AppUserListDto>> GetR(int id)
        {
            var AppUser = await _context.AppUsers.Where(i=>i.Id==id)
                .Include(x => x.Cards).FirstOrDefaultAsync();
            var mapped = _mapper.Map<AppUserListDto>(AppUser);
            return new Response<AppUserListDto>(ResponseType.Success, mapped);
        }
    }
}
