using MassTransit;
using MediatR;
using Nelibur.ObjectMapper;
using OrderService.Core.Commands;
using Services.Common.Events.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Core.CommandHandlers
{
    public class OrderCommandHandler : IRequestHandler<MakeOrderCommand, bool>
    {
        public OrderCommandHandler(IMediator Mediator,IBusControl Bus)
        {
            TinyMapper.Bind<MakeOrderCommand,OrderCreated>();
            this.Bus = Bus;
        }

        public IBusControl Bus { get; }

        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            OrderCreated @event = TinyMapper.Map<OrderCreated>(request);
            await Bus.Publish(@event);
            return true;
        }
    }
}
