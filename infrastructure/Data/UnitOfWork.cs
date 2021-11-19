using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly StoreContext _context;
        private Hashtable _repositories;
        
      public  UnitOfWork(StoreContext context)
         {
           _context = context;
        }
        public async  Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories==null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if(!_repositories.ContainsKey(type)){
              var repositoryType= typeof(GenericRepository<>);
              var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                          _repositories.Add(type,repositoryInstance);

            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }
                                                                                                                                 
    

        // // TODO: override c only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
              _context.Dispose();
        }
    }
}