namespace Aplication.Query.QueryBebidas.ObtenerBebidas
{
    public class ObtenerBebidasResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Moneda { get; set; }

        public ObtenerBebidasResponse(Guid id, string nombre, float cantidad, float precio, string moneda)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Moneda = moneda;
        }

        protected ObtenerBebidasResponse() { }
    }
}
