using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIMarcaAutos.Config;
using WebAPIMarcaAutos.Models;
using WebAPIMarcaAutos.Services;

namespace WebAPIMarcaAutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {
        private readonly IMarcasAutosService _marcasAutosService;

        public MarcasAutosController(IMarcasAutosService marcasAutosService)
        {
            _marcasAutosService = marcasAutosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcasAutos>>> GetMarcasAutos()
        {
            var marcasAutos = await _marcasAutosService.GetAllMarcasAutos();    
            return Ok(marcasAutos);
        }
    }
}
