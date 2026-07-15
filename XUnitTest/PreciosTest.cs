using Xunit.Abstractions;
using Domain.ValueObjects;
namespace XUnit.Domain;
public class PreciosTest
{
    private readonly ITestOutputHelper _output;
    public PreciosTest(ITestOutputHelper output) 
    {
        _output = output;
    }

    [Fact]
    public void CrearPrecio_DatosValidos_Exito()
    {
        string moneda = "Pesos";
        float valor = 2000.0f;

        Assert.NotNull(new Precio(valor,moneda));
    }

    [Theory]
    [InlineData(-1.0f, "Pesos")] //valor negativo
    [InlineData(1.0f, "")]       //moneda vacia
    [InlineData(-1.0f, "")]      //moneda y valor negativo
    public void CrearPrecio_DatosInvalidos_LanzaExcepcion(float valor,string moneda)
    {
       var ex = Assert.Throws<Exception>(() =>
       {
           new Precio(valor, moneda);
       });

       _output.WriteLine(ex.Message); 
    }

}
  
