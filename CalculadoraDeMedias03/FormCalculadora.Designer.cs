namespace CalculadoraDeMedias03
{
    partial class FormCalculadora
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Controles
            lblTitulo = new System.Windows.Forms.Label();
            lblStatusTitle = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();

            lblNP1 = new System.Windows.Forms.Label();
            lblNP2 = new System.Windows.Forms.Label();
            lblPIM = new System.Windows.Forms.Label();
            lblSemestralLbl = new System.Windows.Forms.Label();
            lblSemestral = new System.Windows.Forms.Label();

            txtNP1 = new System.Windows.Forms.TextBox();
            txtNP2 = new System.Windows.Forms.TextBox();
            txtPIM = new System.Windows.Forms.TextBox();

            btnLimparSemestral = new System.Windows.Forms.Button();
            btnSemestral = new System.Windows.Forms.Button();

            lblExame = new System.Windows.Forms.Label();
            lblFinalLbl = new System.Windows.Forms.Label();
            lblFinal = new System.Windows.Forms.Label();
            txtExame = new System.Windows.Forms.TextBox();

            btnLimparFinal = new System.Windows.Forms.Button();
            btnFinal = new System.Windows.Forms.Button();

            SuspendLayout();

            // ── Formulário ──────────────────────────────────────────
            this.Text = "Cálculo de Médias e Status | ESWA+POO";
            this.Size = new System.Drawing.Size(360, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // ── STATUS label título ──────────────────────────────────
            lblStatusTitle.Text = "STATUS";
            lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStatusTitle.BackColor = System.Drawing.Color.FromArgb(0, 70, 127);
            lblStatusTitle.ForeColor = System.Drawing.Color.White;
            lblStatusTitle.Size = new System.Drawing.Size(320, 28);
            lblStatusTitle.Location = new System.Drawing.Point(10, 10);

            // ── STATUS valor ─────────────────────────────────────────
            lblStatus.Text = "Em Andamento";
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStatus.Size = new System.Drawing.Size(320, 24);
            lblStatus.Location = new System.Drawing.Point(10, 38);

            // ── NP1 ──────────────────────────────────────────────────
            lblNP1.Text = "NP1";
            lblNP1.Size = new System.Drawing.Size(80, 22);
            lblNP1.Location = new System.Drawing.Point(10, 75);
            lblNP1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            txtNP1.Size = new System.Drawing.Size(100, 22);
            txtNP1.Location = new System.Drawing.Point(230, 75);
            txtNP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtNP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);

            // ── NP2 ──────────────────────────────────────────────────
            lblNP2.Text = "NP2";
            lblNP2.Size = new System.Drawing.Size(80, 22);
            lblNP2.Location = new System.Drawing.Point(10, 105);
            lblNP2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            txtNP2.Size = new System.Drawing.Size(100, 22);
            txtNP2.Location = new System.Drawing.Point(230, 105);
            txtNP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtNP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);

            // ── PIM ──────────────────────────────────────────────────
            lblPIM.Text = "PIM";
            lblPIM.Size = new System.Drawing.Size(80, 22);
            lblPIM.Location = new System.Drawing.Point(10, 135);
            lblPIM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            txtPIM.Size = new System.Drawing.Size(100, 22);
            txtPIM.Location = new System.Drawing.Point(230, 135);
            txtPIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtPIM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);

            // ── Semestral ─────────────────────────────────────────────
            lblSemestralLbl.Text = "Semestral";
            lblSemestralLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSemestralLbl.Size = new System.Drawing.Size(80, 22);
            lblSemestralLbl.Location = new System.Drawing.Point(10, 165);
            lblSemestralLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            lblSemestral.Text = "0,0";
            lblSemestral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSemestral.Size = new System.Drawing.Size(100, 22);
            lblSemestral.Location = new System.Drawing.Point(230, 165);
            lblSemestral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblSemestral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── Botões Semestral ──────────────────────────────────────
            btnLimparSemestral.Text = "Limpar";
            btnLimparSemestral.Size = new System.Drawing.Size(75, 26);
            btnLimparSemestral.Location = new System.Drawing.Point(145, 200);
            btnLimparSemestral.Click += new System.EventHandler(btnLimparSemestral_Click);

            btnSemestral.Text = "Semestral";
            btnSemestral.Size = new System.Drawing.Size(85, 26);
            btnSemestral.Location = new System.Drawing.Point(225, 200);
            btnSemestral.BackColor = System.Drawing.Color.FromArgb(0, 70, 127);
            btnSemestral.ForeColor = System.Drawing.Color.White;
            btnSemestral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSemestral.Click += new System.EventHandler(btnSemestral_Click);

            // ── Separador visual ──────────────────────────────────────
            var sep = new System.Windows.Forms.Label();
            sep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sep.Size = new System.Drawing.Size(320, 2);
            sep.Location = new System.Drawing.Point(10, 238);

            // ── Exame ─────────────────────────────────────────────────
            lblExame.Text = "Exame";
            lblExame.Size = new System.Drawing.Size(80, 22);
            lblExame.Location = new System.Drawing.Point(10, 250);
            lblExame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            txtExame.Size = new System.Drawing.Size(100, 22);
            txtExame.Location = new System.Drawing.Point(230, 250);
            txtExame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtExame.Enabled = false;
            txtExame.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);

            // ── Final ─────────────────────────────────────────────────
            lblFinalLbl.Text = "Final";
            lblFinalLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblFinalLbl.Size = new System.Drawing.Size(80, 22);
            lblFinalLbl.Location = new System.Drawing.Point(10, 280);
            lblFinalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            lblFinal.Text = "0,0";
            lblFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblFinal.Size = new System.Drawing.Size(100, 22);
            lblFinal.Location = new System.Drawing.Point(230, 280);
            lblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── Botões Final ──────────────────────────────────────────
            btnLimparFinal.Text = "Limpar";
            btnLimparFinal.Size = new System.Drawing.Size(75, 26);
            btnLimparFinal.Location = new System.Drawing.Point(145, 315);
            btnLimparFinal.Enabled = false;
            btnLimparFinal.Click += new System.EventHandler(btnLimparFinal_Click);

            btnFinal.Text = "Final";
            btnFinal.Size = new System.Drawing.Size(85, 26);
            btnFinal.Location = new System.Drawing.Point(225, 315);
            btnFinal.Enabled = false;
            btnFinal.BackColor = System.Drawing.Color.FromArgb(0, 70, 127);
            btnFinal.ForeColor = System.Drawing.Color.White;
            btnFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFinal.Click += new System.EventHandler(btnFinal_Click);

            // ── Adicionar ao Form ─────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblStatusTitle, lblStatus,
                lblNP1, txtNP1,
                lblNP2, txtNP2,
                lblPIM, txtPIM,
                lblSemestralLbl, lblSemestral,
                btnLimparSemestral, btnSemestral,
                sep,
                lblExame, txtExame,
                lblFinalLbl, lblFinal,
                btnLimparFinal, btnFinal
            });

            ResumeLayout(false);
        }

        #endregion

        // ── Declaração dos controles ──────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNP1;
        private System.Windows.Forms.Label lblNP2;
        private System.Windows.Forms.Label lblPIM;
        private System.Windows.Forms.Label lblSemestralLbl;
        private System.Windows.Forms.Label lblSemestral;
        private System.Windows.Forms.TextBox txtNP1;
        private System.Windows.Forms.TextBox txtNP2;
        private System.Windows.Forms.TextBox txtPIM;
        private System.Windows.Forms.Button btnLimparSemestral;
        private System.Windows.Forms.Button btnSemestral;
        private System.Windows.Forms.Label lblExame;
        private System.Windows.Forms.Label lblFinalLbl;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.TextBox txtExame;
        private System.Windows.Forms.Button btnLimparFinal;
        private System.Windows.Forms.Button btnFinal;
    }
}