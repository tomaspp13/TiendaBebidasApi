using MediatR;

namespace Aplication.Query.QueryBebidas.ObtenerBebidasPorId
{
    public class ObtenerBebidasPorIdQuery : IRequest<ObtenerBebidasPorIdResponse>
    { 
        public Guid Id { get; }
        public ObtenerBebidasPorIdQuery(Guid id) { Id = id; }
    }
}
