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
                    context.Instance.ProductId = context.Data.ProductId;
                    context.Instance.CompanyId = context.Data.CompanyId;
                    context.Instance.CardDetails = context.Data.CardDetails;
                })
                .TransitionTo(Registered)
                .Publish(context => new CheckProductAvailability()
                {
                    CompanyId = context.Instance.CompanyId,
                    ProductId = context.Instance.ProductId
                })
            );

            During(Registered,
                When(OrderProductIsAvailable)
                .Then(context =>
                {
                })
                .TransitionTo(WaitForPurchase)
                .Publish(context => new PurchaseOrder() {CardDetails = context.Instance.CardDetails }),
               When(OrderRejected)
                .Then(context =>
                {
                       
                })
                .Finalize()
            );
            During(WaitForPurchase,
                When(OrderPurchased)
                .Then(context => 
                {

                })
                .Finalize()
            );

            SetCompletedWhenFinalized();
        }


        public State Registered { get; set; }
        public State WaitForPurchase { get; set; }
        public Event<OrderCreated> OrderCreated { get; set; }
        public Event<OrderProductIsAvailable> OrderProductIsAvailable { get; set; }
        public Event<OrderPurchased> OrderPurchased { get; set; }
        public Event<OrderRejected> OrderRejected { get; set; }
    }
}
