using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Commands;
using WastelessAPI.Mediator;

namespace WastelessAPI.Handlers
{
    public class DonateHandler : IRequestHandler<DonateCommand, EmptyResult>
    {
        private CharitiesLogic _charitiesLogic;
        public DonateHandler(CharitiesLogic charitiesLogic)
        {
            _charitiesLogic = charitiesLogic;
        }
       
        public async Task<EmptyResult> Handle(DonateCommand request)
        {
            await _charitiesLogic.Donate(request.Donation);
            return new EmptyResult();
        }
    }
}
