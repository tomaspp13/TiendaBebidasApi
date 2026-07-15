using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Commands.BebidaCommands.ModificarBebida
{
    public class ModificarBebidaRequest
    {
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float Valor { get; set; }
        public string Moneda { get; set; }
    }
}
