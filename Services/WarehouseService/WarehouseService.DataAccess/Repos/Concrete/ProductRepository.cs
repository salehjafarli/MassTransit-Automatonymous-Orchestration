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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string ConString) : base(ConString,"Products",typeof(Product))
        {
            DapperCustomMap.SetFor<Category>();
            DapperCustomMap.SetFor<Product>();
        }
        public async Task<bool> Create(Product entity)
        {
            var sql = InsertCommand("category","category_id");
            using (NpgsqlConnection conn = new NpgsqlConnection(ConString))
            {
               bool res =  await conn.ExecuteAsync(sql,new
                {
                    id = entity.Id,
                    name = entity.Name,
                    cost = entity.Cost,
                    category_id = entity.Category.Id
                }) ==1;
                return res;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var sql = DeleteCommand;
            using (NpgsqlConnection conn = new NpgsqlConnection(ConString))
            {
                bool res = await conn.ExecuteAsync(sql,new {id = id }) ==1 ;
                return res;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var sql = @"select p.*,c.category_name from Products p inner join categories c
                        on p.category_id = c.category_id";
            using (NpgsqlConnection conn = new NpgsqlConnection(ConString))
            {
                var res = await conn.QueryAsync<Product,Category,Product>(sql,(x,y) => 
                {
                    x.Category = y;
                    return x;
                },splitOn:"category_id");

                return res;
            }

        }

        public async Task<Product> GetById(int id)
        {
            var sql = @"select from Products p inner join categories c
                        on p.category_id = c.category_id where p.product_id = @id";
            using (NpgsqlConnection conn = new NpgsqlConnection(ConString))
            {
                var res = await conn.QueryAsync<Product, Category, Product>(sql,(x, y) =>
                {
                    x.Category = y;
                    return x;
                }, splitOn: "category_id",param:new {id = id});

                return res.FirstOrDefault();
            }
        }

        public async Task<bool> Update(Product entity)
        {
            var sql = UpdateCommand("category", "category_id");
            using (NpgsqlConnection conn = new NpgsqlConnection(ConString))
            {
                bool res = await conn.ExecuteAsync(sql, new
                {
                    id = entity.Id,
                    name = entity.Name,
                    cost = entity.Cost,
                    category_id = entity.Category.Id
                }) == 1;
                return res;
            }
        }
    }
}
