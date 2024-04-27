using Microsoft.AspNetCore.Mvc;

namespace WebMarker.Controllers
{
    public class WorkspaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
