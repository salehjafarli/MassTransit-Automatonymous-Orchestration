using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Abstract
{
    public abstract class BaseRepository
    {
        public BaseRepository(string ConString, string TableName,Type EntityType)
        {
            this.ConString = ConString;
            this.TableName = TableName;
            this.EntityType = EntityType;
        }

        public string ConString { get; }
        public string TableName { get; }
        public Type EntityType { get; }
 
        public string GetByIdQuery => $"{Get} where {EntityType.Name}_Id = @Id";

        public string Get => $"Select * From {TableName}";
        public string DeleteCommand => $"Delete from {TableName} where {EntityType.Name}_Id = @Id";

        //insert into 

        public string MyProperty { get; set; }

        public string InsertCommand(string exprops = null)
        {
            string[] excluded = exprops is null ? new string[0] : exprops.Split(",");
            var props = EntityType.GetProperties();
            string qp1 = "";
            string qp2 = "";
            foreach (var item in props)
            { 
                var name =$"{EntityType.Name}_{item.Name}";
                var name2 = $"{item.Name}";
                if (item.Name.ToLower() != "id" && !excluded.Contains(item.Name.ToLower()))
                {
                    qp1 += name + ",";
                    qp2 += "@" + name2 + ",";
                }
            }
            qp1 = qp1.Remove(qp1.Length - 1);
            qp2 = qp2.Remove(qp2.Length - 1);
            return $"Insert into {TableName}({qp1}) values({qp2})";
        }
        public string UpdateCommand(string exprops = null)
        {
            string[] excluded = exprops is null ? new string[0] : exprops.Split(",");

            var props = EntityType.GetProperties();
            string qp = "";
            foreach (var item in props)
            {
                var name = $"{EntityType.Name}_{item.Name}";
                var name2 = $"{item.Name}";
                if (item.Name.ToLower() != "id" && !excluded.Contains(item.Name.ToLower()))
                {
                    qp += $"{name} = @{name2},";
                }
            }
            qp = qp.Remove(qp.Length - 1);
            return $"Update {TableName} Set {qp} where {EntityType.Name}_id = @Id";
        }



    }
}
