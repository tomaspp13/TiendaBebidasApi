namespace Aplication.Query.QueryBebidas.ObtenerBebidasPorId
{
    public class ObtenerBebidasPorIdResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Moneda { get; set; }

        public ObtenerBebidasPorIdResponse(Guid id, string nombre, float cantidad, float precio, string moneda)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Moneda = moneda;
        }
        protected ObtenerBebidasPorIdResponse() { }
    }
}
