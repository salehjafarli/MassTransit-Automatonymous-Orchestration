using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models
{
    public class CardDetails
    {
        public string Number { get; set; }
        public byte ExpMonth { get; set; }
        public byte ExpYear { get; set; }
        public string CardName { get; set; }
        public byte CVV { get; set; }
    }
}
