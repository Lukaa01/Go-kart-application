using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marketing_system.DA.Contracts.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<EntityEntry<TEntity>> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        TEntity Update(TEntity entity);
        public void Delete(int id);
    }
}

