using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {

        private readonly PruebaContext _context;

        public BrandController(PruebaContext context)
        {
            _context = context; //Parte de inyeccion de dependencia, permite entrar a BD
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync()); //listea las brands de la BD
        }
    }
}
