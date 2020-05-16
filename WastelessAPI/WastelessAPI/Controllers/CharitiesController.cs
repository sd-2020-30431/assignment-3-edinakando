using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharitiesController : ControllerBase
    {
        private IMediator _mediator;

        public CharitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _mediator.Handle<GetCharitiesQuery, IList<Charity>>(new GetCharitiesQuery()));
        }

        //[HttpPost]
        //[Route("donate")]
        //public IActionResult Donate([FromBody]Donation donation)
        //{
        //    _charitiesLogic.Donate(donation);
        //    return Ok();
        //}
    }
}