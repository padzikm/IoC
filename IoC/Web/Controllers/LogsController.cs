using System.Web.Mvc;
using Domain;

namespace Web.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _logRepository;
        private readonly IUserService _userService;

        public LogsController(ILogRepository logRepository, IUserService userService)
        {
            _logRepository = logRepository;
            _userService = userService;
        }

        public ActionResult Index()
        {
            var logs = _logRepository.GetAll();

            return View(logs);
        }

        public ActionResult Add()
        {
            var msg = "inny log";
            var conf = new LogConfiguration() { Format = "metodowy log: {0}" };

            _userService.LogUser(msg, conf);

            return View((object)string.Format(conf.Format, msg));
        }
    }
}