using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PORTIMAGES.Web.Controllers.User
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
