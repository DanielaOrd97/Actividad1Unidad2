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

            ClasesViewModel vm = new();


            //vm.Especies = d.Select(x => new EspecieModel
            //{
            //    Nombre = x.Especie
            //});


            ////////////////////////////
            //var datos = context.Clase.Include(x => x.Especies).ThenInclude(x => x.IdClaseNavigation).Select(x => new ClasesViewModel
            //{
            //    IdClase = x.Id,
            //    NombreClase = x.Nombre,
            //    Especies = x.Especies.Select(x => new EspecieModel
            //    {
            //        IdEspecie = x.Id,
            //        Nombre = x.Especie
            //    })
            //}).Where(x => x.NombreClase == Id).FirstOrDefault();

            var datos = context.Clase.Include(x => x.Especies).ThenInclude(x => x.IdClaseNavigation).Select(x => new ClasesViewModel
            {
                IdClase = x.Id,
                NombreClase = x.Nombre ?? "No contiene un nombre",
                Especies = x.Especies.Select(x => new EspecieModel
                {
                    IdEspecie = x.Id,
                    Nombre = x.Especie
                })
            }).FirstOrDefault(x => x.NombreClase == Id);


            return View(datos);
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
