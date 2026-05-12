using System;
using OOPFoundation.Concrete;

namespace OOPFoundation.Calculator
{
    /// <summary>
    /// Responsável pelo cálculo das médias semestral e final,
    /// validação de entradas e definição do status do aluno.
    /// </summary>
    public class GradeCalculator
    {
        // Validadores
        private readonly NoteValidation   _noteValidator   = new NoteValidation();
        private readonly WeightValidation _weightValidator = new WeightValidation();

        // Pesos padrão conforme enunciado
        // MS = (4×NP1 + 4×NP2 + 2×PIM) / 10
        public double WeightNP1 { get; private set; } = 0.4;
        public double WeightNP2 { get; private set; } = 0.4;
        public double WeightPIM { get; private set; } = 0.2;

        // MF = (MS + EX) / 2
        public double WeightMS  { get; private set; } = 0.5;
        public double WeightEX  { get; private set; } = 0.5;

        // Limiar para aprovação direta e aprovação em exame
        private const double PASSING_GRADE  = 7.0;
        private const double EXAM_MIN_GRADE = 5.0;

        // ─── Validação ──────────────────────────────────────────────

        /// <summary>Valida uma nota no intervalo [0,0; 10,0].</summary>
        public bool IsNoteValid(double note) => _noteValidator.DoubleIsValid(note);

        /// <summary>Valida um peso no intervalo [0,0; 1,0].</summary>
        public bool IsWeightValid(double weight) => _weightValidator.DoubleIsValid(weight);

        /// <summary>
        /// Valida se a soma dos pesos de MS é exatamente 1,0.
        /// (weightNP1 + weightNP2 + weightPIM == 1.0)
        /// </summary>
        public bool IsSemestralWeightSumValid(double wNP1, double wNP2, double wPIM)
        {
            double sum = Math.Round(wNP1 + wNP2 + wPIM, 10);
            return Math.Abs(sum - 1.0) < 1e-9;
        }

        /// <summary>
        /// Valida se a soma dos pesos de MF é exatamente 1,0.
        /// (weightMS + weightEX == 1.0)
        /// </summary>
        public bool IsFinalWeightSumValid(double wMS, double wEX)
        {
            double sum = Math.Round(wMS + wEX, 10);
            return Math.Abs(sum - 1.0) < 1e-9;
        }

        // ─── Cálculo ─────────────────────────────────────────────────

        /// <summary>
        /// Calcula a Média Semestral:
        /// MS = (4×NP1 + 4×NP2 + 2×PIM) / 10
        /// com arredondamento matemático para 1 casa decimal.
        /// </summary>
        /// <exception cref="ArgumentException">Se alguma nota for inválida.</exception>
        public double CalculateSemestralAverage(double np1, double np2, double pim)
        {
            if (!IsNoteValid(np1)) throw new ArgumentException("NP1 inválida.", nameof(np1));
            if (!IsNoteValid(np2)) throw new ArgumentException("NP2 inválida.", nameof(np2));
            if (!IsNoteValid(pim)) throw new ArgumentException("PIM inválida.", nameof(pim));

            double ms = (4 * np1 + 4 * np2 + 2 * pim) / 10.0;
            return Math.Round(ms, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calcula a Média Final:
        /// MF = (MS + EX) / 2
        /// com arredondamento matemático para 1 casa decimal.
        /// </summary>
        /// <exception cref="ArgumentException">Se algum valor for inválido.</exception>
        public double CalculateFinalAverage(double semestralAverage, double exam)
        {
            if (!IsNoteValid(semestralAverage))
                throw new ArgumentException("Média semestral inválida.", nameof(semestralAverage));
            if (!IsNoteValid(exam))
                throw new ArgumentException("Nota de exame inválida.", nameof(exam));

            double mf = (semestralAverage + exam) / 2.0;
            return Math.Round(mf, 1, MidpointRounding.AwayFromZero);
        }

        // ─── Status ──────────────────────────────────────────────────

        /// <summary>
        /// Define o status do aluno com base na Média Semestral.
        /// MS >= 7,0 → Aprovado | MS < 7,0 → Em Exame
        /// </summary>
        public StudentStatus GetSemestralStatus(double semestralAverage)
        {
            return semestralAverage >= PASSING_GRADE
                ? StudentStatus.Aprovado
                : StudentStatus.EmExame;
        }

        /// <summary>
        /// Define o status do aluno com base na Média Final.
        /// MF >= 5,0 → Aprovado | MF < 5,0 → Reprovado
        /// </summary>
        public StudentStatus GetFinalStatus(double finalAverage)
        {
            return finalAverage >= EXAM_MIN_GRADE
                ? StudentStatus.Aprovado
                : StudentStatus.Reprovado;
        }

        // ─── Sanitização de entrada ───────────────────────────────────

        /// <summary>
        /// Sanitiza a entrada do usuário, permitindo apenas dígitos e vírgula/ponto.
        /// Converte vírgula para ponto para parsing correto em double.
        /// </summary>
        public string SanitizeNoteInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var text = new Text(input, SanitizationPattern.NOTE);
            return text.GetText().Replace(',', '.');
        }

        /// <summary>
        /// Tenta converter uma string sanitizada em double.
        /// Retorna true e o valor em <paramref name="result"/> se bem-sucedido.
        /// </summary>
        public bool TryParseNote(string sanitizedInput, out double result)
        {
            return double.TryParse(
                sanitizedInput,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out result);
        }
    }
}
