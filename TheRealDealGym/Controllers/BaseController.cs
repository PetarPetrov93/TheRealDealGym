using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// This is a BaseController which implements some common configurations for all controllers.
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
