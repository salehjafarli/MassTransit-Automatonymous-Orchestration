using Automatonymous;
using Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.StateMachines
{
    public class Order : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State State { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public CardDetails CardDetails { get; set; }
    }
}
