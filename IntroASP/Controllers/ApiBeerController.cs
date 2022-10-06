using IntroASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {

        private readonly PruebaContext _context;

        public ApiBeerController(PruebaContext context)
        {
            _context = context;
        }

        public async Task<List<Birra>> Get()
            => await _context.Birras.ToListAsync();

     
    }
}
