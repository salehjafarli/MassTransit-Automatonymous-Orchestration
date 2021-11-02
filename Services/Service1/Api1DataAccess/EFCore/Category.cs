using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Api1DataAccess.EFCore
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Product> Products { get; set; }
    }
}
