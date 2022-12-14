using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs.Interfaces;
using IndustrialKitchenEquipmentsCRM.Entities.Interface;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface IService<CreateDto,  ListDto, UpdateDto, T>
        where CreateDto : class, new()
        where ListDto : class,new()
        where UpdateDto : class,new()
        where T : BaseEntity
    {
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
         Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse> RemoveAsync(int id);
    }
}

