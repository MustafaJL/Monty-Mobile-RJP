﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddRangeAsync(List<T> entity);
        void Delete(T entity);
        void RemoveRange(List<T> entities);
        void Update(T entity);
    }
}
