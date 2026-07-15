using Aplication.Commands.BebidaCommands.CrearBebida;
using Aplication.Query.QueryBebidas.ObtenerBebidas;
using Aplication.Query.QueryBebidas.ObtenerBebidasPorId;
using AutoMapper;
using Domain.Entidades;
using Domain.ValueObjects;

namespace Aplication.Mappings
{
    public class BebidaProfile : Profile
    {
        public BebidaProfile()
        {
            CreateMap<CrearBebidaCommand, Bebida>()
                .ForCtorParam("precio", opt =>
                    opt.MapFrom(src => new Precio(src.Precio, src.Moneda)));

            CreateMap<Bebida, CrearBebidaResponse>()
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio.Valor))
                .ForMember(dest => dest.Moneda, opt => opt.MapFrom(src => src.Precio.Moneda));

            CreateMap<Bebida, ObtenerBebidasResponse>()
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio.Valor))
                .ForMember(dest => dest.Moneda, opt => opt.MapFrom(src => src.Precio.Moneda));

            CreateMap<Bebida, ObtenerBebidasPorIdResponse>()
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio.Valor))
                .ForMember(dest => dest.Moneda, opt => opt.MapFrom(src => src.Precio.Moneda));
        }
    }
}
