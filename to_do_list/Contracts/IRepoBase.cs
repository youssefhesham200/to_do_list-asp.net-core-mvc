﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list.Contracts
{
    public interface IRepoBase<T> where T : class
    {
        Task<IQueryable<T>> FindAllAsync();
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
