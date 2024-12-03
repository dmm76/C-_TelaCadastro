namespace WinFormsAppFoto
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvFoto = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fotoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fotoBindingSource = new BindingSource(components);
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnFechar = new Button();
            btnFoto = new Button();
            txtNome = new TextBox();
            lblNome = new Label();
            pbxImagem = new PictureBox();
            label1 = new Label();
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fotoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxImagem).BeginInit();
            SuspendLayout();
            // 
            // dgvFoto
            // 
            dgvFoto.AllowUserToAddRows = false;
            dgvFoto.AllowUserToDeleteRows = false;
            dgvFoto.AutoGenerateColumns = false;
            dgvFoto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoto.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, fotoDataGridViewTextBoxColumn });
            dgvFoto.DataSource = fotoBindingSource;
            dgvFoto.Location = new Point(36, 446);
            dgvFoto.Margin = new Padding(4);
            dgvFoto.Name = "dgvFoto";
            dgvFoto.ReadOnly = true;
            dgvFoto.RowTemplate.Height = 25;
            dgvFoto.Size = new Size(339, 155);
            dgvFoto.TabIndex = 0;
            dgvFoto.CellClick += dgvFoto_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fotoDataGridViewTextBoxColumn
            // 
            fotoDataGridViewTextBoxColumn.DataPropertyName = "foto";
            fotoDataGridViewTextBoxColumn.HeaderText = "foto";
            fotoDataGridViewTextBoxColumn.Name = "fotoDataGridViewTextBoxColumn";
            fotoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fotoBindingSource
            // 
            fotoBindingSource.DataSource = typeof(Foto);
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.SeaGreen;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.ForeColor = SystemColors.ButtonHighlight;
            btnAdicionar.Location = new Point(546, 73);
            btnAdicionar.Margin = new Padding(4);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(167, 88);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "ADICIONAR";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.Highlight;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = SystemColors.HighlightText;
            btnEditar.Location = new Point(546, 169);
            btnEditar.Margin = new Padding(4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(167, 88);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.ForeColor = SystemColors.HighlightText;
            btnExcluir.Location = new Point(546, 269);
            btnExcluir.Margin = new Padding(4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(167, 88);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = SystemColors.ButtonShadow;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnFechar.ForeColor = SystemColors.HighlightText;
            btnFechar.Location = new Point(546, 365);
            btnFechar.Margin = new Padding(4);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(167, 88);
            btnFechar.TabIndex = 4;
            btnFechar.Text = "FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnFoto
            // 
            btnFoto.BackColor = Color.LimeGreen;
            btnFoto.FlatStyle = FlatStyle.Flat;
            btnFoto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnFoto.ForeColor = SystemColors.HighlightText;
            btnFoto.Location = new Point(281, 181);
            btnFoto.Margin = new Padding(4);
            btnFoto.Name = "btnFoto";
            btnFoto.Size = new Size(167, 88);
            btnFoto.TabIndex = 5;
            btnFoto.Text = "Foto";
            btnFoto.UseMnemonic = false;
            btnFoto.UseVisualStyleBackColor = false;
            btnFoto.Click += btnFoto_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(36, 73);
            txtNome.Margin = new Padding(4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(412, 27);
            txtNome.TabIndex = 6;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.ForeColor = SystemColors.ControlLightLight;
            lblNome.Location = new Point(36, 37);
            lblNome.Margin = new Padding(4, 0, 4, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(54, 20);
            lblNome.TabIndex = 7;
            lblNome.Text = "NOME";
            // 
            // pbxImagem
            // 
            pbxImagem.BackColor = SystemColors.ButtonHighlight;
            pbxImagem.Location = new Point(36, 181);
            pbxImagem.Name = "pbxImagem";
            pbxImagem.Size = new Size(218, 228);
            pbxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxImagem.TabIndex = 8;
            pbxImagem.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(36, 139);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 9;
            label1.Text = "IMAGEM";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.ForeColor = SystemColors.HighlightText;
            lblId.Location = new Point(36, 422);
            lblId.Name = "lblId";
            lblId.Size = new Size(23, 20);
            lblId.TabIndex = 10;
            lblId.Text = "Id";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(735, 620);
            Controls.Add(lblId);
            Controls.Add(label1);
            Controls.Add(pbxImagem);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(btnFoto);
            Controls.Add(btnFechar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(dgvFoto);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "frmPrincipal";
            Text = "MenuFoto";
            ((System.ComponentModel.ISupportInitialize)dgvFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)fotoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxImagem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFoto;
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnFechar;
        private Button btnFoto;
        private TextBox txtNome;
        private Label lblNome;
        private PictureBox pbxImagem;
        private Label label1;
        private Label lblId;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fotoDataGridViewTextBoxColumn;
        private BindingSource fotoBindingSource;
    }
}