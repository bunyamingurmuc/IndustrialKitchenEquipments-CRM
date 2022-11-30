using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using Microsoft.AspNetCore.Http;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface IImageService:IService<ImageCreateDto,ImageListDto,ImageUpdateDto,Image>
    {
        IResponse CreateImage(FileStream fileStream, IFormFile formFile);
        IResponse DeleteImage(string filePath);
        IResponse updateImage(string oldFilePath, FileStream fileStream, IFormFile formFile);
        string ConvertToBase64(string path);
        Task<IResponse<List<ImageListDto>>> GetAllWithR();
        Task<IResponse<ImageListDto>> GetR(int id);


    }
}
