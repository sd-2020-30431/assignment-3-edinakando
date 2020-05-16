using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("Expiration")]
        [HttpGet]
        public async Task<IActionResult> GetExpirationNotification(Int32 userId)
        {
            return new JsonResult(await _mediator.Handle<GetNotificationQuery, IList<GroceryItem>>(new GetNotificationQuery { UserId = userId }));
        }
    }
}
