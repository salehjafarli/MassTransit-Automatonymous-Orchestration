using Api2DataAccess.Entities;
using Api2DataAccess.Helpers;
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


    public class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        public WarehouseRepository(string ConString) : base(ConString, "Warehouses", typeof(Warehouse))
        {
            DapperCustomMap.SetFor<Category>();
            DapperCustomMap.SetFor<Product>("product");
            DapperCustomMap.SetFor<Company>();
            DapperCustomMap.SetFor<Warehouse>();


        }
        public Task<bool> Create(Warehouse entity)
        {
            var sql = InsertCommand("company,products,id", "company_id");
            using (var conn = new NpgsqlConnection(ConString))
            {
                bool res1 = conn.Execute(sql,
                new
                {
                    name = entity.Name,
                    adress = entity.Adress,
                    company_id = entity.Company.Id
                }) == 1;
                return Task.FromResult(res1);
            }
        }
        public Task<bool> Update(Warehouse entity)
        {
            var sql = UpdateCommand("company,products,id", "company_id");
            using (var conn = new NpgsqlConnection(ConString))
            {
                return Task.FromResult(conn.Execute(sql, new
                {
                    name = entity.Name,
                    adress = entity.Adress,
                    company_id = entity.Company.Id
                }) == 1);
            }
        }

        public Task<bool> Delete(int id)
        {
            string sql = DeleteCommand;
            using (var conn = new NpgsqlConnection(ConString))
            {
                return Task.FromResult(conn.ExecuteAsync(sql, new { Id = id }).Result == 1);
            }
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {

            string sql = @"Select w.*,c.company_name,p.*,wd.product_amount,cat.category_name from WarehouseData as wd
                            right join Warehouses as w on w.Warehouse_Id = wd.Warehouse_Id 
                            left join Companies as c on w.Company_Id = c.Company_Id
                            left join Products as p on wd.Product_Id = p.Product_Id
                            left join Categories as cat on p.Category_Id = cat.Category_Id
                            ";
            using (var conn = new NpgsqlConnection(ConString))
            {
                var res = conn.Query<Warehouse, Company, WarehouseProduct, Category, Warehouse>(sql, (w, c, p, cat) =>
                    {
                        w.Company = c;
                        if (p is not null)
                        {
                            w.Products = new List<WarehouseProduct>();
                            p.Category = cat;
                            w.Products.Add(p);
                        }
                        return w;
                    }, splitOn: "Company_Id,Product_Id,Category_Id");

                res = res.GroupBy(x => x.Id)
                      .Select(x =>
                      {
                          var first = x.First();
                          if (first.Products != null)
                              first.Products = x.Select(x => x.Products.FirstOrDefault()).ToList();
                          else first.Products = new List<WarehouseProduct>();
                          return first;
                      });
                return res;
            }
        }


        public Task<Warehouse> GetById(int id)
        {
            string sql = @"Select w.*,c.company_name,p.*,wd.product_amount,cat.category_name from WarehouseData as wd
                            right join Warehouses as w on w.Warehouse_Id = wd.Warehouse_Id 
                            left join Companies as c on w.Company_Id = c.Company_Id
                            left join Products as p on wd.Product_Id = p.Product_Id
                            left join Categories as cat on p.Category_Id = cat.Category_Id
                            where w.warehouse_id =@Id
                            ";
            using (var conn = new NpgsqlConnection(ConString))
            {
                var res = conn.Query<Warehouse, Company, WarehouseProduct, Category, Warehouse>(sql, (w, c, p, cat) =>
                {
                    w.Company = c;
                    if (p is not null)
                    {
                        w.Products = new List<WarehouseProduct>();
                        p.Category = cat;
                        w.Products.Add(p);
                    }

                    return w;
                }, splitOn: "Company_Id,Product_Id,Category_Id", param: new { Id = id });

                var result = res.GroupBy(x => x.Id)
                      .Select(x =>
                      {
                          var first = x.First();
                          if (first.Products is not null)
                              first.Products = x.Select(x => x.Products.FirstOrDefault()).ToList();
                          else first.Products = new List<WarehouseProduct>();
                          return first;
                      }).FirstOrDefault();
                return Task.FromResult(result);
            }
        }

    }
}
