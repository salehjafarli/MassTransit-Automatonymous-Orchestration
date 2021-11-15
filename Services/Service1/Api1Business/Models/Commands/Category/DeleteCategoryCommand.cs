using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Business.Models.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<bool>
    { 
        public string Name { get; set; }
    }
}
