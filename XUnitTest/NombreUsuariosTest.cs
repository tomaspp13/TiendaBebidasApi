using Domain.ValueObjects;
using Xunit.Abstractions;

namespace XUnit.Domain;

public class NombreUsuariosTest
{
    private readonly ITestOutputHelper _output;
    public NombreUsuariosTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CrearNombreCompleto_DatosValidos_Exito()
    {
        string nombre = "Pedro";
        string apellido = "Sandoval";

        Assert.NotNull(() => { new NombreCompleto(nombre,apellido); });
    }

    [Theory]
    [InlineData("Pedro","")]      //apellido vacio
    [InlineData("", "Sandoval")] //nombre vacio
    [InlineData("", "")]         //apellido y nombre vacio
    public void CrearNombreCompleto_DatosInvalidos_LanzaExcepcion(string nombre, string apellido)
    {
        var ex = Assert.Throws<Exception>(() =>
        {
            new NombreCompleto(nombre,apellido);
        });

        _output.WriteLine(ex.Message);

    }
}
