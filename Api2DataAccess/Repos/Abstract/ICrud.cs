using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Abstract
{
    public interface ICrud<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
