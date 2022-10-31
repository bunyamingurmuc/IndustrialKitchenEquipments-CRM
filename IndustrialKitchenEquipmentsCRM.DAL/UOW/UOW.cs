using IndustrialKitchenEquipmentsCRM.DAL.Abstracts;
using IndustrialKitchenEquipmentsCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DAL.Context;

namespace IndustrialKitchenEquipmentsCRM.DAL.UOW
{
    public class UOW : IUOW
    {
        private readonly IndustrialKitchenEquipmentsContext _context;

        public UOW(IndustrialKitchenEquipmentsContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsycn()
        {
            await _context.SaveChangesAsync();
        }
    }
}
