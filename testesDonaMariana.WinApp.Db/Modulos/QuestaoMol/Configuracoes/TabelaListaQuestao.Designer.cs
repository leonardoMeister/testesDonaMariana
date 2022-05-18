namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.Configuracoes
{
    partial class TabelaListaQuestao
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
            this.gridQuestao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestao)).BeginInit();
            this.SuspendLayout();
            // 
            // gridQuestao
            // 
            this.gridQuestao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQuestao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQuestao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuestao.Location = new System.Drawing.Point(0, 0);
            this.gridQuestao.Name = "gridQuestao";
            this.gridQuestao.RowHeadersWidth = 51;
            this.gridQuestao.RowTemplate.Height = 29;
            this.gridQuestao.Size = new System.Drawing.Size(604, 476);
            this.gridQuestao.TabIndex = 1;
            // 
            // TabelaListaQuestao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridQuestao);
            this.Name = "TabelaListaQuestao";
            this.Size = new System.Drawing.Size(604, 476);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridQuestao;
    }
}
