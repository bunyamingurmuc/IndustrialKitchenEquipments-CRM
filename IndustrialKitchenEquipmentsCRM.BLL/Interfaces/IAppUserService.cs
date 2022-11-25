using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos;
using IndustrialKitchenEquipmentsCRM.DTOs.User;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface IAppUserService:IService<AppUserCreateDto,AppUserListDto,AppUser>
    {
        public Task<IResponse<AppUserCreateDto>> CreateUser(CCreateAccountDto dto);
        Task<IResponse<List<AppUserListDto>>> GetAllWithR();
        Task<IResponse<AppUserListDto>> GetR(int id);


    }
}
