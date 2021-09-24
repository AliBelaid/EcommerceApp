using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {

        Task<T> GetByIdAsync (int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> spec);
         Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
         Task<int> CountAsync(ISpecifications<T>spec);
    }
}