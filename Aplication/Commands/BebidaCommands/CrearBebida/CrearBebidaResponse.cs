namespace Aplication.Commands.BebidaCommands.CrearBebida
{
    public class CrearBebidaResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Cantidad {  get; set; }
        public float Precio {  get; set; }
        public string Moneda { get; set; }

        public CrearBebidaResponse(Guid id, string nombre, float cantidad, float precio, string moneda)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Moneda = moneda;
        }
        protected CrearBebidaResponse() { }
    }
}
