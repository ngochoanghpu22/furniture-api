﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Furniture.Data.Interfaces;
using Furniture.Data;

namespace PCMS.Infrastructure.Repositories
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
    {
        private readonly FurnitureContext _context;

        public EFRepository(FurnitureContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }


        public void AddRange(List<T> entities)
        {
            _context.AddRange(entities);
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
        public void UpdateRange(List<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public async Task<T> FindByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await FindAll(includeProperties).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
           _context.Set<T>().Remove(entity);
        }

        public async Task Remove(K id)
        {
            var entity = await FindByIdAsync(id);
            Remove(entity);
        }

        public void RemoveRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            var isExisted = await _context.Set<T>().Where(predicate).AnyAsync();
            return isExisted;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
