using AutoMapper;
using FluentValidation;
using IndustrialKitchenEquipmentsCRM.BLL.Interfaces;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using IndustrialKitchenEquipmentsCRM.DAL.UOW;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.BLL.Services
{
    public class ImageService:Service<ImageCreateDto,ImageListDto,ImageUpdateDto,Image>,IImageService
    {
        public readonly IMapper _mapper;
        public readonly IValidator<ImageCreateDto> _createDtoValidator;
        public readonly IValidator<ImageUpdateDto> _updateDtoValidator;
        public readonly IUOW _uow;
        public readonly IndustrialKitchenEquipmentsContext _context;

        public ImageService(IMapper mapper, IValidator<ImageCreateDto> createDtoValidator, IUOW uow, IValidator<ImageUpdateDto> updateDtoValidator, IndustrialKitchenEquipmentsContext context) : base(mapper, createDtoValidator, uow, updateDtoValidator)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
            _context = context;
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
        public async Task<IResponse<List<ImageListDto>>> GetAllWithR()
        {
            var Images = await _context.Images
                .Include(x => x.Stock)
                .ToListAsync();
            var mapped = _mapper.Map<List<ImageListDto>>(Images);
            return new Response<List<ImageListDto>>(ResponseType.Success, mapped);
        }

        public async Task<IResponse<ImageListDto>> GetR(int id)
        {
            var Image = await _context.Images.Where(i => i.Id == id)
                .Include(x => x.Stock)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<ImageListDto>(Image);
            return new Response<ImageListDto>(ResponseType.Success, mapped);
        }
    }
}
