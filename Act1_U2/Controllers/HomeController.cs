using Act1_U2.Models;
using Act1_U2.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                NombreClase = x.Nombre ?? ""
            });

            return View(d);
        }


        public IActionResult Especies(string Id)
        {

            ZooplanetContext context = new();
            EspeciesViewModel vm = new();
            //var d = context.Especies.Include(x => x.ClaseNavigation).OrderBy(x => x.Especie).Select(x => new EspeciesViewModel
            //{
            //    NombreClase = x.ClaseNavigation.Nombre,
            //    NombreEspecie = x.Especie,
            //    IdClase = x.ClaseNavigation.Idclase
            //}).Where(x => x.NombreClase == Id);


            var d = context.Especies.Include(x => x.ClaseNavigation).OrderBy(x => x.Especie).Where(x => x.ClaseNavigation.Nombre == Id);

            vm.Especies = d.Select(x => new EspecieModel
            {
                Nombre = x.Especie
            });

            return View(vm);
        }
    }
}
