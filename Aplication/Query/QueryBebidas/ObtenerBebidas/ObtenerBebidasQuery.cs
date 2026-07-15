using Aplication.Query.QueryBebidas.ObtenerBebidasPorId;
using MediatR;

namespace Aplication.Query.QueryBebidas.ObtenerBebidas
{
    public class ObtenerBebidasQuery:IRequest<ICollection<ObtenerBebidasResponse>>
    {
    }
}
