using Microsoft.AspNetCore.Mvc;

namespace IBKS.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
