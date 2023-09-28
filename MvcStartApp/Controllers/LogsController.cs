using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Repository;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private ILoggingRepository _loggerRepository;

        public LogsController(ILoggingRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _loggerRepository.GetRequests();
            return View(requests);
        }
    }
}
