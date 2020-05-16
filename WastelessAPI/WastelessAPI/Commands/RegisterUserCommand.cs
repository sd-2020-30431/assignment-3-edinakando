using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
