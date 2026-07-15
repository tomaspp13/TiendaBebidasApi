using Aplication.Commands.UsuarioCommands.ModificarContraseñaUsuario;
using Aplication.Commands.UsuarioCommands.ModificarEmailUsuario;
using Aplication.Commands.UsuarioCommands.ModificarNombreUsuario;
using Aplication.Exceptions;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Moq;

namespace XUnit.Aplication.UsuarioTest
{
    public class ModificarUsuarioTest
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly ModificarContraseñaUsuarioHandler _handlerContraseña;
        private readonly ModificarEmailUsuarioHandler _handlerEmail;
        private readonly ModificarNombreUsuarioHandler _handlerNombre;
        public ModificarUsuarioTest()
        {
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _handlerContraseña = new ModificarContraseñaUsuarioHandler(_usuarioRepository.Object);
            _handlerEmail = new ModificarEmailUsuarioHandler(_usuarioRepository.Object);
            _handlerNombre = new ModificarNombreUsuarioHandler(_usuarioRepository.Object);
        }

        [Fact]
        public async Task ModificarContraseña_UsuarioEncontrado_Exito()
        {
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#";

            var nombreCompleto = new NombreCompleto(nombre, apellido);
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var usuario = new Usuario(nombreCompleto, emailUsuario, contraseñaUsuario);
            var command = new ModificarContraseñaUsuarioCommand(contraseña, email);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync(usuario);

            await _handlerContraseña.Handle(command, CancellationToken.None);

            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public async Task ModificarContraseña_UsuarioNoEncontrado_LanzaExcepcion()
        {

            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#";
  
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var command = new ModificarContraseñaUsuarioCommand(contraseña, email);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync((Usuario)null);

            Assert.ThrowsAsync<InvalidUsuarioException.UsuarioNoEncontradoPorMail>( async () => {

                await _handlerContraseña.Handle(command, CancellationToken.None);

            });

            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Never());
        }

        [Fact]
        public async Task ModificarEmail_UsuarioEncontrado_Exito()
        {
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#";
            string emailNuevo = "juan@gmail.com";

            var nombreCompleto = new NombreCompleto(nombre, apellido);
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var usuario = new Usuario(nombreCompleto, emailUsuario, contraseñaUsuario);
            var command = new ModificarEmailUsuarioCommand(email, emailNuevo);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync(usuario);

            await _handlerEmail.Handle(command, CancellationToken.None);

            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public async Task ModificarEmail_UsuarioNoEncontrado_LanzaExcepcion()
        {

            string email = "pedro@gmail.com";
            string emailNuevo = "juan@gmail.com";

            var command = new ModificarEmailUsuarioCommand(email, emailNuevo);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync((Usuario)null);

            Assert.ThrowsAsync<InvalidUsuarioException.UsuarioNoEncontradoPorMail>(async () =>
            {
                await _handlerEmail.Handle(command,CancellationToken.None);
            });

            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Never());
        }

        [Fact]
        public async Task ModificarNombreCompleto_UsuarioEncontrado_Exito()
        {
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#"; 
            string nombreNuevo = "Juan";
            string apellidoNuevo = "Rodriguez";

            var nombreCompleto = new NombreCompleto(nombre, apellido);
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var usuario = new Usuario(nombreCompleto, emailUsuario, contraseñaUsuario);
            var command = new ModificarNombreUsuarioCommand(nombreNuevo,email, apellidoNuevo);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync(usuario);

            await _handlerNombre.Handle(command, CancellationToken.None);

            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public async Task ModificarNombreCompleto_UsuarioNoEncontrado_LanzaExcepcion()
        {
            string email = "pedro@gmail.com";
            string nombreNuevo = "Juan";
            string apellidoNuevo = "Rodriguez";

            var command = new ModificarNombreUsuarioCommand(nombreNuevo, email, apellidoNuevo);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync((Usuario)null);

            Assert.ThrowsAsync<InvalidUsuarioException.UsuarioNoEncontradoPorMail>( async () =>
            {
                await _handlerNombre.Handle(command, CancellationToken.None);
            });
            
            _usuarioRepository.Verify(u => u.EditarUsuarioAsync(It.IsAny<Usuario>()), Times.Never());
        }
    }
}
