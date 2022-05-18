namespace testesDonaMariana.WinApp.Modulos.TesteMol.Configuracoes
{
    partial class TabelaListaTeste
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
            this.gridTeste = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeste)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTeste
            // 
            this.gridTeste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTeste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeste.Location = new System.Drawing.Point(0, 0);
            this.gridTeste.Name = "gridTeste";
            this.gridTeste.RowHeadersWidth = 51;
            this.gridTeste.RowTemplate.Height = 29;
            this.gridTeste.Size = new System.Drawing.Size(603, 475);
            this.gridTeste.TabIndex = 2;
            // 
            // TabelaListaTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTeste);
            this.Name = "TabelaListaTeste";
            this.Size = new System.Drawing.Size(603, 475);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTeste;
    }
}
