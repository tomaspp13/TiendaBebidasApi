using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Contraseña
    {
        public string ContraseñaDeEmail { get; } 
        public Contraseña(string contraseñaDeEmail)
        {
            if (string.IsNullOrEmpty(contraseñaDeEmail))
            {
                throw new Exception("La contraseña no puede estar vacia");
            }

            int contadorcaracteresEspeciales = contraseñaDeEmail.Count(c => !char.IsLetterOrDigit(c));

            if (contadorcaracteresEspeciales < 1 || !contraseñaDeEmail.Any(c => char.IsUpper(c)) || !contraseñaDeEmail.Any(c => char.IsNumber(c)) || !contraseñaDeEmail.Any(c => char.IsLower(c))) { throw new Exception("La contraseña debe tener al menos un caracter especial, una mayuscula, una minuscula y un numero minimo"); }

            this.ContraseñaDeEmail = contraseñaDeEmail;
        }
        protected Contraseña() { }
    }
}
