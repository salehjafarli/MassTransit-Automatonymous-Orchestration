using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Helpers
{
    public static class DapperCustomMap
    {
        public static void SetFor<T>(string prefix = null)
        {
            if (prefix == null) prefix = typeof(T).Name + "_";
            var typeMap = new CustomPropertyTypeMap(typeof(T), (type, name) =>
            {
                if (name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) 
                {
                    name = name.Substring(prefix.Length);
                    var c = (char)((int)name[0] - 32);
                    name = c + name[1..];
                }

                return type.GetProperty(name);
            }); 
            SqlMapper.SetTypeMap(typeof(T), typeMap);
        }
    }
}
