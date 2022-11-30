using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.Common;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface ICardItemService:IService<CardItemCreateDto,CardItemListDto,CardItemUpdateDto, CardItem>
    {
        Task<IResponse<List<CardItemListDto>>> GetAllWithR();
        Task<IResponse<CardItemListDto>> GetR(int id);
    }
}
