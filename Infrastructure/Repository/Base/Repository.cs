﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _set;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<T> GetById(long id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await _set.AddRangeAsync(entity);
        }
        public void Delete(T entity)
        {
            _set.Remove(entity);
        }
        public void RemoveRange(List<T> entities)
        {
            _set.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _set.Update(entity);
        }


    }
}
