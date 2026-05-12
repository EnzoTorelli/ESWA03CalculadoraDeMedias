using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using OOPFoundation.Interfaces;

namespace OOPFoundation.Abstract
{
    /// <summary>
    /// Classe abstrata que representa um texto validável e sanitizável.
    /// Implementa ISanitization e ITextValidation.
    /// </summary>
    public abstract class AText : ISanitization, ITextValidation
    {
        private string _text;
        private string _validPattern;

        protected AText()
        {
            _text = string.Empty;
            _validPattern = string.Empty;
        }

        protected AText(string text, string validPattern)
        {
            _validPattern = validPattern;
            _text = Sanitize(text);
        }

        public string GetText() => _text;

        public string ObtainHashedText() => Hash();

        public string Sanitize(string textToSanitize)
        {
            if (string.IsNullOrEmpty(textToSanitize)) return string.Empty;
            return Regex.Replace(textToSanitize, $"[^{_validPattern}]", string.Empty);
        }

        public bool TextIsValid(string textToValidate)
        {
            if (string.IsNullOrEmpty(textToValidate)) return false;
            return Regex.IsMatch(textToValidate, $"^[{_validPattern}]+$");
        }

        private string Hash()
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Encode()));
            return Convert.ToBase64String(bytes);
        }

        private string Encode()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_text));
        }
    }
}
