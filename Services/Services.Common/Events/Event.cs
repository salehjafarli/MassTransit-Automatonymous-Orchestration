using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Events
{
    public abstract class Event
    {
        public Guid CorrelationId => Guid.NewGuid();
    }
}
