using Api2DataAccess.Entities;
using Api2DataAccess.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Concrete
{
    

    class WarehouseRepository : IWarehouseRepository
    {
        public Task<bool> Create(Warehouse entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warehouse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Warehouse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Warehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}
