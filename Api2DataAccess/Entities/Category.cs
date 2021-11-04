using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2DataAccess.Entities
{
    public class Category 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
