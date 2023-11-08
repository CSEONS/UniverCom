using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniverCom.MediatR.Areas.Admin.SignIn
{
    public class AdminSignInRequest : IRequest<IActionResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
