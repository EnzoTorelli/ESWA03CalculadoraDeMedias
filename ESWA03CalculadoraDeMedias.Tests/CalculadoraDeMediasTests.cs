using Xunit;
using OOPFoundation.Calculator;
using OOPFoundation.Concrete;

namespace CalculadoraDeMedias03.Tests
{
    // ════════════════════════════════════════════════════════════════════════════
    // 1. Validação de Notas  [0,0 ; 10,0]
    // ════════════════════════════════════════════════════════════════════════════
    public class ValidacaoNotasTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(0.0)]
        [InlineData(5.0)]
        [InlineData(7.5)]
        [InlineData(10.0)]
        public void IsNoteValid_NotaDentroDoIntervalo_DeveRetornarTrue(double nota)
        {
            Assert.True(_calc.IsNoteValid(nota));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(10.1)]
        [InlineData(-1.0)]
        [InlineData(11.0)]
        public void IsNoteValid_NotaForaDoIntervalo_DeveRetornarFalse(double nota)
        {
            Assert.False(_calc.IsNoteValid(nota));
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    // 2. Validação de Pesos  [0,0 ; 1,0]  e  Soma dos Pesos
    // ════════════════════════════════════════════════════════════════════════════
    public class ValidacaoPesosTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(0.0)]
        [InlineData(0.4)]
        [InlineData(1.0)]
        public void IsWeightValid_PesoDentroDoIntervalo_DeveRetornarTrue(double peso)
        {
            Assert.True(_calc.IsWeightValid(peso));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void IsWeightValid_PesoForaDoIntervalo_DeveRetornarFalse(double peso)
        {
            Assert.False(_calc.IsWeightValid(peso));
        }

        // Soma dos pesos MS: NP1=0.4, NP2=0.4, PIM=0.2  →  1.0
        [Fact]
        public void IsSemestralWeightSumValid_SomaPadraoIgualA1_DeveRetornarTrue()
        {
            Assert.True(_calc.IsSemestralWeightSumValid(0.4, 0.4, 0.2));
        }

        [Fact]
        public void IsSemestralWeightSumValid_SomaDiferenteDe1_DeveRetornarFalse()
        {
            Assert.False(_calc.IsSemestralWeightSumValid(0.4, 0.3, 0.2));
        }

        // Soma dos pesos MF: MS=0.5, EX=0.5  →  1.0
        [Fact]
        public void IsFinalWeightSumValid_SomaPadraoIgualA1_DeveRetornarTrue()
        {
            Assert.True(_calc.IsFinalWeightSumValid(0.5, 0.5));
        }

        [Fact]
        public void IsFinalWeightSumValid_SomaDiferenteDe1_DeveRetornarFalse()
        {
            Assert.False(_calc.IsFinalWeightSumValid(0.4, 0.5));
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    // 3. Cálculo da Média Semestral
    //    MS = (4×NP1 + 4×NP2 + 2×PIM) / 10   — AwayFromZero, 1 decimal
    // ════════════════════════════════════════════════════════════════════════════
    public class MediaSemestralTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(8.0, 7.0, 6.0, 7.2)]   // (32+28+12)/10 = 7.2
        [InlineData(10.0, 10.0, 10.0, 10.0)]
        [InlineData(0.0, 0.0, 0.0, 0.0)]
        [InlineData(5.0, 5.0, 5.0, 5.0)]
        [InlineData(7.0, 6.0, 8.0, 6.8)]   // (28+24+16)/10 = 6.8
        public void CalculateSemestralAverage_DeveCalcularCorretamente(
            double np1, double np2, double pim, double esperado)
        {
            double resultado = _calc.CalculateSemestralAverage(np1, np2, pim);
            Assert.Equal(esperado, resultado);
        }

        // Arredondamento AwayFromZero: 6.95 → 7.0 (não banker's rounding)
        [Fact]
        public void CalculateSemestralAverage_Arredondamento_AwayFromZero()
        {
            // (4×7 + 4×7 + 2×6.75) / 10 = (28+28+13.5)/10 = 6.95 → 7.0
            double resultado = _calc.CalculateSemestralAverage(7.0, 7.0, 6.75);
            Assert.Equal(7.0, resultado);
        }

        [Fact]
        public void CalculateSemestralAverage_NotaInvalida_DeveLancarArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                _calc.CalculateSemestralAverage(-1.0, 5.0, 5.0));
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    // 4. Status da Média Semestral
    //    MS >= 7,0 → Aprovado  |  MS < 7,0 → EmExame
    // ════════════════════════════════════════════════════════════════════════════
    public class StatusSemestralTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(7.0)]
        [InlineData(8.5)]
        [InlineData(10.0)]
        public void GetSemestralStatus_MSMaiorOuIgualA7_DeveRetornarAprovado(double ms)
        {
            Assert.Equal(StudentStatus.Aprovado, _calc.GetSemestralStatus(ms));
        }

        [Theory]
        [InlineData(6.9)]
        [InlineData(5.0)]
        [InlineData(0.0)]
        public void GetSemestralStatus_MSMenorQue7_DeveRetornarEmExame(double ms)
        {
            Assert.Equal(StudentStatus.EmExame, _calc.GetSemestralStatus(ms));
        }

        [Fact]
        public void GetSemestralStatus_LimiteExato7_DeveRetornarAprovado()
        {
            Assert.Equal(StudentStatus.Aprovado, _calc.GetSemestralStatus(7.0));
        }

        [Fact]
        public void GetSemestralStatus_Abaixo7_DeveRetornarEmExame()
        {
            // MS calculada = 6.9 → EmExame
            double ms = _calc.CalculateSemestralAverage(6.0, 6.0, 9.0);
            Assert.Equal(StudentStatus.EmExame, _calc.GetSemestralStatus(ms));
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    // 5. Cálculo da Média Final
    //    MF = (MS + EX) / 2   — AwayFromZero, 1 decimal
    // ════════════════════════════════════════════════════════════════════════════
    public class MediaFinalTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(6.0, 6.0, 6.0)]
        [InlineData(5.0, 7.0, 6.0)]
        [InlineData(4.0, 8.0, 6.0)]
        [InlineData(10.0, 10.0, 10.0)]
        [InlineData(0.0, 0.0, 0.0)]
        public void CalculateFinalAverage_DeveCalcularCorretamente(
            double ms, double ex, double esperado)
        {
            double resultado = _calc.CalculateFinalAverage(ms, ex);
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalculateFinalAverage_LimiteDe5_Exato()
        {
            // (4.0 + 6.0) / 2 = 5.0
            double resultado = _calc.CalculateFinalAverage(4.0, 6.0);
            Assert.Equal(5.0, resultado);
        }

        [Fact]
        public void CalculateFinalAverage_NotaInvalida_DeveLancarArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                _calc.CalculateFinalAverage(5.0, -1.0));
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    // 6. Status da Média Final
    //    MF >= 5,0 → Aprovado  |  MF < 5,0 → Reprovado
    // ════════════════════════════════════════════════════════════════════════════
    public class StatusFinalTests
    {
        private readonly GradeCalculator _calc = new GradeCalculator();

        [Theory]
        [InlineData(5.0)]
        [InlineData(6.0)]
        [InlineData(10.0)]
        public void GetFinalStatus_MFMaiorOuIgualA5_DeveRetornarAprovado(double mf)
        {
            Assert.Equal(StudentStatus.Aprovado, _calc.GetFinalStatus(mf));
        }

        [Theory]
        [InlineData(4.9)]
        [InlineData(3.0)]
        [InlineData(0.0)]
        public void GetFinalStatus_MFMenorQue5_DeveRetornarReprovado(double mf)
        {
            Assert.Equal(StudentStatus.Reprovado, _calc.GetFinalStatus(mf));
        }

        [Fact]
        public void GetFinalStatus_LimiteExato5_DeveRetornarAprovado()
        {
            Assert.Equal(StudentStatus.Aprovado, _calc.GetFinalStatus(5.0));
        }

        [Fact]
        public void GetFinalStatus_Abaixo5_DeveRetornarReprovado()
        {
            // MF calculada: (4.8 + 5.0) / 2 = 4.9 → Reprovado
            double mf = _calc.CalculateFinalAverage(4.8, 5.0);
            Assert.Equal(StudentStatus.Reprovado, _calc.GetFinalStatus(mf));
        }
    }
}