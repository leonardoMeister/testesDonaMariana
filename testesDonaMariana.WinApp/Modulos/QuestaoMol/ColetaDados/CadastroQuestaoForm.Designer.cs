namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.ColetaDados
{
    partial class CadastroQuestaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboDisciplina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAnoLetivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboMateria = new System.Windows.Forms.ComboBox();
            this.grupoQuestao = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.grupoAlternativa = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboAlternativaCorreta = new System.Windows.Forms.ComboBox();
            this.listaAlternativas = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDescricaoAlternativa = new System.Windows.Forms.TextBox();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grupoQuestao.SuspendLayout();
            this.grupoAlternativa.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboDisciplina
            // 
            this.comboDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisciplina.Enabled = false;
            this.comboDisciplina.FormattingEnabled = true;
            this.comboDisciplina.Location = new System.Drawing.Point(492, 29);
            this.comboDisciplina.Name = "comboDisciplina";
            this.comboDisciplina.Size = new System.Drawing.Size(306, 28);
            this.comboDisciplina.TabIndex = 2;
            this.comboDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboDisciplina_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Disciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ano Letivo";
            // 
            // comboAnoLetivo
            // 
            this.comboAnoLetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnoLetivo.FormattingEnabled = true;
            this.comboAnoLetivo.Location = new System.Drawing.Point(91, 29);
            this.comboAnoLetivo.Name = "comboAnoLetivo";
            this.comboAnoLetivo.Size = new System.Drawing.Size(306, 28);
            this.comboAnoLetivo.TabIndex = 1;
            this.comboAnoLetivo.SelectedIndexChanged += new System.EventHandler(this.comboAnoLetivo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Materia";
            // 
            // comboMateria
            // 
            this.comboMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMateria.Enabled = false;
            this.comboMateria.FormattingEnabled = true;
            this.comboMateria.Location = new System.Drawing.Point(91, 81);
            this.comboMateria.Name = "comboMateria";
            this.comboMateria.Size = new System.Drawing.Size(306, 28);
            this.comboMateria.TabIndex = 3;
            this.comboMateria.SelectedIndexChanged += new System.EventHandler(this.comboMateria_SelectedIndexChanged);
            // 
            // grupoQuestao
            // 
            this.grupoQuestao.Controls.Add(this.btnExcluir);
            this.grupoQuestao.Controls.Add(this.btnAdicionar);
            this.grupoQuestao.Controls.Add(this.grupoAlternativa);
            this.grupoQuestao.Controls.Add(this.txtEnunciado);
            this.grupoQuestao.Controls.Add(this.label5);
            this.grupoQuestao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grupoQuestao.Enabled = false;
            this.grupoQuestao.Location = new System.Drawing.Point(0, 129);
            this.grupoQuestao.Name = "grupoQuestao";
            this.grupoQuestao.Size = new System.Drawing.Size(828, 450);
            this.grupoQuestao.TabIndex = 4;
            this.grupoQuestao.TabStop = false;
            this.grupoQuestao.Text = "Dados Questão";
            // 
            // btnExcluir
            // 
            this.btnExcluir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExcluir.Location = new System.Drawing.Point(517, 386);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(134, 45);
            this.btnExcluir.TabIndex = 12;
            this.btnExcluir.Text = "Cancelar";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(669, 386);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(134, 45);
            this.btnAdicionar.TabIndex = 13;
            this.btnAdicionar.Text = "Gravar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // grupoAlternativa
            // 
            this.grupoAlternativa.Controls.Add(this.label6);
            this.grupoAlternativa.Controls.Add(this.comboAlternativaCorreta);
            this.grupoAlternativa.Controls.Add(this.listaAlternativas);
            this.grupoAlternativa.Controls.Add(this.label7);
            this.grupoAlternativa.Controls.Add(this.button1);
            this.grupoAlternativa.Controls.Add(this.txtDescricaoAlternativa);
            this.grupoAlternativa.Location = new System.Drawing.Point(15, 110);
            this.grupoAlternativa.Name = "grupoAlternativa";
            this.grupoAlternativa.Size = new System.Drawing.Size(804, 261);
            this.grupoAlternativa.TabIndex = 11;
            this.grupoAlternativa.TabStop = false;
            this.grupoAlternativa.Text = "Alternativas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Alternativa Correta";
            // 
            // comboAlternativaCorreta
            // 
            this.comboAlternativaCorreta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlternativaCorreta.Enabled = false;
            this.comboAlternativaCorreta.FormattingEnabled = true;
            this.comboAlternativaCorreta.Location = new System.Drawing.Point(153, 62);
            this.comboAlternativaCorreta.Name = "comboAlternativaCorreta";
            this.comboAlternativaCorreta.Size = new System.Drawing.Size(327, 28);
            this.comboAlternativaCorreta.TabIndex = 11;
            this.comboAlternativaCorreta.SelectedIndexChanged += new System.EventHandler(this.comboAlternativaCorreta_SelectedIndexChanged);
            // 
            // listaAlternativas
            // 
            this.listaAlternativas.FormattingEnabled = true;
            this.listaAlternativas.ItemHeight = 20;
            this.listaAlternativas.Location = new System.Drawing.Point(9, 122);
            this.listaAlternativas.Name = "listaAlternativas";
            this.listaAlternativas.Size = new System.Drawing.Size(471, 124);
            this.listaAlternativas.TabIndex = 4;
            this.listaAlternativas.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Descrição da Alternativa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDescricaoAlternativa
            // 
            this.txtDescricaoAlternativa.Location = new System.Drawing.Point(492, 62);
            this.txtDescricaoAlternativa.Multiline = true;
            this.txtDescricaoAlternativa.Name = "txtDescricaoAlternativa";
            this.txtDescricaoAlternativa.Size = new System.Drawing.Size(296, 132);
            this.txtDescricaoAlternativa.TabIndex = 7;
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Location = new System.Drawing.Point(104, 26);
            this.txtEnunciado.Multiline = true;
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.Size = new System.Drawing.Size(644, 78);
            this.txtEnunciado.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Enunciado";
            // 
            // CadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 579);
            this.Controls.Add(this.grupoQuestao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAnoLetivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDisciplina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroQuestaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Questão";
            this.grupoQuestao.ResumeLayout(false);
            this.grupoQuestao.PerformLayout();
            this.grupoAlternativa.ResumeLayout(false);
            this.grupoAlternativa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDisciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAnoLetivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboMateria;
        private System.Windows.Forms.GroupBox grupoQuestao;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox grupoAlternativa;
        private System.Windows.Forms.ListBox listaAlternativas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDescricaoAlternativa;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboAlternativaCorreta;
    }
}