using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniverCom.MediatR.Areas.Admin
{
    public class AdminGetUsersRequest : IRequest<IActionResult>
    {
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
