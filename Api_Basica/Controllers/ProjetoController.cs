using Microsoft.AspNetCore.Mvc;

namespace Api_Basica.Controllers
{
    public class ProjetoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
