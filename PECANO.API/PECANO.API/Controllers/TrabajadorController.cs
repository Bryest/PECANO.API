using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PECANO.API.Dto;
using PECANO.API.Models;
using PECANO.API.Service;

namespace PECANO.API.Controllers
{
  [ApiController]
    [Route("api/controller")]
    public class TrabajadorController:ControllerBase
    {
        private readonly TrabajadorService _trabajadorService;

        public TrabajadorController(TrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrabajadorDto>> GetTrabajadores()
        {
            return Ok(_trabajadorService.ObtenerTodos());
        }

        [HttpGet("{dni}")]
        public ActionResult<TrabajadorDto> GetTrabajador(string dni)
        {
            var trabajador = _trabajadorService.ObtenerPorDNI(dni);
            if (trabajador == null)
            {
                return NotFound();
            }
            return Ok(trabajador);
        }
    }

}
