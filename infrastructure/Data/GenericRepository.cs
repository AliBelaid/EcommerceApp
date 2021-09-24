using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly StoreContext _ctx;

        public GenericRepository (StoreContext ctx) {
            _ctx = ctx;
        }

        async Task<T> IGenericRepository<T>.GetByIdAsync (int id) {
            return await _ctx.Set<T> ().FindAsync (id);

        }

        async Task<IReadOnlyList<T>> IGenericRepository<T>.ListAllAsync () {
            return await _ctx.Set<T> ().ToListAsync ();
        }

        async Task<IReadOnlyList<T>> IGenericRepository<T>.ListAsync (ISpecifications<T> spec) {
            return await applaySpecification (spec).ToListAsync ();
        }
        async Task<T> IGenericRepository<T>.GetEntityWithSpec (ISpecifications<T> spec) {
            return await applaySpecification (spec).FirstOrDefaultAsync ();
        }
        private IQueryable<T> applaySpecification (ISpecifications<T> spec) {
            return SpecificationEvaluator<T>.GetQuery (_ctx.Set<T> ().AsQueryable (), spec);
        }

        public async Task<int> CountAsync (ISpecifications<T> spec) {
            return await applaySpecification (spec).CountAsync ();
        }
    }
}