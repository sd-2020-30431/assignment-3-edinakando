using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private IMediator _mediator;

        public GroceriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("Save")]
        //public IActionResult Save([FromBody]Groceries groceries)
        //{
        //    _groceriesLogic.Save(groceries);
        //    return Ok();
        //}

        [HttpGet]
        public async Task<IActionResult> Index(Int32 userId)
        {
            return new JsonResult(await _mediator.Handle<GetGroceriesQuery, IList<Groceries>>(new GetGroceriesQuery { UserId = userId}));
        }

        //[HttpPost]
        //[Route("Edit")]
        //public IActionResult Edit([FromBody]IList<GroceryItem> groceries)
        //{
        //    _groceriesLogic.Edit(groceries);
        //    return Ok();
        //}
    }
}