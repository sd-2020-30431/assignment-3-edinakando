using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Commands;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;
using EmptyResult = WastelessAPI.Mediator.EmptyResult;

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

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody]Groceries groceries)
        {
            await _mediator.Handle<SaveGroceriesCommand, EmptyResult>(new SaveGroceriesCommand { Groceries = groceries });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Index(Int32 userId)
        {
            return new JsonResult(await _mediator.Handle<GetGroceriesQuery, IList<Groceries>>(new GetGroceriesQuery { UserId = userId}));
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody]IList<GroceryItem> groceries)
        {
            await _mediator.Handle<EditGroceryCommand, EmptyResult>(new EditGroceryCommand { Groceries = groceries });
         //   _groceriesLogic.Edit(groceries);
            return Ok();
        }
    }
}