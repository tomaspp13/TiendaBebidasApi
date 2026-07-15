
namespace Domain.ValueObjects
{
    public class Precio
    {
        public float Valor {get;}
        public string Moneda {get;}

        public Precio(float valor, string moneda)
        {
            if (valor < 0) throw new Exception("EL valor no puede ser negativo");

            if (string.IsNullOrEmpty(moneda)) throw new Exception("La moneda no puede ser nula o vacía");

            this.Valor = valor;
            this.Moneda = moneda;
        }
        protected Precio() { }
    }
}
