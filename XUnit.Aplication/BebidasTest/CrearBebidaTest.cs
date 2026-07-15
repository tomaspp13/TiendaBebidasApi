using Aplication.Commands.BebidaCommands.CrearBebida;
using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Moq;

namespace XUnit.Aplication.BebidasTest
{
    public class CrearBebidaTest
    {
        private readonly Mock <IBebidaRepository> _bebidaRepositoryMock;
        private readonly Mock <IMapper> _mapperMock;
        private readonly CrearBebidaHandler _handlerBebida;
        public CrearBebidaTest()
        {
            _mapperMock = new Mock<IMapper>();
            _bebidaRepositoryMock = new Mock<IBebidaRepository>();
            _handlerBebida = new CrearBebidaHandler(_mapperMock.Object, _bebidaRepositoryMock.Object);
        }

        [Fact]
        public async Task CrearBebida_BebidaNoExiste_Exito()
        {
            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";
            var precio = new Precio(valor, moneda);

            var command = new CrearBebidaCommand(nombre, cantidad, valor, moneda);
            var bebida = new Bebida(nombre,cantidad,precio);
            var response = new CrearBebidaResponse(new Guid (),nombre,cantidad,valor,moneda);

            _bebidaRepositoryMock.Setup(b => b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync((Bebida)null);

            _mapperMock.Setup(m=>m.Map<Bebida>(command)).Returns(bebida);

            _mapperMock.Setup( m=>m.Map<CrearBebidaResponse>(bebida)).Returns(response);

            Assert.NotNull(await _handlerBebida.Handle(command, CancellationToken.None));
            _bebidaRepositoryMock.Verify( b => b.CrearBebidaAsync( It.IsAny<Bebida>()), Times.Once);
        }

        [Fact]
        public async Task CrearBebida_BebidaExiste_LanzaExcepcion()
        {
            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";
            var precio = new Precio(valor, moneda);

            var command = new CrearBebidaCommand(nombre, cantidad, valor, moneda);
            var bebida = new Bebida(nombre, cantidad, precio);

            _bebidaRepositoryMock.Setup(b => b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync(bebida);

            Assert.ThrowsAsync<InvalidBebidaException.BebidaEncontradaException>(async() =>
            {
                await _handlerBebida.Handle(command, CancellationToken.None);
            });

            _bebidaRepositoryMock.Verify(b => b.CrearBebidaAsync(It.IsAny<Bebida>()), Times.Never);
        }
    }
}
