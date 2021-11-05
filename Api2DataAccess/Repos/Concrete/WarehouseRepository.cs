using Api2DataAccess.Entities;
using Api2DataAccess.Repos.Abstract;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Concrete
{
    class WarehouseData
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
    }
    

    public class WarehouseRepository :BaseRepository, IWarehouseRepository
    {
        public WarehouseRepository(string ConString) : base(ConString,"Warehouses",typeof(Warehouse))
        {

        }
        public async Task<bool> Create(Warehouse entity)
        {
            var sql = InsertCommand();
            using (var conn = new NpgsqlConnection())
            {
                return true;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {

            string sql = @"Select w.*,c.CompanyName,p.*,cat.CategoryName from WarehouseData as wd
                            inner join Warehouses as w on w.WarehouseId = wd.WarehouseId 
                            inner join Companies as c on w.CompanyId = c.CompanyId
                            inner join Products as p on wd.ProductId = p.ProductId
                            inner join Categories as cat on p.CategoryId = cat.CategoryId
                            ";
            using (var conn = new NpgsqlConnection(ConString))
            {
                var dic = new Dictionary<int, Warehouse>();
                var res = conn.Query<Warehouse, Company, Product, Category, Warehouse>(sql, (w, c, p, cat) =>
                    {
                        
                        if (dic.ContainsKey(w.WarehouseId))
                        {
                            p.Category = cat;
                            dic[w.WarehouseId].Products.Add(p);
                        }
                        else
                        {
                            w.Company = c;
                            p.Category = cat;
                            w.Products.Add(p);
                            dic.Add(w.WarehouseId, w);
                        }
                        
                        
                        return w;
                    }, splitOn: "CompanyId,ProductId,CategoryId");
                return dic.Select(x => x.Value).ToList();
            }
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
