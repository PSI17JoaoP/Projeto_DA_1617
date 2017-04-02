namespace Projeto
{
    partial class formMenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMenuAdmin));
            this.tbMenu = new System.Windows.Forms.TabControl();
            this.tpGestao = new System.Windows.Forms.TabPage();
            this.tbVer = new System.Windows.Forms.TabPage();
            this.tcGestao = new System.Windows.Forms.TabControl();
            this.tbGestaoJogadores = new System.Windows.Forms.TabPage();
            this.tbGestaoEquipas = new System.Windows.Forms.TabPage();
            this.tbGestaoTorneios = new System.Windows.Forms.TabPage();
            this.tbGestaoCartas = new System.Windows.Forms.TabPage();
            this.tbGestaoBaralhos = new System.Windows.Forms.TabPage();
            this.tbGestaoUtilizadores = new System.Windows.Forms.TabPage();
            this.tcVer = new System.Windows.Forms.TabControl();
            this.tbVerJogadores = new System.Windows.Forms.TabPage();
            this.tbVerEquipas = new System.Windows.Forms.TabPage();
            this.tbVerTorneios = new System.Windows.Forms.TabPage();
            this.tbVerCartas = new System.Windows.Forms.TabPage();
            this.tbVerBaralhos = new System.Windows.Forms.TabPage();
            this.tbVerUtilizadores = new System.Windows.Forms.TabPage();
            this.tbMenu.SuspendLayout();
            this.tpGestao.SuspendLayout();
            this.tbVer.SuspendLayout();
            this.tcGestao.SuspendLayout();
            this.tcVer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Controls.Add(this.tpGestao);
            this.tbMenu.Controls.Add(this.tbVer);
            this.tbMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMenu.Location = new System.Drawing.Point(0, 0);
            this.tbMenu.Name = "tbMenu";
            this.tbMenu.SelectedIndex = 0;
            this.tbMenu.Size = new System.Drawing.Size(845, 493);
            this.tbMenu.TabIndex = 0;
            // 
            // tpGestao
            // 
            this.tpGestao.Controls.Add(this.tcGestao);
            this.tpGestao.Location = new System.Drawing.Point(4, 25);
            this.tpGestao.Name = "tpGestao";
            this.tpGestao.Padding = new System.Windows.Forms.Padding(3);
            this.tpGestao.Size = new System.Drawing.Size(837, 464);
            this.tpGestao.TabIndex = 0;
            this.tpGestao.Text = "Gestão";
            this.tpGestao.UseVisualStyleBackColor = true;
            // 
            // tbVer
            // 
            this.tbVer.Controls.Add(this.tcVer);
            this.tbVer.Location = new System.Drawing.Point(4, 25);
            this.tbVer.Name = "tbVer";
            this.tbVer.Padding = new System.Windows.Forms.Padding(3);
            this.tbVer.Size = new System.Drawing.Size(837, 464);
            this.tbVer.TabIndex = 1;
            this.tbVer.Text = "Ver";
            this.tbVer.UseVisualStyleBackColor = true;
            // 
            // tcGestao
            // 
            this.tcGestao.Controls.Add(this.tbGestaoJogadores);
            this.tcGestao.Controls.Add(this.tbGestaoEquipas);
            this.tcGestao.Controls.Add(this.tbGestaoTorneios);
            this.tcGestao.Controls.Add(this.tbGestaoCartas);
            this.tcGestao.Controls.Add(this.tbGestaoBaralhos);
            this.tcGestao.Controls.Add(this.tbGestaoUtilizadores);
            this.tcGestao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcGestao.Location = new System.Drawing.Point(3, 3);
            this.tcGestao.Name = "tcGestao";
            this.tcGestao.SelectedIndex = 0;
            this.tcGestao.Size = new System.Drawing.Size(831, 458);
            this.tcGestao.TabIndex = 0;
            // 
            // tbGestaoJogadores
            // 
            this.tbGestaoJogadores.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoJogadores.Name = "tbGestaoJogadores";
            this.tbGestaoJogadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoJogadores.Size = new System.Drawing.Size(823, 429);
            this.tbGestaoJogadores.TabIndex = 0;
            this.tbGestaoJogadores.Text = "Jogadores";
            this.tbGestaoJogadores.UseVisualStyleBackColor = true;
            // 
            // tbGestaoEquipas
            // 
            this.tbGestaoEquipas.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoEquipas.Name = "tbGestaoEquipas";
            this.tbGestaoEquipas.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoEquipas.Size = new System.Drawing.Size(931, 514);
            this.tbGestaoEquipas.TabIndex = 1;
            this.tbGestaoEquipas.Text = "Equipas";
            this.tbGestaoEquipas.UseVisualStyleBackColor = true;
            // 
            // tbGestaoTorneios
            // 
            this.tbGestaoTorneios.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoTorneios.Name = "tbGestaoTorneios";
            this.tbGestaoTorneios.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoTorneios.Size = new System.Drawing.Size(931, 514);
            this.tbGestaoTorneios.TabIndex = 2;
            this.tbGestaoTorneios.Text = "Torneios";
            this.tbGestaoTorneios.UseVisualStyleBackColor = true;
            // 
            // tbGestaoCartas
            // 
            this.tbGestaoCartas.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoCartas.Name = "tbGestaoCartas";
            this.tbGestaoCartas.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoCartas.Size = new System.Drawing.Size(931, 514);
            this.tbGestaoCartas.TabIndex = 3;
            this.tbGestaoCartas.Text = "Cartas";
            this.tbGestaoCartas.UseVisualStyleBackColor = true;
            // 
            // tbGestaoBaralhos
            // 
            this.tbGestaoBaralhos.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoBaralhos.Name = "tbGestaoBaralhos";
            this.tbGestaoBaralhos.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoBaralhos.Size = new System.Drawing.Size(931, 514);
            this.tbGestaoBaralhos.TabIndex = 4;
            this.tbGestaoBaralhos.Text = "Baralhos";
            this.tbGestaoBaralhos.UseVisualStyleBackColor = true;
            // 
            // tbGestaoUtilizadores
            // 
            this.tbGestaoUtilizadores.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoUtilizadores.Name = "tbGestaoUtilizadores";
            this.tbGestaoUtilizadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoUtilizadores.Size = new System.Drawing.Size(931, 514);
            this.tbGestaoUtilizadores.TabIndex = 5;
            this.tbGestaoUtilizadores.Text = "Utilizadores";
            this.tbGestaoUtilizadores.UseVisualStyleBackColor = true;
            // 
            // tcVer
            // 
            this.tcVer.Controls.Add(this.tbVerJogadores);
            this.tcVer.Controls.Add(this.tbVerEquipas);
            this.tcVer.Controls.Add(this.tbVerTorneios);
            this.tcVer.Controls.Add(this.tbVerCartas);
            this.tcVer.Controls.Add(this.tbVerBaralhos);
            this.tcVer.Controls.Add(this.tbVerUtilizadores);
            this.tcVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcVer.Location = new System.Drawing.Point(3, 3);
            this.tcVer.Name = "tcVer";
            this.tcVer.SelectedIndex = 0;
            this.tcVer.Size = new System.Drawing.Size(831, 458);
            this.tcVer.TabIndex = 0;
            // 
            // tbVerJogadores
            // 
            this.tbVerJogadores.Location = new System.Drawing.Point(4, 25);
            this.tbVerJogadores.Name = "tbVerJogadores";
            this.tbVerJogadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerJogadores.Size = new System.Drawing.Size(823, 429);
            this.tbVerJogadores.TabIndex = 0;
            this.tbVerJogadores.Text = "Jogadores";
            this.tbVerJogadores.UseVisualStyleBackColor = true;
            // 
            // tbVerEquipas
            // 
            this.tbVerEquipas.Location = new System.Drawing.Point(4, 25);
            this.tbVerEquipas.Name = "tbVerEquipas";
            this.tbVerEquipas.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerEquipas.Size = new System.Drawing.Size(931, 514);
            this.tbVerEquipas.TabIndex = 1;
            this.tbVerEquipas.Text = "Equipas";
            this.tbVerEquipas.UseVisualStyleBackColor = true;
            // 
            // tbVerTorneios
            // 
            this.tbVerTorneios.Location = new System.Drawing.Point(4, 25);
            this.tbVerTorneios.Name = "tbVerTorneios";
            this.tbVerTorneios.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerTorneios.Size = new System.Drawing.Size(931, 514);
            this.tbVerTorneios.TabIndex = 2;
            this.tbVerTorneios.Text = "Torneios";
            this.tbVerTorneios.UseVisualStyleBackColor = true;
            // 
            // tbVerCartas
            // 
            this.tbVerCartas.Location = new System.Drawing.Point(4, 25);
            this.tbVerCartas.Name = "tbVerCartas";
            this.tbVerCartas.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerCartas.Size = new System.Drawing.Size(931, 514);
            this.tbVerCartas.TabIndex = 3;
            this.tbVerCartas.Text = "Cartas";
            this.tbVerCartas.UseVisualStyleBackColor = true;
            // 
            // tbVerBaralhos
            // 
            this.tbVerBaralhos.Location = new System.Drawing.Point(4, 25);
            this.tbVerBaralhos.Name = "tbVerBaralhos";
            this.tbVerBaralhos.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerBaralhos.Size = new System.Drawing.Size(931, 514);
            this.tbVerBaralhos.TabIndex = 4;
            this.tbVerBaralhos.Text = "Baralhos";
            this.tbVerBaralhos.UseVisualStyleBackColor = true;
            // 
            // tbVerUtilizadores
            // 
            this.tbVerUtilizadores.Location = new System.Drawing.Point(4, 25);
            this.tbVerUtilizadores.Name = "tbVerUtilizadores";
            this.tbVerUtilizadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerUtilizadores.Size = new System.Drawing.Size(931, 514);
            this.tbVerUtilizadores.TabIndex = 5;
            this.tbVerUtilizadores.Text = "Utilizadores";
            this.tbVerUtilizadores.UseVisualStyleBackColor = true;
            // 
            // formMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 493);
            this.Controls.Add(this.tbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMenuAdmin";
            this.Text = "Arcmage - Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMenuAdmin_FormClosed);
            this.tbMenu.ResumeLayout(false);
            this.tpGestao.ResumeLayout(false);
            this.tbVer.ResumeLayout(false);
            this.tcGestao.ResumeLayout(false);
            this.tcVer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMenu;
        private System.Windows.Forms.TabPage tpGestao;
        private System.Windows.Forms.TabControl tcGestao;
        private System.Windows.Forms.TabPage tbGestaoJogadores;
        private System.Windows.Forms.TabPage tbGestaoEquipas;
        private System.Windows.Forms.TabPage tbGestaoTorneios;
        private System.Windows.Forms.TabPage tbGestaoCartas;
        private System.Windows.Forms.TabPage tbGestaoBaralhos;
        private System.Windows.Forms.TabPage tbGestaoUtilizadores;
        private System.Windows.Forms.TabPage tbVer;
        private System.Windows.Forms.TabControl tcVer;
        private System.Windows.Forms.TabPage tbVerJogadores;
        private System.Windows.Forms.TabPage tbVerEquipas;
        private System.Windows.Forms.TabPage tbVerTorneios;
        private System.Windows.Forms.TabPage tbVerCartas;
        private System.Windows.Forms.TabPage tbVerBaralhos;
        private System.Windows.Forms.TabPage tbVerUtilizadores;
    }
}