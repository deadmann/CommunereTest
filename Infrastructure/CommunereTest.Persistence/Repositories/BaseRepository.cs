using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommunereTest.Persistence.Repositories
{
    public abstract class BaseRepository<TData, TId>: IRepository<TData, TId> where TData : class
    {
        protected AppDbContext DbContext { get; private set; }

        protected BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<TData> GetAll()
        {
            return DbContext.Set<TData>().ToList();
        }

        public async Task<IEnumerable<TData>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<TData>().ToListAsync(cancellationToken);
        }

        public TData GetById(TId id)
        {
            return DbContext.Set<TData>().Find(id);
        }

        public async Task<TData> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<TData>().FindAsync(new object[] {id}, cancellationToken);
        }

        public TData Create(TData data)
        {
            return DbContext.Add(data).Entity;
        }

        public void CreateRange(IEnumerable<TData> dataList)
        {
            DbContext.AddRange(dataList);
        }

        public void Update(TData data)
        {
            DbContext.Attach(data).State = EntityState.Modified;
            DbContext.Update(data);
        }
        
        public void UpdateRange(IEnumerable<TData> dataList)
        {
            DbContext.UpdateRange(dataList);
        }

        public void Delete(TData data)
        {
            DbContext.Remove(data);
        }
        
        public void DeleteRange(IEnumerable<TData> dataList)
        {
            DbContext.RemoveRange(dataList);
        }

        public void DeleteById(TId id)
        {
            var data = DbContext.Set<TData>().Find(id);
            Delete(data);
        }

        public async Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            var data = await DbContext.Set<TData>().FindAsync(new object[] {id}, cancellationToken);
            Delete(data);
        }
    }
}