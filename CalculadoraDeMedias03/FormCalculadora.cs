using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OOPFoundation.Calculator;
using OOPFoundation.Concrete;

namespace CalculadoraDeMedias03
{
    public partial class FormCalculadora : Form
    {
        private readonly GradeCalculator _calculator = new GradeCalculator();
        private double _semestralAverage = 0.0;

        public FormCalculadora()
        {
            InitializeComponent();
            ResetAll();
        }

        // ─── Botão Semestral ─────────────────────────────────────────

        private void btnSemestral_Click(object sender, EventArgs e)
        {
            if (!TryGetNote(txtNP1, "NP1", out double np1)) return;
            if (!TryGetNote(txtNP2, "NP2", out double np2)) return;
            if (!TryGetNote(txtPIM, "PIM", out double pim)) return;

            _semestralAverage = _calculator.CalculateSemestralAverage(np1, np2, pim);
            lblSemestral.Text = _semestralAverage.ToString("F1", new CultureInfo("pt-BR"));

            var status = _calculator.GetSemestralStatus(_semestralAverage);
            SetStatus(status);

            if (status == StudentStatus.EmExame)
            {
                btnLimparFinal.Enabled = true;
                btnFinal.Enabled = true;
                txtExame.Enabled = true;
            }
            else
            {
                btnLimparFinal.Enabled = false;
                btnFinal.Enabled = false;
                txtExame.Enabled = false;
                lblFinal.Text = "0,0";
            }
        }

        // ─── Botão Limpar (Semestral) ────────────────────────────────

        private void btnLimparSemestral_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        // ─── Botão Final ─────────────────────────────────────────────

        private void btnFinal_Click(object sender, EventArgs e)
        {
            if (!TryGetNote(txtExame, "Exame", out double exame)) return;

            double finalAverage = _calculator.CalculateFinalAverage(_semestralAverage, exame);
            lblFinal.Text = finalAverage.ToString("F1", new CultureInfo("pt-BR"));

            var status = _calculator.GetFinalStatus(finalAverage);
            SetStatus(status);
        }

        // ─── Botão Limpar (Final) ─────────────────────────────────────

        private void btnLimparFinal_Click(object sender, EventArgs e)
        {
            txtExame.Text = string.Empty;
            lblFinal.Text = "0,0";
            lblStatus.ForeColor = Color.Black;

            // Mantém o status em exame (semestral não muda)
            lblStatus.Text = "Em Exame";
            lblStatus.ForeColor = Color.Orange;
        }

        // ─── Sanitização de entrada ───────────────────────────────────

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos, vírgula e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // ─── Helpers ─────────────────────────────────────────────────

        private bool TryGetNote(TextBox txt, string fieldName, out double value)
        {
            value = 0;
            string sanitized = _calculator.SanitizeNoteInput(txt.Text);

            if (!_calculator.TryParseNote(sanitized, out value))
            {
                MessageBox.Show($"{fieldName}: valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                return false;
            }

            if (!_calculator.IsNoteValid(value))
            {
                MessageBox.Show($"{fieldName}: deve estar entre 0,0 e 10,0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                return false;
            }

            return true;
        }

        private void SetStatus(StudentStatus status)
        {
            switch (status)
            {
                case StudentStatus.Aprovado:
                    lblStatus.Text = "Aprovado";
                    lblStatus.ForeColor = Color.Green;
                    break;
                case StudentStatus.EmExame:
                    lblStatus.Text = "Em Exame";
                    lblStatus.ForeColor = Color.Orange;
                    break;
                case StudentStatus.Reprovado:
                    lblStatus.Text = "Reprovado";
                    lblStatus.ForeColor = Color.Red;
                    break;
                default:
                    lblStatus.Text = "Em Andamento";
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        private void ResetAll()
        {
            txtNP1.Text = string.Empty;
            txtNP2.Text = string.Empty;
            txtPIM.Text = string.Empty;
            txtExame.Text = string.Empty;

            lblSemestral.Text = "0,0";
            lblFinal.Text = "0,0";

            lblStatus.Text = "Em Andamento";
            lblStatus.ForeColor = Color.Black;

            _semestralAverage = 0.0;

            txtExame.Enabled = false;
            btnLimparFinal.Enabled = false;
            btnFinal.Enabled = false;
        }
    }
}