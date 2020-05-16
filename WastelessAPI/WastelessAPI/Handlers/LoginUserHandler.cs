using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Commands;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, User>
    {
        private UserLogic _userLogic;

        public LoginUserHandler(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public async Task<User> Handle(LoginUserCommand request)
        {
            return await _userLogic.GetValidUser(request.User);
        }
    }
}
