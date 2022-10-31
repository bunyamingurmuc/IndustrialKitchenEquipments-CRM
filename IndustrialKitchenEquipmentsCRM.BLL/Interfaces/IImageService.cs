using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Image;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface IImageService:IService<ImageCreateDto,ImageListDto,Image>
    {
    }
}
