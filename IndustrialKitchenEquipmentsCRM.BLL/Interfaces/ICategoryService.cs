using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface ICategoryService:IService<CategoryCreateDto,CategoryListDto,CategoryUpdateDto,Category>
    {
        Task<IResponse<List<CategoryListDto>>> GetAllWithR();
        Task<IResponse<CategoryListDto>> GetR(int id);
    }
}
