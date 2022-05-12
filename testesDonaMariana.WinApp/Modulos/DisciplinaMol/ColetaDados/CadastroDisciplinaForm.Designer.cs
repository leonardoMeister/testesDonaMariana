using testesDonaMariana.WinApp.Shared;

namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.ColetaDados
{
    partial class CadastroDisciplinaForm
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
            this.comboAnoLetivo = new System.Windows.Forms.ComboBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.gpDisciplina = new System.Windows.Forms.GroupBox();
            this.valida2 = new System.Windows.Forms.Button();
            this.valida1 = new System.Windows.Forms.Button();
            this.gpMateria = new System.Windows.Forms.GroupBox();
            this.valida3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.valida4 = new System.Windows.Forms.Button();
            this.box1 = new System.Windows.Forms.CheckBox();
            this.box4 = new System.Windows.Forms.CheckBox();
            this.box2 = new System.Windows.Forms.CheckBox();
            this.box3 = new System.Windows.Forms.CheckBox();
            this.txtNomeMateria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.listaMaterias = new System.Windows.Forms.ListBox();
            this.gpDisciplina.SuspendLayout();
            this.gpMateria.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboAnoLetivo
            // 
            this.comboAnoLetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnoLetivo.FormattingEnabled = true;
            this.comboAnoLetivo.Location = new System.Drawing.Point(170, 82);
            this.comboAnoLetivo.Name = "comboAnoLetivo";
            this.comboAnoLetivo.Size = new System.Drawing.Size(228, 28);
            this.comboAnoLetivo.TabIndex = 3;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(631, 553);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(125, 43);
            this.btnGravar.TabIndex = 14;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(500, 553);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 43);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome Disciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ano Letivo";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(170, 37);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(228, 27);
            this.txtNome.TabIndex = 2;
            // 
            // gpDisciplina
            // 
            this.gpDisciplina.Controls.Add(this.valida2);
            this.gpDisciplina.Controls.Add(this.valida1);
            this.gpDisciplina.Controls.Add(this.label2);
            this.gpDisciplina.Controls.Add(this.comboAnoLetivo);
            this.gpDisciplina.Controls.Add(this.txtNome);
            this.gpDisciplina.Controls.Add(this.label1);
            this.gpDisciplina.Location = new System.Drawing.Point(12, 12);
            this.gpDisciplina.Name = "gpDisciplina";
            this.gpDisciplina.Size = new System.Drawing.Size(670, 125);
            this.gpDisciplina.TabIndex = 0;
            this.gpDisciplina.TabStop = false;
            this.gpDisciplina.Text = "Dados Disciplina";
            // 
            // valida2
            // 
            this.valida2.Image = global::testesDonaMariana.WinApp.Properties.Resources.erro;
            this.valida2.Location = new System.Drawing.Point(404, 82);
            this.valida2.Name = "valida2";
            this.valida2.Size = new System.Drawing.Size(30, 29);
            this.valida2.TabIndex = 6;
            this.valida2.UseVisualStyleBackColor = true;
            // 
            // valida1
            // 
            this.valida1.Image = global::testesDonaMariana.WinApp.Properties.Resources.Ok_;
            this.valida1.Location = new System.Drawing.Point(404, 36);
            this.valida1.Name = "valida1";
            this.valida1.Size = new System.Drawing.Size(30, 29);
            this.valida1.TabIndex = 5;
            this.valida1.UseVisualStyleBackColor = true;
            // 
            // gpMateria
            // 
            this.gpMateria.Controls.Add(this.valida3);
            this.gpMateria.Controls.Add(this.groupBox1);
            this.gpMateria.Controls.Add(this.txtNomeMateria);
            this.gpMateria.Controls.Add(this.label3);
            this.gpMateria.Controls.Add(this.btnLimpar);
            this.gpMateria.Controls.Add(this.btnRemover);
            this.gpMateria.Controls.Add(this.btnAdicionar);
            this.gpMateria.Controls.Add(this.listaMaterias);
            this.gpMateria.Location = new System.Drawing.Point(12, 143);
            this.gpMateria.Name = "gpMateria";
            this.gpMateria.Size = new System.Drawing.Size(744, 401);
            this.gpMateria.TabIndex = 1;
            this.gpMateria.TabStop = false;
            this.gpMateria.Text = "Dados Matéria";
            // 
            // valida3
            // 
            this.valida3.Image = global::testesDonaMariana.WinApp.Properties.Resources.erro;
            this.valida3.Location = new System.Drawing.Point(707, 79);
            this.valida3.Name = "valida3";
            this.valida3.Size = new System.Drawing.Size(30, 29);
            this.valida3.TabIndex = 7;
            this.valida3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.valida4);
            this.groupBox1.Controls.Add(this.box1);
            this.groupBox1.Controls.Add(this.box4);
            this.groupBox1.Controls.Add(this.box2);
            this.groupBox1.Controls.Add(this.box3);
            this.groupBox1.Location = new System.Drawing.Point(494, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bimestre Correspondente";
            // 
            // valida4
            // 
            this.valida4.Image = global::testesDonaMariana.WinApp.Properties.Resources.erro;
            this.valida4.Location = new System.Drawing.Point(200, 90);
            this.valida4.Name = "valida4";
            this.valida4.Size = new System.Drawing.Size(30, 29);
            this.valida4.TabIndex = 7;
            this.valida4.UseVisualStyleBackColor = true;
            // 
            // box1
            // 
            this.box1.AutoSize = true;
            this.box1.Checked = true;
            this.box1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box1.Location = new System.Drawing.Point(6, 37);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(87, 24);
            this.box1.TabIndex = 5;
            this.box1.Text = "Primeiro";
            this.box1.UseVisualStyleBackColor = true;
            // 
            // box4
            // 
            this.box4.AutoSize = true;
            this.box4.Location = new System.Drawing.Point(130, 67);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(77, 24);
            this.box4.TabIndex = 8;
            this.box4.Text = "Quarto";
            this.box4.UseVisualStyleBackColor = true;
            // 
            // box2
            // 
            this.box2.AutoSize = true;
            this.box2.Location = new System.Drawing.Point(130, 37);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(90, 24);
            this.box2.TabIndex = 6;
            this.box2.Text = "Segundo";
            this.box2.UseVisualStyleBackColor = true;
            // 
            // box3
            // 
            this.box3.AutoSize = true;
            this.box3.Location = new System.Drawing.Point(6, 67);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(84, 24);
            this.box3.TabIndex = 7;
            this.box3.Text = "Terceiro";
            this.box3.UseVisualStyleBackColor = true;
            // 
            // txtNomeMateria
            // 
            this.txtNomeMateria.Location = new System.Drawing.Point(502, 81);
            this.txtNomeMateria.Name = "txtNomeMateria";
            this.txtNomeMateria.Size = new System.Drawing.Size(199, 27);
            this.txtNomeMateria.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nome Materia";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(531, 287);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(160, 29);
            this.btnLimpar.TabIndex = 9;
            this.btnLimpar.Text = "Limpar Seleção";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(619, 322);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(94, 29);
            this.btnRemover.TabIndex = 12;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(502, 322);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(94, 29);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // listaMaterias
            // 
            this.listaMaterias.FormattingEnabled = true;
            this.listaMaterias.ItemHeight = 20;
            this.listaMaterias.Location = new System.Drawing.Point(13, 26);
            this.listaMaterias.Name = "listaMaterias";
            this.listaMaterias.Size = new System.Drawing.Size(469, 364);
            this.listaMaterias.TabIndex = 0;
            this.listaMaterias.TabStop = false;
            this.listaMaterias.SelectedValueChanged += new System.EventHandler(this.listaMaterias_SelecionouUmItemNaLista);
            // 
            // CadastroDisciplinaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 608);
            this.Controls.Add(this.gpMateria);
            this.Controls.Add(this.gpDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroDisciplinaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Cadastro Disciplina";
            this.gpDisciplina.ResumeLayout(false);
            this.gpDisciplina.PerformLayout();
            this.gpMateria.ResumeLayout(false);
            this.gpMateria.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAnoLetivo;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox gpDisciplina;
        private System.Windows.Forms.GroupBox gpMateria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox box1;
        private System.Windows.Forms.CheckBox box4;
        private System.Windows.Forms.CheckBox box2;
        private System.Windows.Forms.CheckBox box3;
        private System.Windows.Forms.TextBox txtNomeMateria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox listaMaterias;
        private System.Windows.Forms.Button valida2;
        private System.Windows.Forms.Button valida1;
        private System.Windows.Forms.Button valida3;
        private System.Windows.Forms.Button valida4;
        private System.Windows.Forms.Button btnLimpar;
    }
}