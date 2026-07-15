using Aplication.Commands.BebidaCommands.ModificarBebida;
using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Moq;


namespace XUnit.Aplication.BebidasTest
{
    public class ModificarBebidaTest
    {
        private readonly Mock<IBebidaRepository> _bebidaRepositoryMock;
        private readonly ModificarBebidaHandler _handlerBebida;
        private readonly Mock<IMapper> _mapperMock;

        public ModificarBebidaTest()
        {
            _bebidaRepositoryMock = new Mock<IBebidaRepository>();
            _mapperMock = new Mock<IMapper>();
            _handlerBebida = new ModificarBebidaHandler(_bebidaRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ModificarBebida_BebidaEncontrada_Exito()
        {
            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";
            var precio = new Precio(valor, moneda);

            var command = new ModificarBebidaCommand(nombre, cantidad, valor, moneda);
            var bebida = new Bebida(nombre, cantidad, precio);

            _bebidaRepositoryMock.Setup(b => b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync(bebida);

            await _handlerBebida.Handle(command,CancellationToken.None);

            _bebidaRepositoryMock.Verify(b => b.ModificarBebidaAsync(It.IsAny <Bebida>()),Times.Once);
        }

        [Fact]
        public async Task ModificarBebida_BebidaNoEncontrada_LanzaExcepcion()
        {
            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";

            var command = new ModificarBebidaCommand(nombre, cantidad, valor, moneda);

            _bebidaRepositoryMock.Setup(b => b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync((Bebida)null);

            Assert.ThrowsAsync<InvalidBebidaException.BebidaNoEncontradaException>(async() =>
            {
                await _handlerBebida.Handle(command, CancellationToken.None);
            });

            _bebidaRepositoryMock.Verify(b => b.ModificarBebidaAsync(It.IsAny<Bebida>()), Times.Never);
        }
    }
}
