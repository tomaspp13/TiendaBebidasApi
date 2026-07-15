using Aplication.Commands.BebidaCommands.CrearBebida;
using Aplication.Commands.BebidaCommands.ModificarBebida;
using Aplication.Commands.BebidaCommands.EliminarBebida;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplication.Query.QueryBebidas.ObtenerBebidas;

namespace ApiProyectoEstudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {        

        private readonly IMediator _mediatR;

        public BebidaController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("CrearBebida")]
        public async Task<IActionResult> CrearBebida([FromBody] CrearBebidaCommand request)
        {
            var bebida = await _mediatR.Send(new CrearBebidaCommand(request.Nombre, request.Cantidad,request.Precio,request.Moneda));
            return Ok(bebida);           
        }

        [HttpPut("EditarBebida/{nombre}")]
        public async Task<IActionResult> EditarBebida(string nombre,[FromBody] ModificarBebidaCommand request)
        {
            await _mediatR.Send(new ModificarBebidaCommand(request.Nombre,request.Cantidad,request.Valor,request.Moneda,nombre));
            return Ok();
        }

        [HttpDelete ("ELiminarBebida/{nombre}")]
        public async Task<IActionResult> EliminarBebida(string nombre)
        {
            await _mediatR.Send(new EliminarBebidaCommand(nombre)); 
            return Ok();
        }

        [HttpGet("MostrarTodasLasBebidas")]
        public async Task<IActionResult> MostrarTodasLasBebidas() => Ok(await _mediatR.Send(new ObtenerBebidasQuery()));

    }
}
