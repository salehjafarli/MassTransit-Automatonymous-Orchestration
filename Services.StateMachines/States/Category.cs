using Automatonymous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StateMachines.States
{
    public class Category : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State State { get; set; }

    }
}
