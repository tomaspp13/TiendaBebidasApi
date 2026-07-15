using Domain.ValueObjects;
using Xunit.Abstractions;

namespace XUnit.Domain;

public class ContraseñaTest
{
    private readonly ITestOutputHelper _output;
    public ContraseñaTest(ITestOutputHelper output)
    {
        _output = output;
    }
    [Fact]
    public void CrearContraseña_DatosValidos_Exito()
    {
        string contraseña = "Pedro12345@";
        Assert.NotNull(new Contraseña(contraseña));
    }

    [Theory]
    [InlineData("")]          // vacía
    [InlineData("pedro")]     // solo minúsculas, sin mayúscula, número ni especial
    [InlineData("pedro123")]  // minúsculas y números, sin mayúscula ni especial
    [InlineData("pedro@")]    // minúsculas y especial, sin mayúscula ni número
    [InlineData("pedroP")]    // minúsculas y mayúscula, sin número ni especial
    [InlineData("pedroP@")]   // minúsculas, mayúscula y especial, sin número
    [InlineData("pedro1")]    // minúsculas y número, sin mayúscula ni especial
    [InlineData("pedro1P")]   // minúsculas, número y mayúscula, sin especial
    [InlineData("pedro@1")]   // minúsculas, especial y número, sin mayúscula
    [InlineData("PEDRO1@")]   // mayúsculas, número y especial, sin minúscula 
    public void CrearContraseña_DatosInvalidos_LanzaExcepcion(string contraseña)
    {
        var ex = Assert.Throws<Exception>(() =>
        {
            new Contraseña(contraseña);
        });

        _output.WriteLine(ex.Message);
    }
}
