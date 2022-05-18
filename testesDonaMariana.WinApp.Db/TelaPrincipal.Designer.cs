namespace testesDonaMariana.WinApp
{
    partial class TelaPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.toolboxAcoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPDF = new System.Windows.Forms.ToolStripButton();
            this.btnClonar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.toolboxAcoes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disciplinaToolStripMenuItem,
            this.questãoToolStripMenuItem,
            this.testesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // disciplinaToolStripMenuItem
            // 
            this.disciplinaToolStripMenuItem.Name = "disciplinaToolStripMenuItem";
            this.disciplinaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.disciplinaToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.disciplinaToolStripMenuItem.Text = "Disciplina / Matéria";
            this.disciplinaToolStripMenuItem.Click += new System.EventHandler(this.disciplinaToolStripMenuItem_Click);
            // 
            // questãoToolStripMenuItem
            // 
            this.questãoToolStripMenuItem.Name = "questãoToolStripMenuItem";
            this.questãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.questãoToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.questãoToolStripMenuItem.Text = "Questões";
            this.questãoToolStripMenuItem.Click += new System.EventHandler(this.questãoToolStripMenuItem_Click);
            // 
            // testesToolStripMenuItem
            // 
            this.testesToolStripMenuItem.Name = "testesToolStripMenuItem";
            this.testesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.testesToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.testesToolStripMenuItem.Text = "Testes (Prova)";
            this.testesToolStripMenuItem.Click += new System.EventHandler(this.testesToolStripMenuItem_Click);
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 69);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(902, 600);
            this.panelRegistros.TabIndex = 9999;
            // 
            // toolboxAcoes
            // 
            this.toolboxAcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolboxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.btnPDF,
            this.btnClonar,
            this.toolStripSeparator3,
            this.labelTipoCadastro});
            this.toolboxAcoes.Location = new System.Drawing.Point(0, 28);
            this.toolboxAcoes.Name = "toolboxAcoes";
            this.toolboxAcoes.Size = new System.Drawing.Size(902, 41);
            this.toolboxAcoes.TabIndex = 5;
            this.toolboxAcoes.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar.Image = global::testesDonaMariana.WinApp.Db.Properties.Resources.outline_add_circle_outline_black_24dp;
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdicionar.Size = new System.Drawing.Size(38, 38);
            this.btnAdicionar.Text = "toolStripButton1";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::testesDonaMariana.WinApp.Db.Properties.Resources.outline_mode_edit_black_24dp;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "toolStripButton1";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::testesDonaMariana.WinApp.Db.Properties.Resources.outline_delete_black_24dp;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "toolStripButton1";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // btnPDF
            // 
            this.btnPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPDF.Image = global::testesDonaMariana.WinApp.Db.Properties.Resources.pdf_removebg_preview__1__removebg_preview;
            this.btnPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(29, 38);
            this.btnPDF.Text = "toolStripButton1";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnClonar
            // 
            this.btnClonar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClonar.Image = global::testesDonaMariana.WinApp.Db.Properties.Resources._24;
            this.btnClonar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClonar.Name = "btnClonar";
            this.btnClonar.Size = new System.Drawing.Size(29, 38);
            this.btnClonar.Text = "toolStripButton1";
            this.btnClonar.Click += new System.EventHandler(this.btnClonar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(217, 38);
            this.labelTipoCadastro.Text = "Cadastro Selecionado: Nenhum";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(83, 20);
            this.labelRodape.Text = "Tudo Ok ;-)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 669);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(902, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 695);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolboxAcoes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste Dona Mariana";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolboxAcoes.ResumeLayout(false);
            this.toolboxAcoes.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questãoToolStripMenuItem;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStrip toolboxAcoes;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem testesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnPDF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClonar;
    }
}
