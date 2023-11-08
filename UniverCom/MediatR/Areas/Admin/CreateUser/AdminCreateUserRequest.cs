using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniverCom.MediatR.Areas.Admin.CreateUser
{
    public class AdminCreateUserRequest : IRequest<IActionResult>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
