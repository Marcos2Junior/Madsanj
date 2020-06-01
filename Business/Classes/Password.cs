using System;
using System.Linq;

namespace Business.Classes
{
    public class Password
    {

        /// <summary>
        /// Gera uma string de caracteres aleatorios
        /// </summary>
        /// <param name="quantity">Quantidade de caracteres</param>
        /// <param name="upperCase">permitir letras maiusculas</param>
        /// <param name="lowerCase">permitir letras minusculas</param>
        /// <param name="speChar">permitir caracteres especiais</param>
        /// <param name="number">permitir numeros</param>
        /// <returns>retorna string resultado</returns>
        public string NewPassword(int quantity, bool upperCase = true, bool lowerCase = true, bool speChar = true, bool number = true)
        {
            string chars = string.Empty;

            if (upperCase)
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (lowerCase)
                chars += "abcdefghijklmnopqrstuvwxyz";

            if (number)
                chars += "0123456789";

            if (speChar)
                chars += "!@#$%&*()";

            var random = new Random();

            return new string(
                Enumerable.Repeat(chars, quantity)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}
