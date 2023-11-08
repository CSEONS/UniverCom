using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniverCom.Domain.Entities;
using UniverCom.Models;

namespace UniverCom.MediatR.Areas.Admin
{
    public class AdminGetUsersRequestHandler : IRequestHandler<AdminGetUsersRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminGetUsersRequestHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AdminGetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.Skip(request.Start).Take(request.Count);

            var usersViewModel = users.ProjectTo<AppUserViewModel>(_mapper.ConfigurationProvider);

            return new OkObjectResult(usersViewModel);
        }
    }
}
