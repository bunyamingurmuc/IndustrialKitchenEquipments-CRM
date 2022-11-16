using IndustrialKitchenEquipmentsCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.DAL.Abstracts
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IndustrialKitchenEquipmentsContext _context;

        public Repository(IndustrialKitchenEquipmentsContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }



        public async Task<T?> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByFilterAsycn(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking
                ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter)
                : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<IQueryable<T>> GetQuery()
        {
            var data = await _context.Set<T>().ToListAsync();
            var quarabled = data.AsQueryable();
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
