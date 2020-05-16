using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Commands;
using WastelessAPI.Mediator;

namespace WastelessAPI.Handlers
{
    public class EditGroceryHandler : IRequestHandler<EditGroceryCommand, EmptyResult>
    {
        private GroceriesLogic _groceriesLogic;
        public EditGroceryHandler(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        public async Task<EmptyResult> Handle(EditGroceryCommand request)
        {
            await _groceriesLogic.Edit(request.Groceries);
            return new EmptyResult();
        }
    }
}