using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;

namespace WastelessAPI.Commands
{
    public class SaveGroceriesCommand : IRequest<EmptyResult>
    {
        public Groceries Groceries { get; set; }
    }
}