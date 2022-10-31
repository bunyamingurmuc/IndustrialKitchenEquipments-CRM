using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DTOs.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Card;

namespace IndustrialKitchenEquipmentsCRM.BLL.Interfaces
{
    public interface ICardService:IService<CardCreateDto,CardListDto,Card>
    {
    }
}
