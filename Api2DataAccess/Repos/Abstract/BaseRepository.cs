using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Repos.Abstract
{
    public abstract class BaseRepository
    {
        public BaseRepository(string ConString, string TableName)
        {
            this.ConString = ConString;
            this.TableName = TableName;
        }

        public string ConString { get; }
        public string TableName { get; }

        public string GetByIdQuery => $"{Get} where Id = @Id";

        public string Get => $"Select * From {TableName}";
        public string DeleteCommand => $"Delete from {TableName} where Id = @Id";

        public string InsertCommand(Type entitype)
        {
            var props = entitype.GetProperties();
            string qp1 = "";
            string qp2 = "";
            foreach (var item in props)
            {
                var name = item.Name;
                if (name.ToLower() != "id")
                {
                    qp1 += name + ",";
                    qp2 += "@"+name + ",";
                }
            }
            qp1 = qp1.Remove(qp1.Length - 1);
            qp2 = qp2.Remove(qp2.Length - 1);
            return $"Insert into {TableName}({qp1}) values({qp2})";
        }
        public string UpdateCommand(Type entitype)
        {
            var props = entitype.GetProperties();
            string qp1 = "";
            string qp2 = "";
            foreach (var item in props)
            {
                var name = item.Name;
                if (name.ToLower() != "id")
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
