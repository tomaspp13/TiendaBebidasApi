using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Query.QueryUsuarios.ObtenerUsuarioPorId
{
    public class ObtenerUsuarioPorIdResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email {  get; set; }
        public ObtenerUsuarioPorIdResponse(Guid id, string nombre, string apellido, string email)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
        }
        protected ObtenerUsuarioPorIdResponse() { }
    }
}
