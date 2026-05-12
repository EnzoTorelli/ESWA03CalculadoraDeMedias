namespace OOPFoundation.Concrete
{
    /// <summary>
    /// Padrões de sanitização para diferentes tipos de texto.
    /// </summary>
    public static class SanitizationPattern
    {
        public const string CNPJ  = "a-zA-Z0-9";
        public const string CPF   = "0-9";
        public const string ISBN  = "0-9";
        public const string ISSN  = "0-9Xx";
        public const string PHONE = "0-9";
        public const string RG    = "0-9Xx";

        // Padrão para notas: dígitos e vírgula (conforme QA do enunciado)
        public const string NOTE  = "0-9,\\.";
    }
}
