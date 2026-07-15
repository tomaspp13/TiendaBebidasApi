using Aplication.Exceptions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Aplication.Service.ValidacionEmail
{
    public class ValidarEmail
    {
        public void IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new EmailVacioException();

            if (!email.Any(c => c == '@'))
                throw new EmailSinArrobaException();

            int posicionArroba = email.IndexOf('@');

            if (posicionArroba == 0)
                throw new EmailArrobaAlInicioException();

            if (posicionArroba == email.Length - 1)
                throw new EmailSinDominioException();

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                throw new EmailTimeoutException();
            }
            catch (ArgumentException)
            {
                throw new EmailDominioInvalidoException();
            }

            try
            {
                bool formatoValido = Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                if (!formatoValido)
                    throw new EmailFormatoInvalidoException();
            }
            catch (RegexMatchTimeoutException)
            {
                throw new EmailTimeoutException();
            }
        }

    }
}
