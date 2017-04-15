namespace Projeto
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.gbLoginImg = new System.Windows.Forms.GroupBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLoginDados = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPass = new System.Windows.Forms.TextBox();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbLoginImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbLoginDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoginImg
            // 
            this.gbLoginImg.Controls.Add(this.pbLogo);
            this.gbLoginImg.Controls.Add(this.label1);
            this.gbLoginImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLoginImg.Location = new System.Drawing.Point(0, 0);
            this.gbLoginImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginImg.Name = "gbLoginImg";
            this.gbLoginImg.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginImg.Size = new System.Drawing.Size(164, 265);
            this.gbLoginImg.TabIndex = 0;
            this.gbLoginImg.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(9, 65);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(127, 174);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arcmage";
            // 
            // gbLoginDados
            // 
            this.gbLoginDados.Controls.Add(this.btnSair);
            this.gbLoginDados.Controls.Add(this.btnLogin);
            this.gbLoginDados.Controls.Add(this.txtLoginPass);
            this.gbLoginDados.Controls.Add(this.txtLoginUser);
            this.gbLoginDados.Controls.Add(this.label3);
            this.gbLoginDados.Controls.Add(this.label2);
            this.gbLoginDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLoginDados.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLoginDados.Location = new System.Drawing.Point(164, 0);
            this.gbLoginDados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginDados.Name = "gbLoginDados";
            this.gbLoginDados.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginDados.Size = new System.Drawing.Size(218, 265);
            this.gbLoginDados.TabIndex = 1;
            this.gbLoginDados.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(82, 211);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 28);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.BotaoSairAplicacao);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(145, 211);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(54, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BotaoLoginUtilizador);
            // 
            // txtLoginPass
            // 
            this.txtLoginPass.Location = new System.Drawing.Point(82, 141);
            this.txtLoginPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLoginPass.Name = "txtLoginPass";
            this.txtLoginPass.PasswordChar = '*';
            this.txtLoginPass.Size = new System.Drawing.Size(118, 23);
            this.txtLoginPass.TabIndex = 3;
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Location = new System.Drawing.Point(82, 84);
            this.txtLoginUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.Size = new System.Drawing.Size(118, 23);
            this.txtLoginUser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Utilizador";
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 265);
            this.Controls.Add(this.gbLoginDados);
            this.Controls.Add(this.gbLoginImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 303);
            this.MinimumSize = new System.Drawing.Size(398, 303);
            this.Name = "formLogin";
            this.Text = "Arcmage - Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formLogin_FormClosed);
            this.gbLoginImg.ResumeLayout(false);
            this.gbLoginImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbLoginDados.ResumeLayout(false);
            this.gbLoginDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoginImg;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbLoginDados;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPass;
        private System.Windows.Forms.TextBox txtLoginUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

