namespace Projeto
{
    partial class formMenuArbitro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMenuArbitro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbArbitroTabela = new System.Windows.Forms.GroupBox();
            this.dgvTabelaJogos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gbArbitroTabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabelaJogos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Os meus Jogos";
            // 
            // gbArbitroTabela
            // 
            this.gbArbitroTabela.Controls.Add(this.dgvTabelaJogos);
            this.gbArbitroTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbArbitroTabela.Location = new System.Drawing.Point(0, 89);
            this.gbArbitroTabela.Name = "gbArbitroTabela";
            this.gbArbitroTabela.Size = new System.Drawing.Size(553, 236);
            this.gbArbitroTabela.TabIndex = 1;
            this.gbArbitroTabela.TabStop = false;
            // 
            // dgvTabelaJogos
            // 
            this.dgvTabelaJogos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTabelaJogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabelaJogos.Location = new System.Drawing.Point(39, 34);
            this.dgvTabelaJogos.Name = "dgvTabelaJogos";
            this.dgvTabelaJogos.RowTemplate.Height = 24;
            this.dgvTabelaJogos.Size = new System.Drawing.Size(477, 172);
            this.dgvTabelaJogos.TabIndex = 0;
            // 
            // formMenuArbitro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 325);
            this.Controls.Add(this.gbArbitroTabela);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMenuArbitro";
            this.Text = "Arcmage- Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMenuArbitro_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbArbitroTabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabelaJogos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbArbitroTabela;
        private System.Windows.Forms.DataGridView dgvTabelaJogos;
    }
}