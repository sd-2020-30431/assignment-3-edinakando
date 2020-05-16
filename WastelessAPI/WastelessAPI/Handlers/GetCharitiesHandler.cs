using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Handlers
{
    public class GetCharitiesHandler : IRequestHandler<GetCharitiesQuery, IList<Charity>>
    {
        private CharitiesLogic _charitiesLogic;

        public GetCharitiesHandler(CharitiesLogic charitiesLogic)
        {
            _charitiesLogic = charitiesLogic;
        }

        public async Task<IList<Charity>> Handle(GetCharitiesQuery request)
        {
            return await _charitiesLogic.GetCharities();
        }
    }
}