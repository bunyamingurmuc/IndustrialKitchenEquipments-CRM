using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using Microsoft.AspNetCore.Http;

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

        public IResponse CreateImage(FileStream fileStream, IFormFile formFile)
        {
            formFile.CopyTo(fileStream);
            fileStream.Flush();
            return new Response(ResponseType.Success,$"//Upload//+{formFile.FileName}");

        }

        public IResponse DeleteImage(string filePath)
        {
            File.Delete(filePath);
            return new Response(ResponseType.Success);

        }

        public IResponse updateImage(string oldFilePath, FileStream fileStream, IFormFile formFile)
        {
            DeleteImage(oldFilePath);
            CreateImage(fileStream, formFile);
            return new Response(ResponseType.Success);
        }
    }
}
