
namespace Aplication.Exceptions
{
    public class InvalidBebidaException : Exception
    {
        public InvalidBebidaException(string message) : base(message) { }

        public class BebidaEncontradaException : InvalidBebidaException
        {
            public BebidaEncontradaException() : base("Bebida ya creada")
            {
            }
        }

        public class BebidaNoEncontradaException : InvalidBebidaException
        {
            public BebidaNoEncontradaException() : base("Bebida no encontrada")
            {
            }
        }
    }
}
