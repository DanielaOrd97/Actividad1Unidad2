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
            var datos = context.Clase.Include(x => x.Especies).FirstOrDefault(x => x.Nombre == Id);

            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ClasesViewModel vm = new()
                {
                    IdClase = datos.Id,
                    NombreClase = datos.Nombre ?? "No disponible",
                    Especies = datos.Especies.Select(x => new EspecieModel
                    {
                        IdEspecie = x.Id,
                        Nombre = x.Especie
                    })
                };
                return View(vm);
            }

        }

        public IActionResult Especie(string Id)
        {
            Id = Id.Replace("-", " ");

            AnimalesContext context = new();

            var datos = context.Especies.Include(x => x.IdClaseNavigation).Where(x => x.Especie == Id).FirstOrDefault();

            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                EspecieIndividualViewModel vm = new()
                {
                    Id = datos.Id,
                    Nombre = datos.Especie,
                    NombreClase = datos.IdClaseNavigation.Nombre,
                    Peso = datos.Peso,
                    Tamaño = datos.Tamaño,
                    Habitat = datos.Habitat ?? "No disponible",
                    Descripcion = datos.Observaciones ?? "No disponible"

                };

                return View(vm);
            }
            
        }
    }
}
