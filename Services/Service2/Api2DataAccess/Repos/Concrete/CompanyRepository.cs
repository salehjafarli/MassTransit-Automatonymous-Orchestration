using Api2DataAccess.Entities;
using Api2DataAccess.Helpers;
using Api2DataAccess.Repos.Abstract;
using Dapper;
using Dapper.FluentMap;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Concrete
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(string ConString) : base(ConString,"Companies",typeof(Company))
        {
            DapperCustomMap.SetFor<Company>();
        }

        public async Task<bool> Create(Company entity)
        {
            string sql = InsertCommand("id");
            using (var con = new NpgsqlConnection(ConString))
            {

                return await con.ExecuteAsync(sql,entity)==1;
            }
           
            
        }

        public async Task<bool> Delete(int id)
        {
            string sql = DeleteCommand;
            using (var con = new NpgsqlConnection(ConString))
            {
                var parameters = new { Id = id };
                return await con.ExecuteAsync(sql, parameters) == 1;
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            string sql =Get;
            using (var con = new NpgsqlConnection(ConString))
            { 
                return await con.QueryAsync<Company>(sql);
            }
        }

        public async Task<Company> GetById(int id)
        {
            string sql = GetByIdQuery;
            using (var con = new NpgsqlConnection(ConString))
            {
                var parameters = new {Id = id };
                return await con.QueryFirstOrDefaultAsync<Company>(sql,parameters);
            }
        }

        public async Task<bool> Update(Company entity)
        {
            string sql = UpdateCommand("id");
            using (var con = new NpgsqlConnection(ConString))
            {
                return await con.ExecuteAsync(sql, entity) == 1;
            }
        }
    }
}
