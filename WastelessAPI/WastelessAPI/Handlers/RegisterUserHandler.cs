using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Commands;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private UserLogic _userLogic;

        public RegisterUserHandler(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public async Task<User> Handle(RegisterUserCommand request)
        {
            return await _userLogic.InsertNewUser(request.User);
        }
    }
}