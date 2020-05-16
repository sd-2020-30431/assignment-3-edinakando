using System.Collections.Generic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;

namespace WastelessAPI.Commands
{
    public class EditGroceryCommand : IRequest<EmptyResult>
    {
        public IList<GroceryItem> Groceries { get; set; }
    }
}