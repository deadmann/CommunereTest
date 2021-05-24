using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CommunereTest.Domain.Interfaces.Repositories
{
    public interface IRepository<TData, in TId> where TData:class
    {
        IEnumerable<TData> GetAll();
        Task<IEnumerable<TData>> GetAllAsync(CancellationToken cancellationToken = default);
        TData GetById(TId id);
        Task<TData> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        
        void Create(TData data);
        void Update(TData data);
        void Delete(TData data);
        void DeleteById(TId id);
        Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
        void CreateRange(IEnumerable<TData> dataList);
        void UpdateRange(IEnumerable<TData> dataList);
        void DeleteRange(IEnumerable<TData> dataList);
    }
}