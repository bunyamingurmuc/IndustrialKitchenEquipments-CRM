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
            return new Response(ResponseType.Success,$"/Upload/{formFile.FileName}");

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

        public string ConvertToBase64(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            var base64 = Convert.ToBase64String(byData);
            return String.Format("data:image/jpg;base64,{0}", base64);
        }
    }
}
