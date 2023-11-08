using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniverCom.Domain.Entities;

namespace UniverCom.MediatR.Areas.Admin.CreateUser
{
    public class AdminCreateUserRequestHandler : IRequestHandler<AdminCreateUserRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _mapper;

        public AdminCreateUserRequestHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AdminCreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user is not null)
                return new BadRequestObjectResult(new { error = "Username taken"});

            var role = _roleManager.Roles.FirstOrDefault(r => r.NormalizedName == request.RoleName.ToUpper());
            if (role is null)
                return new BadRequestObjectResult(new { error = "Role not exist"} );

            user = new AppUser()
            {
                UserName = request.Username,
                Firstname = request.FirstName,
                Lastname = request.LastName,
                Fathername = request.Fathername,
            };

            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, role.Name);

            var userViewModel = _mapper.Map<AppUser>(user);

            return new OkObjectResult(userViewModel);
        }
    }
}
