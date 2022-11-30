using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Image;
using IndustrialKitchenEquipmentsCRM.DTOs.Stock;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface IStockService:IService<StockCreateDto,StockListDto,StockUpdateDto,Stock>
    {
        Task<IResponse<List<StockListDto>>> GetAllWithR();
        Task<IResponse<StockListDto>> GetR(int id);

    }
}
