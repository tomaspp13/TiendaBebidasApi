using Aplication.Commands.BebidaCommands.EliminarBebida;
using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Moq;


namespace XUnit.Aplication.BebidasTest
{
    public class EliminarBebidaTest
    {
        private readonly Mock<IBebidaRepository> _bebidaRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EliminarBebidaHandler _handlerBebida;
        public EliminarBebidaTest() 
        {
            _bebidaRepositoryMock = new Mock<IBebidaRepository>();
            _mapperMock = new Mock<IMapper>();
            _handlerBebida = new EliminarBebidaHandler(_bebidaRepositoryMock.Object,_mapperMock.Object);
        }

        [Fact]
        public async Task EliminarBebida_BebidaEncontrada_Exito()
        {

            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";
            var precio = new Precio(valor, moneda);

            var command = new EliminarBebidaCommand(nombre);
            var bebida = new Bebida(nombre, cantidad, precio);

            _bebidaRepositoryMock.Setup(b=>b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync(bebida);

            await _handlerBebida.Handle(command,CancellationToken.None);

            _bebidaRepositoryMock.Verify(b=>b.EliminarBebidaAsync(It.IsAny<Bebida>()),Times.Once);
        }

        [Fact]
        public async Task EliminarBebida_BebidaNoEncontrada_LanzaExcepcion()
        {

            string nombre = "Pepsi";
            int cantidad = 2;
            float valor = 100.0f;
            string moneda = "Pesos";

            var command = new EliminarBebidaCommand(nombre);

            _bebidaRepositoryMock.Setup(b => b.BuscarBebidaPorNombreAsync(nombre)).ReturnsAsync((Bebida)null);

            Assert.ThrowsAsync<InvalidBebidaException.BebidaNoEncontradaException>(async () =>
            {
                await _handlerBebida.Handle(command, CancellationToken.None);
            });

            _bebidaRepositoryMock.Verify(b => b.EliminarBebidaAsync(It.IsAny<Bebida>()), Times.Never);
        }
    }
}
