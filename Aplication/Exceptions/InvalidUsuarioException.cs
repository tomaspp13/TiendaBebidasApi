
namespace Aplication.Exceptions
{
    public class InvalidUsuarioException : Exception
    {
        public InvalidUsuarioException(string message) : base(message) { }

        public class UsuarioNoEncontrado : InvalidUsuarioException
        {
            public UsuarioNoEncontrado (): base("Usuario no encontrado") { }
        }
        public class UsuarioNoEncontradoPorMail : InvalidUsuarioException
        {
            public UsuarioNoEncontradoPorMail() : base("Usuario no encontrado por mail") { }
        }
        public class UsuarioEncontradoPorMail : InvalidUsuarioException
        {
            public UsuarioEncontradoPorMail() : base("Usuario ya creado, cree otro") { }
        }
    }
}
