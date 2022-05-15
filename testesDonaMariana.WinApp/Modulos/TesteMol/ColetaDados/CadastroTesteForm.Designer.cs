namespace testesDonaMariana.WinApp.Modulos.TesteMol.ColetaDados
{
    partial class CadastroTesteForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboAnoLetivo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDisciplina = new System.Windows.Forms.ComboBox();
            this.grupoTeste = new System.Windows.Forms.GroupBox();
            this.lista1 = new System.Windows.Forms.ListBox();
            this.lista2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeTeste = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroQuestoes = new System.Windows.Forms.MaskedTextBox();
            this.grupoTeste.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ano Letivo";
            // 
            // comboAnoLetivo
            // 
            this.comboAnoLetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnoLetivo.FormattingEnabled = true;
            this.comboAnoLetivo.Location = new System.Drawing.Point(106, 12);
            this.comboAnoLetivo.Name = "comboAnoLetivo";
            this.comboAnoLetivo.Size = new System.Drawing.Size(306, 28);
            this.comboAnoLetivo.TabIndex = 8;
            this.comboAnoLetivo.SelectedIndexChanged += new System.EventHandler(this.comboAnoLetivo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Disciplina";
            // 
            // comboDisciplina
            // 
            this.comboDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisciplina.Enabled = false;
            this.comboDisciplina.FormattingEnabled = true;
            this.comboDisciplina.Location = new System.Drawing.Point(507, 12);
            this.comboDisciplina.Name = "comboDisciplina";
            this.comboDisciplina.Size = new System.Drawing.Size(306, 28);
            this.comboDisciplina.TabIndex = 6;
            this.comboDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboDisciplina_SelectedIndexChanged);
            // 
            // grupoTeste
            // 
            this.grupoTeste.Controls.Add(this.txtNumeroQuestoes);
            this.grupoTeste.Controls.Add(this.label5);
            this.grupoTeste.Controls.Add(this.btnConfirmar);
            this.grupoTeste.Controls.Add(this.btnCancelar);
            this.grupoTeste.Controls.Add(this.txtNomeTeste);
            this.grupoTeste.Controls.Add(this.label4);
            this.grupoTeste.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grupoTeste.Location = new System.Drawing.Point(0, 294);
            this.grupoTeste.Name = "grupoTeste";
            this.grupoTeste.Size = new System.Drawing.Size(828, 82);
            this.grupoTeste.TabIndex = 12;
            this.grupoTeste.TabStop = false;
            this.grupoTeste.Text = "Dados Teste";
            // 
            // lista1
            // 
            this.lista1.Cursor = System.Windows.Forms.Cursors.No;
            this.lista1.FormattingEnabled = true;
            this.lista1.ItemHeight = 20;
            this.lista1.Location = new System.Drawing.Point(18, 86);
            this.lista1.Name = "lista1";
            this.lista1.Size = new System.Drawing.Size(400, 204);
            this.lista1.TabIndex = 13;
            this.lista1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lista1_MouseDoubleClick);
            // 
            // lista2
            // 
            this.lista2.FormattingEnabled = true;
            this.lista2.ItemHeight = 20;
            this.lista2.Location = new System.Drawing.Point(427, 86);
            this.lista2.Name = "lista2";
            this.lista2.Size = new System.Drawing.Size(395, 204);
            this.lista2.TabIndex = 14;
            this.lista2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lista2_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Materias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nome Teste";
            // 
            // txtNomeTeste
            // 
            this.txtNomeTeste.Location = new System.Drawing.Point(114, 34);
            this.txtNomeTeste.Name = "txtNomeTeste";
            this.txtNomeTeste.Size = new System.Drawing.Size(151, 27);
            this.txtNomeTeste.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(600, 34);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 38);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(714, 34);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(108, 38);
            this.btnConfirmar.TabIndex = 18;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Numero Questoes";
            // 
            // txtNumeroQuestoes
            // 
            this.txtNumeroQuestoes.Location = new System.Drawing.Point(442, 34);
            this.txtNumeroQuestoes.Mask = "00000";
            this.txtNumeroQuestoes.Name = "txtNumeroQuestoes";
            this.txtNumeroQuestoes.Size = new System.Drawing.Size(77, 27);
            this.txtNumeroQuestoes.TabIndex = 21;
            this.txtNumeroQuestoes.ValidatingType = typeof(int);
            // 
            // CadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 376);
            this.Controls.Add(this.grupoTeste);
            this.Controls.Add(this.lista2);
            this.Controls.Add(this.lista1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAnoLetivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDisciplina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroTesteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Teste";
            this.grupoTeste.ResumeLayout(false);
            this.grupoTeste.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAnoLetivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDisciplina;
        private System.Windows.Forms.GroupBox grupoTeste;
        private System.Windows.Forms.ListBox lista1;
        private System.Windows.Forms.ListBox lista2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNomeTeste;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtNumeroQuestoes;
    }
}