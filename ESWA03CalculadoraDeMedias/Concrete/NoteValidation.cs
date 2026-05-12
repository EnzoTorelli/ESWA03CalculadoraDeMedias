using OOPFoundation.Abstract;

namespace OOPFoundation.Concrete
{
    /// <summary>
    /// Valida notas no intervalo fechado [0,0; 10,0].
    /// Subclasse de ADoubleValidation.
    /// </summary>
    public class NoteValidation : ADoubleValidation
    {
        public NoteValidation() : base(0.0, 10.0) { }
    }
}
