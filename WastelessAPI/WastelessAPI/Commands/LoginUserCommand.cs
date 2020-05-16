using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Commands
{
    public class LoginUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}