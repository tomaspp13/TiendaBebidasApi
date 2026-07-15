using Aplication.Commands.UsuarioCommands.CrearUsuario;
using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Microsoft.AspNet.Identity;
using Moq;


namespace XUnit.Aplication.UsuarioTest
{
    public class CrearUsuarioTest
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPasswordHasher> _hasherMock;
        private readonly CrearUsuarioHandler _handler;
        public CrearUsuarioTest()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _mapperMock = new Mock<IMapper>();
            _hasherMock = new Mock<IPasswordHasher>();
            _handler = new CrearUsuarioHandler(_repositoryMock.Object, _mapperMock.Object, _hasherMock.Object);           
        }
        [Fact]
        public async Task CrearUsuario_DatosNoCreado_Exito()
        {
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "pedro@gmail.com";
            string contraseña = "Pedro12345@#";

            var command = new CrearUsuarioCommand(nombre, apellido, email, contraseña);

            var nombreCompleto = new NombreCompleto(nombre, apellido);
            var emailUsuario = new Email(email);
            var contraseñaUsuario = new Contraseña(contraseña);

            var usuario = new Usuario(nombreCompleto,emailUsuario,contraseñaUsuario);

            var response = new CrearUsuarioResponse(Guid.NewGuid(), nombre,apellido, email,contraseña);

            _repositoryMock.Setup(r => r.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync((Usuario)null);

            _mapperMock.Setup(m => m.Map<Usuario>(command)).Returns(usuario);

            _hasherMock.Setup(h => h.HashPassword(contraseña)).Returns("Hasheado");

            _mapperMock.Setup(m => m.Map<CrearUsuarioResponse>(command)).Returns(response);

            Assert.NotNull( await _handler.Handle(command, CancellationToken.None));
            _repositoryMock.Verify(u => u.CrearUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public async Task CrearUsuario_DatosYaCreados_LanzaExcepcion()
        {
            string nombre = "Pedro";
            string apellido = "Sandoval";
            string email = "usuarioQueYaExiste@gmail.com";
            string contraseña = "Pedro12345@";

            var command = new CrearUsuarioCommand(nombre, apellido, email, contraseña);
            
            var nombrecompleto = new NombreCompleto(nombre, apellido);
            var contraseñaCompleta = new Contraseña(contraseña);
            var emailCompleto = new Email(email);
            var usuario = new Usuario(nombrecompleto, emailCompleto, contraseñaCompleta);

            _repositoryMock.Setup(r => r.BuscarUsuarioPorEmailAsync(email)).ReturnsAsync(usuario);

            await Assert.ThrowsAsync<InvalidUsuarioException.UsuarioNoEncontradoPorMail> (async () =>
            {
                await _handler.Handle(command, CancellationToken.None);
            });

            _repositoryMock.Verify(c => c.CrearUsuarioAsync(It.IsAny<Usuario>()), Times.Never);
        }
    }
}