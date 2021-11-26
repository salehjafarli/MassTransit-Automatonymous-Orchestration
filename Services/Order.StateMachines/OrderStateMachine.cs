using Automatonymous;
using Services.Common.Events.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.StateMachines
{
    public class OrderStateMachine : MassTransitStateMachine<Order>
    {
        public OrderStateMachine()
        {
            Event(() => OrderCreated,c => 
            {
                c.CorrelateById(x => x.Message.CorrelationId);
            });

            Initially(
                When(OrderCreated)
                .Then(context =>
                {
                    throw new Exception("test");
                })
                .TransitionTo(Registered)
                .Publish(x => new CheckProductAvailability())
            );

            During(Registered,
                When(OrderProductIsAvailable)
                .Then(context =>
                {

                })
                .TransitionTo(WaitForPruchase)
                .Publish(x => new PurchaseOrder()),
               When(OrderRejected)
                .Then(context =>
                {

                })
                .Finalize()
            );
            During(WaitForPruchase,
                When(OrderPurchased)
                .Then(context => 
                {

                })
                .Finalize()
            );

            SetCompletedWhenFinalized();
        }


        public State Registered { get; set; }
        public State WaitForPruchase { get; set; }
        public Event<OrderCreated> OrderCreated { get; set; }
        public Event<OrderProductIsAvailable> OrderProductIsAvailable { get; set; }
        public Event<OrderPurchased> OrderPurchased { get; set; }
        public Event<OrderRejected> OrderRejected { get; set; }
    }
}
