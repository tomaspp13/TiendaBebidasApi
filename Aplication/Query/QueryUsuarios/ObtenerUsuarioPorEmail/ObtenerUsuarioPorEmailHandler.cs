using Aplication.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Query.QueryUsuarios.ObtenerUsuarioPorEmail
{
    public class ObtenerUsuarioPorEmailHandler : IRequestHandler<ObtenerUsuarioPorEmailQuery, ObtenerUsuarioPorEmailResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public ObtenerUsuarioPorEmailHandler(IUsuarioRepository usuarioRepository,IMapper mapper) 
        { 
            _usuarioRepository = usuarioRepository; 
            _mapper = mapper;
        }
        public async Task<ObtenerUsuarioPorEmailResponse> Handle(ObtenerUsuarioPorEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorEmailAsync(request.Email);
            if(usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontradoPorMail(); }
            var usuarioMapeado = _mapper.Map<ObtenerUsuarioPorEmailResponse>(usuario);
            return usuarioMapeado;
        }
    }
}
