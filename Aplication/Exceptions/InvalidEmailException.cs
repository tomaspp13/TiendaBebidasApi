
namespace Aplication.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }
    }

    public class EmailVacioException : InvalidEmailException
    {
        public EmailVacioException() : base("El email no puede estar vacío.") { }
    }

    public class EmailSinArrobaException : InvalidEmailException
    {
        public EmailSinArrobaException() : base("El email debe contener un @.") { }
    }

    public class EmailArrobaAlInicioException : InvalidEmailException
    {
        public EmailArrobaAlInicioException() : base("El email no puede empezar con @.") { }
    }

    public class EmailSinDominioException : InvalidEmailException
    {
        public EmailSinDominioException() : base("El email debe tener un dominio después del @.") { }
    }

    public class EmailDominioInvalidoException : InvalidEmailException
    {
        public EmailDominioInvalidoException() : base("El dominio del email es inválido.") { }
    }

    public class EmailTimeoutException : InvalidEmailException
    {
        public EmailTimeoutException() : base("El tiempo de validación del email expiró.") { }
    }

    public class EmailFormatoInvalidoException : InvalidEmailException
    {
        public EmailFormatoInvalidoException() : base("El formato del email es inválido.") { }
    }
    public class EmailNoEncontrado : InvalidEmailException
    {
        public EmailNoEncontrado(): base("Email no encontrado.") { }
    }
        
        
}


