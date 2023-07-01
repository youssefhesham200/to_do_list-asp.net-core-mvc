using System.Linq.Expressions;
using to_do_list.Contracts;
using Microsoft.EntityFrameworkCore;

namespace to_do_list.Repository
{
    public abstract class RepoBase<T> : IRepoBase<T> where T : class
    {
        protected to_do_listDbContext DbContext { get; set; }
        public RepoBase(to_do_listDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<IQueryable<T>> FindAllAsync()
        {
            return (await DbContext.Set<T>().ToListAsync()).AsQueryable();
        }

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return (await DbContext.Set<T>().Where(expression).ToListAsync()).AsQueryable();
        }
        public async Task CreateAsync(T entity) {

            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity) {

            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

    }
}