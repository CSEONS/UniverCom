using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniverCom.MediatR.Areas.Admin;
using UniverCom.MediatR.Areas.Admin.CreateUser;
using UniverCom.MediatR.Areas.Admin.SignIn;

namespace UniverCom.Areas.Admin
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("Admin/Account")]
    [Authorize]
    public class AdminAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int start, [FromQuery] int count)
        {
            AdminGetUsersRequest request = new()
            {
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AdminCreateUserRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AdminSignInRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
