using IndustrialKitchenEquipmentsCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DAL.UOW
{
    public interface IUOW
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsycn();
    }
}
