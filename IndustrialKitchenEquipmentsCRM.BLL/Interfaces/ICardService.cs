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
    public interface ICardService:IService<CardCreateDto,CardListDto,Card>
    {
        IResponse CreatePdf();
        Task<IResponse<List<CardListDto>>> GetAllWithR();
        Task<IResponse<CardListDto>> GetR(int id);
        Task<IResponse<CardCreateDto>> CreateR(CardCreateDto dto);
    }
}
