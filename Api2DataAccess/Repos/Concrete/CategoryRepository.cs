using Api2DataAccess.Entities;
using Api2DataAccess.Helpers;
using Api2DataAccess.Repos.Abstract;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Concrete
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(string ConString) : base(ConString, "Categories", typeof(Category))
        {
            DapperCustomMap.SetFor<Category>();
        }
        public async Task<bool> Create(Category entity)
        {
            //Todo : add id col to command!
            string sql = InsertCommand();
            using (var conn = new NpgsqlConnection(ConString))
            {
                return await conn.ExecuteAsync(sql,entity) == 1;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            string sql = Get;
            using (var conn = new NpgsqlConnection(ConString))
            {
                return await conn.QueryAsync<Category>(sql);
            }
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
