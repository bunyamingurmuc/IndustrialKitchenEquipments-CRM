﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialKitchenEquipmentsCRM.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T?> FindAsync(object id);
        Task<T?> GetByFilterAsycn(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task<IQueryable<T>> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
