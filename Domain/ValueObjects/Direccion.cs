
namespace Domain.ValueObjects
{
    public class Direccion
    {
        public string Calle { get;}
        public int Numero {  get;}
        public string Localidad {  get;}

        public Direccion(string calle,int numero, string localidad) 
        {
            if (string.IsNullOrEmpty(calle)) throw new Exception("La calle no puede estar vacia");
            if (numero < 0) throw new Exception("El numero no puede ser negativo");
            if (string.IsNullOrEmpty(localidad)) throw new Exception("La localidad no puede estar vacia");

            this.Calle = calle;
            this.Numero = numero;
            this.Localidad = localidad;

        }
        protected Direccion() {}
    }
}
