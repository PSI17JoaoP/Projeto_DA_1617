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
            this.tcGestao = new System.Windows.Forms.TabControl();
            this.tbGestaoJogadores = new System.Windows.Forms.TabPage();
            this.gbGJogadoresForm = new System.Windows.Forms.GroupBox();
            this.btnJogadoresCancelar = new System.Windows.Forms.Button();
            this.btnJogadoresAcao = new System.Windows.Forms.Button();
            this.nudIdadeJogador = new System.Windows.Forms.NumericUpDown();
            this.txtNickJogador = new System.Windows.Forms.TextBox();
            this.txtEmailJogador = new System.Windows.Forms.TextBox();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbGJogadoresAcoes = new System.Windows.Forms.GroupBox();
            this.btnRemoverJogador = new System.Windows.Forms.Button();
            this.btnAlterarJogador = new System.Windows.Forms.Button();
            this.btnInserirJogador = new System.Windows.Forms.Button();
            this.gbGJogadoresDados = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGListaJogadores = new System.Windows.Forms.DataGridView();
            this.txtGJogadoresPesquisa = new System.Windows.Forms.TextBox();
            this.tbGestaoEquipas = new System.Windows.Forms.TabPage();
            this.gbGEquipasForm = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbGEquipasAcoes = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gbGEquipasDados = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvGListaEquipas = new System.Windows.Forms.DataGridView();
            this.txtGEquipasPesquisa = new System.Windows.Forms.TextBox();
            this.tbGestaoTorneios = new System.Windows.Forms.TabPage();
            this.tbGestaoCartas = new System.Windows.Forms.TabPage();
            this.tbGestaoBaralhos = new System.Windows.Forms.TabPage();
            this.tbGestaoUtilizadores = new System.Windows.Forms.TabPage();
            this.tbVer = new System.Windows.Forms.TabPage();
            this.tcVer = new System.Windows.Forms.TabControl();
            this.tbVerJogadores = new System.Windows.Forms.TabPage();
            this.tbVerEquipas = new System.Windows.Forms.TabPage();
            this.tbVerTorneios = new System.Windows.Forms.TabPage();
            this.tbVerCartas = new System.Windows.Forms.TabPage();
            this.tbVerBaralhos = new System.Windows.Forms.TabPage();
            this.tbVerUtilizadores = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.tbMenu.SuspendLayout();
            this.tpGestao.SuspendLayout();
            this.tcGestao.SuspendLayout();
            this.tbGestaoJogadores.SuspendLayout();
            this.gbGJogadoresForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdadeJogador)).BeginInit();
            this.gbGJogadoresAcoes.SuspendLayout();
            this.gbGJogadoresDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaJogadores)).BeginInit();
            this.tbGestaoEquipas.SuspendLayout();
            this.gbGEquipasForm.SuspendLayout();
            this.gbGEquipasAcoes.SuspendLayout();
            this.gbGEquipasDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaEquipas)).BeginInit();
            this.tbVer.SuspendLayout();
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
            this.tbMenu.Size = new System.Drawing.Size(736, 451);
            this.tbMenu.TabIndex = 0;
            // 
            // tpGestao
            // 
            this.tpGestao.Controls.Add(this.tcGestao);
            this.tpGestao.Location = new System.Drawing.Point(4, 25);
            this.tpGestao.Name = "tpGestao";
            this.tpGestao.Padding = new System.Windows.Forms.Padding(3);
            this.tpGestao.Size = new System.Drawing.Size(728, 422);
            this.tpGestao.TabIndex = 0;
            this.tpGestao.Text = "Gestão";
            this.tpGestao.UseVisualStyleBackColor = true;
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
            this.tcGestao.Size = new System.Drawing.Size(722, 416);
            this.tcGestao.TabIndex = 0;
            // 
            // tbGestaoJogadores
            // 
            this.tbGestaoJogadores.Controls.Add(this.gbGJogadoresForm);
            this.tbGestaoJogadores.Controls.Add(this.gbGJogadoresAcoes);
            this.tbGestaoJogadores.Controls.Add(this.gbGJogadoresDados);
            this.tbGestaoJogadores.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoJogadores.Name = "tbGestaoJogadores";
            this.tbGestaoJogadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoJogadores.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoJogadores.TabIndex = 0;
            this.tbGestaoJogadores.Text = "Jogadores";
            this.tbGestaoJogadores.UseVisualStyleBackColor = true;
            // 
            // gbGJogadoresForm
            // 
            this.gbGJogadoresForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGJogadoresForm.Controls.Add(this.btnJogadoresCancelar);
            this.gbGJogadoresForm.Controls.Add(this.btnJogadoresAcao);
            this.gbGJogadoresForm.Controls.Add(this.nudIdadeJogador);
            this.gbGJogadoresForm.Controls.Add(this.txtNickJogador);
            this.gbGJogadoresForm.Controls.Add(this.txtEmailJogador);
            this.gbGJogadoresForm.Controls.Add(this.txtNomeJogador);
            this.gbGJogadoresForm.Controls.Add(this.label5);
            this.gbGJogadoresForm.Controls.Add(this.label4);
            this.gbGJogadoresForm.Controls.Add(this.label3);
            this.gbGJogadoresForm.Controls.Add(this.label2);
            this.gbGJogadoresForm.Location = new System.Drawing.Point(382, 94);
            this.gbGJogadoresForm.Name = "gbGJogadoresForm";
            this.gbGJogadoresForm.Size = new System.Drawing.Size(326, 288);
            this.gbGJogadoresForm.TabIndex = 5;
            this.gbGJogadoresForm.TabStop = false;
            this.gbGJogadoresForm.Text = "Campos";
            // 
            // btnJogadoresCancelar
            // 
            this.btnJogadoresCancelar.Location = new System.Drawing.Point(223, 210);
            this.btnJogadoresCancelar.Name = "btnJogadoresCancelar";
            this.btnJogadoresCancelar.Size = new System.Drawing.Size(83, 26);
            this.btnJogadoresCancelar.TabIndex = 9;
            this.btnJogadoresCancelar.Text = "Cancelar";
            this.btnJogadoresCancelar.UseVisualStyleBackColor = true;
            // 
            // btnJogadoresAcao
            // 
            this.btnJogadoresAcao.Location = new System.Drawing.Point(142, 210);
            this.btnJogadoresAcao.Name = "btnJogadoresAcao";
            this.btnJogadoresAcao.Size = new System.Drawing.Size(75, 26);
            this.btnJogadoresAcao.TabIndex = 8;
            this.btnJogadoresAcao.Text = "Ação";
            this.btnJogadoresAcao.UseVisualStyleBackColor = true;
            // 
            // nudIdadeJogador
            // 
            this.nudIdadeJogador.Location = new System.Drawing.Point(97, 160);
            this.nudIdadeJogador.Name = "nudIdadeJogador";
            this.nudIdadeJogador.Size = new System.Drawing.Size(54, 22);
            this.nudIdadeJogador.TabIndex = 7;
            // 
            // txtNickJogador
            // 
            this.txtNickJogador.Location = new System.Drawing.Point(97, 118);
            this.txtNickJogador.Name = "txtNickJogador";
            this.txtNickJogador.Size = new System.Drawing.Size(162, 22);
            this.txtNickJogador.TabIndex = 6;
            // 
            // txtEmailJogador
            // 
            this.txtEmailJogador.Location = new System.Drawing.Point(97, 77);
            this.txtEmailJogador.Name = "txtEmailJogador";
            this.txtEmailJogador.Size = new System.Drawing.Size(162, 22);
            this.txtEmailJogador.TabIndex = 5;
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(97, 35);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(162, 22);
            this.txtNomeJogador.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Idade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nickname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome";
            // 
            // gbGJogadoresAcoes
            // 
            this.gbGJogadoresAcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGJogadoresAcoes.Controls.Add(this.btnRemoverJogador);
            this.gbGJogadoresAcoes.Controls.Add(this.btnAlterarJogador);
            this.gbGJogadoresAcoes.Controls.Add(this.btnInserirJogador);
            this.gbGJogadoresAcoes.Location = new System.Drawing.Point(382, 0);
            this.gbGJogadoresAcoes.Name = "gbGJogadoresAcoes";
            this.gbGJogadoresAcoes.Size = new System.Drawing.Size(326, 92);
            this.gbGJogadoresAcoes.TabIndex = 4;
            this.gbGJogadoresAcoes.TabStop = false;
            this.gbGJogadoresAcoes.Text = "Ações";
            // 
            // btnRemoverJogador
            // 
            this.btnRemoverJogador.Location = new System.Drawing.Point(223, 43);
            this.btnRemoverJogador.Name = "btnRemoverJogador";
            this.btnRemoverJogador.Size = new System.Drawing.Size(83, 30);
            this.btnRemoverJogador.TabIndex = 2;
            this.btnRemoverJogador.Text = "Eliminar";
            this.btnRemoverJogador.UseVisualStyleBackColor = true;
            // 
            // btnAlterarJogador
            // 
            this.btnAlterarJogador.Location = new System.Drawing.Point(129, 43);
            this.btnAlterarJogador.Name = "btnAlterarJogador";
            this.btnAlterarJogador.Size = new System.Drawing.Size(77, 30);
            this.btnAlterarJogador.TabIndex = 1;
            this.btnAlterarJogador.Text = "Alterar";
            this.btnAlterarJogador.UseVisualStyleBackColor = true;
            // 
            // btnInserirJogador
            // 
            this.btnInserirJogador.Location = new System.Drawing.Point(24, 43);
            this.btnInserirJogador.Name = "btnInserirJogador";
            this.btnInserirJogador.Size = new System.Drawing.Size(83, 30);
            this.btnInserirJogador.TabIndex = 0;
            this.btnInserirJogador.Text = "Inserir";
            this.btnInserirJogador.UseVisualStyleBackColor = true;
            // 
            // gbGJogadoresDados
            // 
            this.gbGJogadoresDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGJogadoresDados.Controls.Add(this.label1);
            this.gbGJogadoresDados.Controls.Add(this.dgvGListaJogadores);
            this.gbGJogadoresDados.Controls.Add(this.txtGJogadoresPesquisa);
            this.gbGJogadoresDados.Location = new System.Drawing.Point(6, 0);
            this.gbGJogadoresDados.Name = "gbGJogadoresDados";
            this.gbGJogadoresDados.Size = new System.Drawing.Size(376, 382);
            this.gbGJogadoresDados.TabIndex = 3;
            this.gbGJogadoresDados.TabStop = false;
            this.gbGJogadoresDados.Text = "Dados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquise:";
            // 
            // dgvGListaJogadores
            // 
            this.dgvGListaJogadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGListaJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGListaJogadores.Location = new System.Drawing.Point(25, 94);
            this.dgvGListaJogadores.Name = "dgvGListaJogadores";
            this.dgvGListaJogadores.RowTemplate.Height = 24;
            this.dgvGListaJogadores.Size = new System.Drawing.Size(320, 264);
            this.dgvGListaJogadores.TabIndex = 0;
            // 
            // txtGJogadoresPesquisa
            // 
            this.txtGJogadoresPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGJogadoresPesquisa.Location = new System.Drawing.Point(98, 43);
            this.txtGJogadoresPesquisa.Name = "txtGJogadoresPesquisa";
            this.txtGJogadoresPesquisa.Size = new System.Drawing.Size(155, 22);
            this.txtGJogadoresPesquisa.TabIndex = 1;
            // 
            // tbGestaoEquipas
            // 
            this.tbGestaoEquipas.Controls.Add(this.gbGEquipasForm);
            this.tbGestaoEquipas.Controls.Add(this.gbGEquipasAcoes);
            this.tbGestaoEquipas.Controls.Add(this.gbGEquipasDados);
            this.tbGestaoEquipas.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoEquipas.Name = "tbGestaoEquipas";
            this.tbGestaoEquipas.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoEquipas.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoEquipas.TabIndex = 1;
            this.tbGestaoEquipas.Text = "Equipas";
            this.tbGestaoEquipas.UseVisualStyleBackColor = true;
            // 
            // gbGEquipasForm
            // 
            this.gbGEquipasForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGEquipasForm.Controls.Add(this.button4);
            this.gbGEquipasForm.Controls.Add(this.label8);
            this.gbGEquipasForm.Controls.Add(this.label7);
            this.gbGEquipasForm.Location = new System.Drawing.Point(382, 94);
            this.gbGEquipasForm.Name = "gbGEquipasForm";
            this.gbGEquipasForm.Size = new System.Drawing.Size(326, 288);
            this.gbGEquipasForm.TabIndex = 6;
            this.gbGEquipasForm.TabStop = false;
            this.gbGEquipasForm.Text = "Campos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Avatar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nome";
            // 
            // gbGEquipasAcoes
            // 
            this.gbGEquipasAcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGEquipasAcoes.Controls.Add(this.button1);
            this.gbGEquipasAcoes.Controls.Add(this.button2);
            this.gbGEquipasAcoes.Controls.Add(this.button3);
            this.gbGEquipasAcoes.Location = new System.Drawing.Point(382, 0);
            this.gbGEquipasAcoes.Name = "gbGEquipasAcoes";
            this.gbGEquipasAcoes.Size = new System.Drawing.Size(326, 92);
            this.gbGEquipasAcoes.TabIndex = 5;
            this.gbGEquipasAcoes.TabStop = false;
            this.gbGEquipasAcoes.Text = "Ações";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Alterar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "Inserir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gbGEquipasDados
            // 
            this.gbGEquipasDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGEquipasDados.Controls.Add(this.label6);
            this.gbGEquipasDados.Controls.Add(this.dgvGListaEquipas);
            this.gbGEquipasDados.Controls.Add(this.txtGEquipasPesquisa);
            this.gbGEquipasDados.Location = new System.Drawing.Point(6, 0);
            this.gbGEquipasDados.Name = "gbGEquipasDados";
            this.gbGEquipasDados.Size = new System.Drawing.Size(376, 381);
            this.gbGEquipasDados.TabIndex = 0;
            this.gbGEquipasDados.TabStop = false;
            this.gbGEquipasDados.Text = "Dados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pesquise:";
            // 
            // dgvGListaEquipas
            // 
            this.dgvGListaEquipas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGListaEquipas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGListaEquipas.Location = new System.Drawing.Point(25, 94);
            this.dgvGListaEquipas.Name = "dgvGListaEquipas";
            this.dgvGListaEquipas.RowTemplate.Height = 24;
            this.dgvGListaEquipas.Size = new System.Drawing.Size(315, 263);
            this.dgvGListaEquipas.TabIndex = 3;
            // 
            // txtGEquipasPesquisa
            // 
            this.txtGEquipasPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGEquipasPesquisa.Location = new System.Drawing.Point(98, 43);
            this.txtGEquipasPesquisa.Name = "txtGEquipasPesquisa";
            this.txtGEquipasPesquisa.Size = new System.Drawing.Size(155, 22);
            this.txtGEquipasPesquisa.TabIndex = 4;
            // 
            // tbGestaoTorneios
            // 
            this.tbGestaoTorneios.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoTorneios.Name = "tbGestaoTorneios";
            this.tbGestaoTorneios.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoTorneios.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoTorneios.TabIndex = 2;
            this.tbGestaoTorneios.Text = "Torneios";
            this.tbGestaoTorneios.UseVisualStyleBackColor = true;
            // 
            // tbGestaoCartas
            // 
            this.tbGestaoCartas.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoCartas.Name = "tbGestaoCartas";
            this.tbGestaoCartas.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoCartas.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoCartas.TabIndex = 3;
            this.tbGestaoCartas.Text = "Cartas";
            this.tbGestaoCartas.UseVisualStyleBackColor = true;
            // 
            // tbGestaoBaralhos
            // 
            this.tbGestaoBaralhos.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoBaralhos.Name = "tbGestaoBaralhos";
            this.tbGestaoBaralhos.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoBaralhos.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoBaralhos.TabIndex = 4;
            this.tbGestaoBaralhos.Text = "Baralhos";
            this.tbGestaoBaralhos.UseVisualStyleBackColor = true;
            // 
            // tbGestaoUtilizadores
            // 
            this.tbGestaoUtilizadores.Location = new System.Drawing.Point(4, 25);
            this.tbGestaoUtilizadores.Name = "tbGestaoUtilizadores";
            this.tbGestaoUtilizadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbGestaoUtilizadores.Size = new System.Drawing.Size(714, 387);
            this.tbGestaoUtilizadores.TabIndex = 5;
            this.tbGestaoUtilizadores.Text = "Utilizadores";
            this.tbGestaoUtilizadores.UseVisualStyleBackColor = true;
            // 
            // tbVer
            // 
            this.tbVer.Controls.Add(this.tcVer);
            this.tbVer.Location = new System.Drawing.Point(4, 25);
            this.tbVer.Name = "tbVer";
            this.tbVer.Padding = new System.Windows.Forms.Padding(3);
            this.tbVer.Size = new System.Drawing.Size(728, 422);
            this.tbVer.TabIndex = 1;
            this.tbVer.Text = "Ver";
            this.tbVer.UseVisualStyleBackColor = true;
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
            this.tcVer.Size = new System.Drawing.Size(722, 416);
            this.tcVer.TabIndex = 0;
            // 
            // tbVerJogadores
            // 
            this.tbVerJogadores.Location = new System.Drawing.Point(4, 25);
            this.tbVerJogadores.Name = "tbVerJogadores";
            this.tbVerJogadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerJogadores.Size = new System.Drawing.Size(714, 387);
            this.tbVerJogadores.TabIndex = 0;
            this.tbVerJogadores.Text = "Jogadores";
            this.tbVerJogadores.UseVisualStyleBackColor = true;
            // 
            // tbVerEquipas
            // 
            this.tbVerEquipas.Location = new System.Drawing.Point(4, 25);
            this.tbVerEquipas.Name = "tbVerEquipas";
            this.tbVerEquipas.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerEquipas.Size = new System.Drawing.Size(714, 387);
            this.tbVerEquipas.TabIndex = 1;
            this.tbVerEquipas.Text = "Equipas";
            this.tbVerEquipas.UseVisualStyleBackColor = true;
            // 
            // tbVerTorneios
            // 
            this.tbVerTorneios.Location = new System.Drawing.Point(4, 25);
            this.tbVerTorneios.Name = "tbVerTorneios";
            this.tbVerTorneios.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerTorneios.Size = new System.Drawing.Size(714, 387);
            this.tbVerTorneios.TabIndex = 2;
            this.tbVerTorneios.Text = "Torneios";
            this.tbVerTorneios.UseVisualStyleBackColor = true;
            // 
            // tbVerCartas
            // 
            this.tbVerCartas.Location = new System.Drawing.Point(4, 25);
            this.tbVerCartas.Name = "tbVerCartas";
            this.tbVerCartas.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerCartas.Size = new System.Drawing.Size(714, 387);
            this.tbVerCartas.TabIndex = 3;
            this.tbVerCartas.Text = "Cartas";
            this.tbVerCartas.UseVisualStyleBackColor = true;
            // 
            // tbVerBaralhos
            // 
            this.tbVerBaralhos.Location = new System.Drawing.Point(4, 25);
            this.tbVerBaralhos.Name = "tbVerBaralhos";
            this.tbVerBaralhos.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerBaralhos.Size = new System.Drawing.Size(714, 387);
            this.tbVerBaralhos.TabIndex = 4;
            this.tbVerBaralhos.Text = "Baralhos";
            this.tbVerBaralhos.UseVisualStyleBackColor = true;
            // 
            // tbVerUtilizadores
            // 
            this.tbVerUtilizadores.Location = new System.Drawing.Point(4, 25);
            this.tbVerUtilizadores.Name = "tbVerUtilizadores";
            this.tbVerUtilizadores.Padding = new System.Windows.Forms.Padding(3);
            this.tbVerUtilizadores.Size = new System.Drawing.Size(714, 387);
            this.tbVerUtilizadores.TabIndex = 5;
            this.tbVerUtilizadores.Text = "Utilizadores";
            this.tbVerUtilizadores.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(130, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 36);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // formMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 451);
            this.Controls.Add(this.tbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMenuAdmin";
            this.Text = "Arcmage - Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMenuAdmin_FormClosed);
            this.tbMenu.ResumeLayout(false);
            this.tpGestao.ResumeLayout(false);
            this.tcGestao.ResumeLayout(false);
            this.tbGestaoJogadores.ResumeLayout(false);
            this.gbGJogadoresForm.ResumeLayout(false);
            this.gbGJogadoresForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdadeJogador)).EndInit();
            this.gbGJogadoresAcoes.ResumeLayout(false);
            this.gbGJogadoresDados.ResumeLayout(false);
            this.gbGJogadoresDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaJogadores)).EndInit();
            this.tbGestaoEquipas.ResumeLayout(false);
            this.gbGEquipasForm.ResumeLayout(false);
            this.gbGEquipasForm.PerformLayout();
            this.gbGEquipasAcoes.ResumeLayout(false);
            this.gbGEquipasDados.ResumeLayout(false);
            this.gbGEquipasDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaEquipas)).EndInit();
            this.tbVer.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbGJogadoresAcoes;
        private System.Windows.Forms.Button btnRemoverJogador;
        private System.Windows.Forms.Button btnAlterarJogador;
        private System.Windows.Forms.Button btnInserirJogador;
        private System.Windows.Forms.GroupBox gbGJogadoresDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGListaJogadores;
        private System.Windows.Forms.TextBox txtGJogadoresPesquisa;
        private System.Windows.Forms.GroupBox gbGJogadoresForm;
        private System.Windows.Forms.Button btnJogadoresCancelar;
        private System.Windows.Forms.Button btnJogadoresAcao;
        private System.Windows.Forms.NumericUpDown nudIdadeJogador;
        private System.Windows.Forms.TextBox txtNickJogador;
        private System.Windows.Forms.TextBox txtEmailJogador;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbGEquipasDados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvGListaEquipas;
        private System.Windows.Forms.TextBox txtGEquipasPesquisa;
        private System.Windows.Forms.GroupBox gbGEquipasAcoes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox gbGEquipasForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
    }
}