using Aplication.Commands.UsuarioCommands.CrearUsuario;
using Aplication.Commands.UsuarioCommands.EliminarUsuario;
using Aplication.Commands.UsuarioCommands.ModificarContraseñaUsuario;
using Aplication.Commands.UsuarioCommands.ModificarEmailUsuario;
using Aplication.Commands.UsuarioCommands.ModificarNombreUsuario;
using Aplication.Query.QueryUsuarios.ObtenerUsuarioPorEmail;
using Aplication.Query.QueryUsuarios.ObtenerUsuarioPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyectoEstudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {   
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator) { _mediator = mediator; }
       
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody]CrearUsuarioCommand request)
        {
            var usuario = await _mediator.Send(new CrearUsuarioCommand(request.Nombre,request.Apellido,request.Email,request.Contraseña));
            return Ok(usuario);
        }

        [HttpPut("ModificarEmailUsuario")]
        public async Task<IActionResult> ModificarEmailUsuario([FromBody] ModificarEmailUsuarioCommand request)
        {
            await _mediator.Send(new ModificarEmailUsuarioCommand(request.EmailViejo,request.EmailNuevo));
            return Ok();
        }
        [HttpPut("ModificarNombreYApellidoUsuario")]
        public async Task<IActionResult> ModificarNombreYApellidoUsuarioEditarUsuario([FromBody] ModificarNombreUsuarioCommand request)
        {
            await _mediator.Send(new ModificarNombreUsuarioCommand(request.Nombre,request.Email,request.Apellido));
            return Ok();
        }
        [HttpPut("ModificarContraseñaUsuario")]
        public async Task<IActionResult> ModificarContraseñaUsuario([FromBody] ModificarContraseñaUsuarioCommand request)
        {
            await _mediator.Send(new ModificarContraseñaUsuarioCommand(request.Contraseña,request.Email));
            return Ok();
        }


        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<IActionResult> EliminarUsuario(Guid id)
        {
            await _mediator.Send(new EliminarUsuarioCommand(id));
            return Ok();
        }


        [HttpGet("EncontrarUsuarioPorId/{id}")]
        public async Task<IActionResult> EncontrarUsuarioPorId(Guid id)
        {
            var usuario = await _mediator.Send(new ObtenerUsuarioPorIdQuery(id));
            return Ok(usuario);
        }
        [HttpGet("EncontrarUsuarioPorEmail/{email}")]
        public async Task<IActionResult> EncontrarUsuarioPorEmail(string email)
        {
            var usuario = await _mediator.Send(new ObtenerUsuarioPorEmailQuery(email));
            return Ok(usuario);
        }

    }
}
