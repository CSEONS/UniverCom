using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniverCom.Domain.Entities;
using UniverCom.Service;

namespace UniverCom.MediatR.Areas.Admin.SignIn
{
    public class AdminSignInRequestHandler : IRequestHandler<AdminSignInRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AdminSignInRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<IActionResult> Handle(AdminSignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user is null)
                return new BadRequestObjectResult(new { error = "User not found." });

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (signInResult.Succeeded is false)
                return new BadRequestObjectResult("Invalid password");

            var tokens = new 
            { 
                AccessToken = _jwtGenerator.Generate(user, TimeSpan.FromMinutes(Config.AccesTokenExpiredTimePerMinute)),
                RefreshToken = _jwtGenerator.Generate(user, TimeSpan.FromDays(Config.RefreshTokenExpiredTimePerDays)),
            };

            return new OkObjectResult(tokens);
        }
    }
}
