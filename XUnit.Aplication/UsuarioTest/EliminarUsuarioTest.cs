using Aplication.Commands.UsuarioCommands.EliminarUsuario;
using Aplication.Exceptions;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Moq;

namespace XUnit.Aplication.UsuarioTest
{
    public class EliminarUsuarioTest
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly EliminarUsuarioHandler _handlerEliminar;
        public EliminarUsuarioTest()
        {
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _handlerEliminar = new EliminarUsuarioHandler(_usuarioRepository.Object);
        }

        [Fact]
        public async Task EliminarUsuario_UsuarioEncontrado_Exito()
        {
            Guid Id = new Guid("b8d4b0e6-9d7f-4d41-9b0b-5a8f3c7e1f92");
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#";

            var nombreCompleto = new NombreCompleto(nombre, apellido);
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var usuario = new Usuario(nombreCompleto, emailUsuario, contraseñaUsuario);
            var command = new EliminarUsuarioCommand(Id);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync(usuario);

            await _handlerEliminar.Handle(command, CancellationToken.None);

            _usuarioRepository.Verify(u => u.EliminarUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public async Task EliminarUsuario_UsuarioNoEncontrado_LanzaExcepcion()
        {
            Guid Id = new Guid("b8d4b0e6-9d7f-4d41-9b0b-5a8f3c7e1f92");
            string email = "pedro@gmail.com";

            var command = new EliminarUsuarioCommand(Id);

            _usuarioRepository.Setup(u => u.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync((Usuario)null);

            Assert.ThrowsAsync<InvalidUsuarioException.UsuarioNoEncontradoPorMail>(async () =>
            {
                await _handlerEliminar.Handle(command,CancellationToken.None);
            });

            _usuarioRepository.Verify(u => u.EliminarUsuarioAsync(It.IsAny<Usuario>()), Times.Never());
        }
    }
}
