using Act1_U2.Models;
using Act1_U2.Models.Entities;
using Act1_U2.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Act1_U2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new();

            var d = context.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Id = x.Id,
                NombreClase = x.Nombre ?? ""
            });

            return View(d);
        }


        public IActionResult Especies(string Id)
        {

            AnimalesContext context = new();
            // EspeciesViewModel vm = new();


            var d = context.Especies.Include(x => x.IdClaseNavigation).OrderBy(x => x.Especie).Where(x => x.IdClaseNavigation.Nombre == Id).Select(x => new EspeciesViewModel
            {
                IdClase = x.IdClaseNavigation.Id,
                NombreClase = x.IdClaseNavigation.Nombre,
                NombreEspecie = x.Especie,
                Especies1 = x.
            });

            //vm.Especies = d.Select(x => new EspecieModel
            //{
            //    Nombre = x.Especie
            //});


            ////////////////////////////


          

            return View(d);
        }

        public IActionResult EspecieIndivudual(string Id)
        {

            //AnimalesContext context = new();
            //EspecieIndividualViewModel vm = new();

            //var d = context.Especies.Include(x => x.IdClaseNavigation).Select(x => new EspecieIndividualViewModel
            //{
            //    Nombre = x.Especie,
            //    NombreClase = x.IdClaseNavigation.Nombre,
            //    Peso = x.Peso,
            //    Tamaño = x.Tamaño,
            //    Habitat = x.Habitat,
            //    Descripcion = x.Observaciones
            //}).Where(x => x.Nombre == Id);

            return View();
        }
    }
}
