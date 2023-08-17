using Microsoft.AspNetCore.Mvc;

namespace Participant_Panel.UI.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
