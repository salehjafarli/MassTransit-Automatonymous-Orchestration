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

        public string GetByIdQuery => $"{Get} where {EntityType.Name}Id = @Id";

        public string Get => $"Select * From {TableName}";
        public string DeleteCommand => $"Delete from {TableName} where {EntityType.Name}Id = @Id";

        //insert into 

        public string MyProperty { get; set; }

        public string InsertCommand()
        {
            var props = EntityType.GetProperties();
            string qp1 = "";
            string qp2 = "";
            foreach (var item in props)
            {
                var name = item.Name;
                if (!name.ToLower().Contains("id"))
                {
                    qp1 += name + ",";
                    qp2 += "@" + name + ",";
                }
            }
            qp1 = qp1.Remove(qp1.Length - 1);
            qp2 = qp2.Remove(qp2.Length - 1);
            return $"Insert into {TableName}({qp1}) values({qp2})";
        }
        public string UpdateCommand()
        {
            var props = EntityType.GetProperties();
            string qp1 = "";
            string qp2 = "";
            foreach (var item in props)
            {
                var name = item.Name;
                if (!name.ToLower().Contains("id"))
                {
                    qp1 += name + ",";
                    qp2 += $"{name} = @{name},";
                }
            }
            qp1 = qp1.Remove(qp1.Length - 1);
            qp2 = qp2.Remove(qp2.Length - 1);
            return $"Update {TableName} Set {qp2} where Id = @Id";
        }


    }
}
