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
        public IQueryable<T> FindAll() => DbContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DbContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => DbContext.Set<T>().Add(entity);
        public void Update(T entity) => DbContext.Set<T>().Update(entity);
        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);

        public void save()
        {
            DbContext.SaveChanges();
        }
    }
}