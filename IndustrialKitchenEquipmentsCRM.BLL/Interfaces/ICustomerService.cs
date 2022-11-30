using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using IndustrialKitchenEquipmentsCRM.DTOs.Customer;
using IndustrialKitchenEquipmentsCRM.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface ICustomerService:IService<CustomerCreateDto,CustomerListDto,CustomerUpdateDto,Customer>
    {
        Task<IResponse<List<CustomerListDto>>> GetAllWithR();
        Task<IResponse<CustomerListDto>> GetR(int id);
    }
}
