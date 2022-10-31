using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Image;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class ImageService:Service<ImageCreateDto,ImageListDto,Image>,IImageService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<ImageCreateDto> _createDtoValidator;
        public readonly IValidator<ImageListDto> _updateDtoValidator;
        public readonly IUOW _uow;

        public ImageService(IMapper mapper, IValidator<ImageCreateDto> createDtoValidator, IValidator<ImageListDto> updateDtoValidator, IUOW uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }
    }
}
