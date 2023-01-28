using ApiRest.Aplicacion;
using ApiRest.Entidades;
using ApiRest.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Equipos : ControllerBase
    {
        private readonly IAplicacion<Equipo> _equipos;

        public Equipos(IAplicacion<Equipo> equipos)
        {
            _equipos = equipos;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_equipos.GetAll());

        }

        [HttpPost]
        public IActionResult Save(EquipoDTO equipo)
        {
            var club = new Equipo()
            {
                Nombre = equipo.Nombre,
                Puntos = equipo.Puntos,
            };
            return Ok(_equipos.Save(club));
        }
    }
}
