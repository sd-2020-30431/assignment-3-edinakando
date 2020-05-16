using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Commands;
using WastelessAPI.Mediator;

namespace WastelessAPI.Handlers
{
    public class SaveGroceriesHandler : IRequestHandler<SaveGroceriesCommand, EmptyResult>
    {
        private GroceriesLogic _groceriesLogic;
        public SaveGroceriesHandler(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        public async Task<EmptyResult> Handle(SaveGroceriesCommand request)
        {
            await _groceriesLogic.Save(request.Groceries);
            return new EmptyResult();
        }
    }
}
