
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email
    {
        public string EmailNombre { get; }
        public Email(string emailnombre)
        {
            if (string.IsNullOrEmpty(emailnombre))
                throw new Exception("El Email no puede estar vacio");

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.(com|ar|com\.ar|net|org)$");
            if (!regex.IsMatch(emailnombre))
                throw new Exception("El mail no contiene el formato valido");

            this.EmailNombre = emailnombre;
        }
        protected Email() { }
    }
}
