using Domain.Entidades;
using Domain.ValueObjects;
using Xunit.Abstractions;

namespace XUnit.Domain
{
    public class BebidasTest
    {
        private readonly Precio _precio;
        private readonly ITestOutputHelper _output;
        public BebidasTest(ITestOutputHelper output)
        {
            _precio = new Precio(2000, "Pesos");
            _output = output;
        }

        [Fact]
        public void CrearBebida_DatosValidos_Exito()
        {
            string nombre = "Manaos";
            int cantidad = 1;

            var resultado = new Bebida(nombre, cantidad, _precio);

            Assert.NotNull(resultado);
        }

        [Theory]
        [InlineData("", 1)]         //nombre vacio
        [InlineData("Manaos", -1)]  //cantidad negativa
        [InlineData("", -2)]        //nombre y cantidad invalidos
        public void CrearBebida_DatosInvalidos_LanzaExcepcion(string nombre, int cantidad)
        {

            var ex = Assert.Throws<Exception>(() =>
            {
                new Bebida(nombre, cantidad, _precio);
            });

            _output.WriteLine(ex.Message);

        }

    }
}