using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Commands
{
    public class DonateCommand : IRequest<EmptyResult>
    {
        public Donation Donation { get; set; }
    }
}