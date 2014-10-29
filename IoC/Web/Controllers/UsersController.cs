using System.Web.Mvc;
using Domain;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var user = _userService.GetUser(HttpContext.User.Identity);

            _userService.LogUser("normalny log");

            return View(user);
        }
    }
}