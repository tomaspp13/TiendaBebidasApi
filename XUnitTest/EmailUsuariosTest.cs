using Domain.ValueObjects;
using Xunit.Abstractions;

namespace XUnit.Domain;

public class EmailUsuariosTest
{
    private readonly ITestOutputHelper _output;

    public EmailUsuariosTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CrearEmailUsuario_DatosValidos_Exito()
    {
        string email = "Pedro@gmail.com";
        Assert.NotNull(() => { new Email(email); });
    }

    [Theory]
    [InlineData("")]                    // vacío
    [InlineData("pedro")]               // sin @ y sin dominio
    [InlineData("pedro@")]              // sin dominio
    [InlineData("@pedro.com")]          // sin nombre antes del @
    [InlineData("pedro@com")]           // sin punto en dominio
    [InlineData("pedro@.com")]          // punto pegado al @
    [InlineData("pedro@dominio.")]      // punto al final sin extensión
    [InlineData("pedro @dominio.com")]  // espacio en el nombre
    [InlineData("pedro@@dominio.com")]  // doble @
    [InlineData("pedro@dominio@com")]   // @ en lugar de punto
    [InlineData("pedro@dominio.c")]     // extensión de 1 sola letra
    public void CrearEmailUsuario_DatosInvalidos_LanzaExcepcion(string email)
    {
        var ex = Assert.Throws<Exception>(() => { new Email(email); });
        _output.WriteLine(ex.Message);
    }
}
