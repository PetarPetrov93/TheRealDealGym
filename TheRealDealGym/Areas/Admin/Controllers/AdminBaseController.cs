using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TheRealDealGym.Core.Constants.RoleConstants;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
