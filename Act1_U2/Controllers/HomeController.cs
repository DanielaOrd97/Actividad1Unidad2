using Act1_U2.Models;
using Act1_U2.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Act1_U2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ZooplanetContext context = new();

            var d = context.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Id = x.Idclase,
                Nombre = x.Nombre ?? ""
            });

            return View(d);
        }
    }
}
