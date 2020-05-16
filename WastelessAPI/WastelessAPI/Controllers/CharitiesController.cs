using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Commands;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;
using EmptyResult = WastelessAPI.Mediator.EmptyResult;

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

        [HttpPost]
        [Route("donate")]
        public async Task<IActionResult> Donate([FromBody]Donation donation)
        {
            await _mediator.Handle<DonateCommand, EmptyResult>(new DonateCommand { Donation = donation }); 
            return Ok();
        }
    }
}