using OOPFoundation.Abstract;

namespace OOPFoundation.Concrete
{
    /// <summary>
    /// Implementação concreta de AText para uso geral.
    /// </summary>
    public class Text : AText
    {
        public Text() : base() { }

        public Text(string text, string validPattern) : base(text, validPattern) { }
    }
}
