using Automatonymous;
using Services.Common.Events.Category;
using Services.StateMachines.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StateMachines.StateMachines
{
    public class CategoryStateMachine : MassTransitStateMachine<Category>
    {
        public CategoryStateMachine()
        {
            Initially(
                When(CategoryCreated)
                .Then(context =>
                    throw new Exception("category created")
                )
            ); 
        }






        public Event<CategoryCreated> CategoryCreated { get; set; }
        public Event<CategoryUpdated> CategoryUpdated { get; set; }
        public Event<CategoryDeleted> CategoryDeleted { get; set; }



    }
}
