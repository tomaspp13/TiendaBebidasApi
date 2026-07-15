 using Aplication.Commands.UsuarioCommands.CrearUsuario;
using Aplication.Query.QueryUsuarios.ObtenerUsuarioPorEmail;
using Aplication.Query.QueryUsuarios.ObtenerUsuarioPorId;
using AutoMapper;
using Domain.Entidades;
using Domain.ValueObjects;

namespace Aplication.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            //Trasformar de objetos con variables a entidades con value objects
            CreateMap<CrearUsuarioCommand, Usuario>()
            .ForCtorParam("nombre", opt =>
         opt.MapFrom(src => new NombreCompleto(src.Nombre, src.Apellido)))
            .ForCtorParam("emailUsuario", opt =>
         opt.MapFrom(src => new Email(src.Email)))
            .ForCtorParam("contraseñaUsuario", opt =>
         opt.MapFrom(src => new Contraseña(src.Contraseña)));
            //Trasformar dos objetos con las mismas variables
            CreateMap<CrearUsuarioCommand, CrearUsuarioResponse>();
            //Transformar entidades con value objects a un objeto con variables
            CreateMap<Usuario, ObtenerUsuarioPorEmailResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailUsuario.EmailNombre))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Nombre.Apellido));
            CreateMap<Usuario, ObtenerUsuarioPorIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailUsuario.EmailNombre))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Nombre.Apellido));

        }
    }
}
