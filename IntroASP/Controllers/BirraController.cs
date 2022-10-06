using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BirraController : Controller
    {

        private readonly PruebaContext _context;

        public BirraController(PruebaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beer = _context.Birras.Include(b => b.Brand); // en beer incluye todo el contexto (las birras de BD)
            return View(await beer.ToListAsync());            //e incluye la referencia a table brand que tiene la table birras  
        }

        //GET
        public IActionResult Create() //inserta en BD, no necesita ser async
        {
            //ViewData es un diccionario, se puede acceder desde la vista y no llega como controlador
            //es como hacer un select              origen , se busca por id, devuelve name   
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        //public  IActionResult Create() //inserta en BD, no necesita ser async
        //{ //asi se hacen consultas especificas (para realizar verificaciones etc)
        //    var res =  _context.Birras.Where(x=>x.Name =="Pilsen");
        //    return Json(res);
        //}

        //FALTA VER COMO VERIFICAR LO QUE ESCRIBE USUARIO, para hacer un tipo LOGIN,
        // verificar password escrita con pass en BD

        [HttpPost]
        [ValidateAntiForgeryToken] //valida que no llegue info de otro sitio y solo del formulario correspondiente, seguridad
        public async Task<IActionResult> Create(BirraViewModel model) //inserta en BD, no necesita ser async
        {
            if (ModelState.IsValid) {
                //Entity Frameword
                var beer = new Birra() { 
                   Name = model.Name,
                   BrandId = model.BrandId,
                   BeerId = model.BeerId
                };
                //se añade a EF
                _context.Add(beer);
                //se modifica la BD hasta este punto
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //este return rederige al metodo Index de arriba
                // y hace el listado
                // y si no se hace exitosamente, hace lo de abajo y vuelve al create para llenar el formulario
            }

            //ViewData es un diccionario, se puede acceder desde la vista y no llega como controlador
            //es como hacer un select              origen , se busca por id, devuelve name , selecciona el brand id guardado del BirraViewModel selecionado anteriormente  
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name",model.BrandId);
            return View(model);
        } 


    }
}
