using OOPFoundation.Abstract;

namespace OOPFoundation.Concrete
{
    /// <summary>
    /// Valida pesos no intervalo fechado [0,0; 1,0].
    /// Subclasse de ADoubleValidation.
    /// </summary>
    public class WeightValidation : ADoubleValidation
    {
        public WeightValidation() : base(0.0, 1.0) { }
    }
}
