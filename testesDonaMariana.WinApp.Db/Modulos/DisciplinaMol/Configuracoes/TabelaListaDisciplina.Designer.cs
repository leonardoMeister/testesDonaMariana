namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes
{
    partial class TabelaListaDisciplina
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridDisciplina = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDisciplina)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDisciplina
            // 
            this.gridDisciplina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDisciplina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDisciplina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDisciplina.Location = new System.Drawing.Point(0, 0);
            this.gridDisciplina.Name = "gridDisciplina";
            this.gridDisciplina.RowHeadersWidth = 51;
            this.gridDisciplina.RowTemplate.Height = 29;
            this.gridDisciplina.Size = new System.Drawing.Size(603, 475);
            this.gridDisciplina.TabIndex = 0;
            // 
            // TabelaListaDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDisciplina);
            this.Name = "TabelaListaDisciplina";
            this.Size = new System.Drawing.Size(603, 475);
            ((System.ComponentModel.ISupportInitialize)(this.gridDisciplina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDisciplina;
    }
}
