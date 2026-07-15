using Domain.ValueObjects;

namespace Domain.Entidades
{
    public class Bebida : BaseEntity
    {
        public string Nombre { get; private set; }
        public float Cantidad { get; private set; }
        public Precio Precio { get; private set; }

        public void modificarNombreBebida(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede estar vacio");
            this.Nombre = nombre;
        }
        public void modificarCantidadBebida(float cantidad) 
        { 
            if (cantidad < 0) throw new Exception("La cantidad no puede ser negativa o cero");
            this.Cantidad = cantidad;
        }
        public void modificarPrecioBebida( float valor, string moneda) => this.Precio = new Precio(valor, moneda);
        
        public Bebida (string nombre, float cantidad, Precio precio) 
        {
            if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede estar vacio");
            if (cantidad < 0) throw new Exception("La cantidad no puede ser negativa o cero");
            
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
        protected Bebida() { }
    }
}
