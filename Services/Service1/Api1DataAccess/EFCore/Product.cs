using System;
using System.Collections.Generic;

#nullable disable

namespace Api1DataAccess.EFCore
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
