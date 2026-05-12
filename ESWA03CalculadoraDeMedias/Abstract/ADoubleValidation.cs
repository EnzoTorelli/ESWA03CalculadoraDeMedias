using OOPFoundation.Interfaces;

namespace OOPFoundation.Abstract
{
    /// <summary>
    /// Classe abstrata que implementa IDoubleValidation.
    /// Define os limites inferior e superior para validação de um valor double.
    /// </summary>
    public abstract class ADoubleValidation : IDoubleValidation
    {
        protected double LowerLimit { get; set; }
        protected double UpperLimit { get; set; }

        protected ADoubleValidation(double lowerLimit, double upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// Valida se o valor está dentro do intervalo fechado [LowerLimit, UpperLimit].
        /// </summary>
        public bool DoubleIsValid(double doubleToValidate)
        {
            return doubleToValidate >= LowerLimit && doubleToValidate <= UpperLimit;
        }
    }
}
