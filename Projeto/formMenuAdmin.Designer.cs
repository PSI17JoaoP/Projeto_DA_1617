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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMenuAdmin));
            this.tbMenu = new System.Windows.Forms.TabControl();
            this.tpGestao = new System.Windows.Forms.TabPage();
            this.tcGestao = new System.Windows.Forms.TabControl();
            this.tbGestaoJogadores = new System.Windows.Forms.TabPage();
            this.gbGJogadoresForm = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btImagem = new System.Windows.Forms.Button();
            this.txtAvatar = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
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
            this.gbGJogadoresDados = new System.Windows.Forms.GroupBox();
            this.btnRemoverJogador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlterarJogador = new System.Windows.Forms.Button();
            this.dgvGListaJogadores = new System.Windows.Forms.DataGridView();
            this.playerSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bD_DA_ProjetoDataSet = new Projeto.BD_DA_ProjetoDataSet();
            this.btnInserirJogador = new System.Windows.Forms.Button();
            this.txtGJogadoresPesquisa = new System.Windows.Forms.TextBox();
            this.tbGestaoEquipas = new System.Windows.Forms.TabPage();
            this.gbGEquipasForm = new System.Windows.Forms.GroupBox();
            this.btnAvatarEquipa = new System.Windows.Forms.Button();
            this.txtEquipaCancelar = new System.Windows.Forms.Button();
            this.txtEquipaAcao = new System.Windows.Forms.Button();
            this.txtGAvatarEquipa = new System.Windows.Forms.TextBox();
            this.txtGNomeEquipa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbGEquipasDados = new System.Windows.Forms.GroupBox();
            this.btnRemoverEquipa = new System.Windows.Forms.Button();
            this.btnAlterarEquipa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInserirEquipa = new System.Windows.Forms.Button();
            this.dgvGListaEquipas = new System.Windows.Forms.DataGridView();
            this.txtGEquipasPesquisa = new System.Windows.Forms.TextBox();
            this.tbGestaoTorneios = new System.Windows.Forms.TabPage();
            this.gbGJogosDados = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGJogosPesquisa = new System.Windows.Forms.TextBox();
            this.dgvGJogosLista = new System.Windows.Forms.DataGridView();
            this.btnAlterarJogo = new System.Windows.Forms.Button();
            this.btnInserirJogo = new System.Windows.Forms.Button();
            this.btnRemoverJogo = new System.Windows.Forms.Button();
            this.gbGTorneiosDados = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtGTorneiosPesquisa = new System.Windows.Forms.TextBox();
            this.btnAlterarTorneio = new System.Windows.Forms.Button();
            this.btnInserirTorneio = new System.Windows.Forms.Button();
            this.dgvGTorneiosLista = new System.Windows.Forms.DataGridView();
            this.btnRemoverTorneio = new System.Windows.Forms.Button();
            this.gbGTorneiosInfo = new System.Windows.Forms.GroupBox();
            this.gbGJogosForm = new System.Windows.Forms.GroupBox();
            this.btnJogoCancelar = new System.Windows.Forms.Button();
            this.btnJogoAcao = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbJogador2Jogo = new System.Windows.Forms.ComboBox();
            this.cmbJogador1Jogo = new System.Windows.Forms.ComboBox();
            this.nudNJogo = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tpDataJogos = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescricaoJogo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbGTorneiosForm = new System.Windows.Forms.GroupBox();
            this.txtTorneioCancelar = new System.Windows.Forms.Button();
            this.txtTorneioAcao = new System.Windows.Forms.Button();
            this.txtDescricaoTorneio = new System.Windows.Forms.TextBox();
            this.tpDataTorneio = new System.Windows.Forms.DateTimePicker();
            this.txtNomeTorneio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGestaoCartas = new System.Windows.Forms.TabPage();
            this.gbGCartasForm = new System.Windows.Forms.GroupBox();
            this.btnCartaCancelar = new System.Windows.Forms.Button();
            this.btnAcaoCarta = new System.Windows.Forms.Button();
            this.nudGDefesaCarta = new System.Windows.Forms.NumericUpDown();
            this.nudGAtaqueCarta = new System.Windows.Forms.NumericUpDown();
            this.txtGRegrasCarta = new System.Windows.Forms.TextBox();
            this.nudGLealdadeCarta = new System.Windows.Forms.NumericUpDown();
            this.txtGCustoCarta = new System.Windows.Forms.TextBox();
            this.cmbGTipoCarta = new System.Windows.Forms.ComboBox();
            this.cmbFacaoCarta = new System.Windows.Forms.ComboBox();
            this.txtGNomeCarta = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.gbGCartasDados = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvGCartasLista = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGCartasPesquisa = new System.Windows.Forms.TextBox();
            this.tbGestaoBaralhos = new System.Windows.Forms.TabPage();
            this.btnGuardarAltBaralho = new System.Windows.Forms.Button();
            this.btnRemoverCartaBaralho = new System.Windows.Forms.Button();
            this.btnCancelarAltBaralho = new System.Windows.Forms.Button();
            this.gbGCartasnoBaralho = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnAdicionarCartaBaralho = new System.Windows.Forms.Button();
            this.gbGCartasparaBaralho = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.gbGBaralhosDados = new System.Windows.Forms.GroupBox();
            this.gbGBaralhosForm = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnGuardarBaralho = new System.Windows.Forms.Button();
            this.btnCancelarNovoBaralho = new System.Windows.Forms.Button();
            this.txtNomeBaralho = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dgvGBaralhosLista = new System.Windows.Forms.DataGridView();
            this.btnInserirBaralho = new System.Windows.Forms.Button();
            this.txtGBaralhosPesquisa = new System.Windows.Forms.TextBox();
            this.btnGerirBaralho = new System.Windows.Forms.Button();
            this.btnEliminarBaralho = new System.Windows.Forms.Button();
            this.tbGestaoUtilizadores = new System.Windows.Forms.TabPage();
            this.gbGUtilizadoresForm = new System.Windows.Forms.GroupBox();
            this.btnCancelarUtilizador = new System.Windows.Forms.Button();
            this.btnAcaoUtilizador = new System.Windows.Forms.Button();
            this.txtGEmailUtilizador = new System.Windows.Forms.TextBox();
            this.btnAvatarUtilizador = new System.Windows.Forms.Button();
            this.txtGAvatarUtilizador = new System.Windows.Forms.TextBox();
            this.txtGNomeUtilizador = new System.Windows.Forms.TextBox();
            this.cmbGTipoUser = new System.Windows.Forms.ComboBox();
            this.txtGPasswordUtilizador = new System.Windows.Forms.TextBox();
            this.txtGUsernameUtilizador = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.gbGUtilizadoresDados = new System.Windows.Forms.GroupBox();
            this.btnEliminarUtilizador = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.btnAlterarUtilizador = new System.Windows.Forms.Button();
            this.dgvGUtilizadoresLista = new System.Windows.Forms.DataGridView();
            this.btnInserirUtilizador = new System.Windows.Forms.Button();
            this.txtGUtilizadoresPesquisa = new System.Windows.Forms.TextBox();
            this.tbVer = new System.Windows.Forms.TabPage();
            this.tcVer = new System.Windows.Forms.TabControl();
            this.tbVerJogadores = new System.Windows.Forms.TabPage();
            this.tbVerEquipas = new System.Windows.Forms.TabPage();
            this.tbVerTorneios = new System.Windows.Forms.TabPage();
            this.tbVerCartas = new System.Windows.Forms.TabPage();
            this.tbVerBaralhos = new System.Windows.Forms.TabPage();
            this.tbVerUtilizadores = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.playerSetTableAdapter = new Projeto.BD_DA_ProjetoDataSetTableAdapters.PlayerSetTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nicknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avatarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbMenu.SuspendLayout();
            this.tpGestao.SuspendLayout();
            this.tcGestao.SuspendLayout();
            this.tbGestaoJogadores.SuspendLayout();
            this.gbGJogadoresForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdadeJogador)).BeginInit();
            this.gbGJogadoresDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaJogadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_DA_ProjetoDataSet)).BeginInit();
            this.tbGestaoEquipas.SuspendLayout();
            this.gbGEquipasForm.SuspendLayout();
            this.gbGEquipasDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaEquipas)).BeginInit();
            this.tbGestaoTorneios.SuspendLayout();
            this.gbGJogosDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGJogosLista)).BeginInit();
            this.gbGTorneiosDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGTorneiosLista)).BeginInit();
            this.gbGTorneiosInfo.SuspendLayout();
            this.gbGJogosForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNJogo)).BeginInit();
            this.gbGTorneiosForm.SuspendLayout();
            this.tbGestaoCartas.SuspendLayout();
            this.gbGCartasForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDefesaCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGAtaqueCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGLealdadeCarta)).BeginInit();
            this.gbGCartasDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGCartasLista)).BeginInit();
            this.tbGestaoBaralhos.SuspendLayout();
            this.gbGCartasnoBaralho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gbGCartasparaBaralho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.gbGBaralhosDados.SuspendLayout();
            this.gbGBaralhosForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGBaralhosLista)).BeginInit();
            this.tbGestaoUtilizadores.SuspendLayout();
            this.gbGUtilizadoresForm.SuspendLayout();
            this.gbGUtilizadoresDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGUtilizadoresLista)).BeginInit();
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
            this.tbMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tbMenu.Name = "tbMenu";
            this.tbMenu.SelectedIndex = 0;
            this.tbMenu.Size = new System.Drawing.Size(590, 377);
            this.tbMenu.TabIndex = 0;
            // 
            // tpGestao
            // 
            this.tpGestao.Controls.Add(this.tcGestao);
            this.tpGestao.Location = new System.Drawing.Point(4, 22);
            this.tpGestao.Margin = new System.Windows.Forms.Padding(2);
            this.tpGestao.Name = "tpGestao";
            this.tpGestao.Padding = new System.Windows.Forms.Padding(2);
            this.tpGestao.Size = new System.Drawing.Size(582, 351);
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
            this.tcGestao.Location = new System.Drawing.Point(2, 2);
            this.tcGestao.Margin = new System.Windows.Forms.Padding(2);
            this.tcGestao.Name = "tcGestao";
            this.tcGestao.SelectedIndex = 0;
            this.tcGestao.Size = new System.Drawing.Size(578, 347);
            this.tcGestao.TabIndex = 0;
            // 
            // tbGestaoJogadores
            // 
            this.tbGestaoJogadores.Controls.Add(this.gbGJogadoresForm);
            this.tbGestaoJogadores.Controls.Add(this.gbGJogadoresDados);
            this.tbGestaoJogadores.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoJogadores.Name = "tbGestaoJogadores";
            this.tbGestaoJogadores.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoJogadores.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoJogadores.TabIndex = 0;
            this.tbGestaoJogadores.Text = "Jogadores";
            this.tbGestaoJogadores.UseVisualStyleBackColor = true;
            // 
            // gbGJogadoresForm
            // 
            this.gbGJogadoresForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGJogadoresForm.Controls.Add(this.pictureBox1);
            this.gbGJogadoresForm.Controls.Add(this.btImagem);
            this.gbGJogadoresForm.Controls.Add(this.txtAvatar);
            this.gbGJogadoresForm.Controls.Add(this.label36);
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
            this.gbGJogadoresForm.Enabled = false;
            this.gbGJogadoresForm.Location = new System.Drawing.Point(323, 0);
            this.gbGJogadoresForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGJogadoresForm.Name = "gbGJogadoresForm";
            this.gbGJogadoresForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGJogadoresForm.Size = new System.Drawing.Size(244, 327);
            this.gbGJogadoresForm.TabIndex = 5;
            this.gbGJogadoresForm.TabStop = false;
            this.gbGJogadoresForm.Text = "Campos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(71, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btImagem
            // 
            this.btImagem.Location = new System.Drawing.Point(207, 160);
            this.btImagem.Name = "btImagem";
            this.btImagem.Size = new System.Drawing.Size(35, 23);
            this.btImagem.TabIndex = 12;
            this.btImagem.Text = "Q";
            this.btImagem.UseVisualStyleBackColor = true;
            this.btImagem.Click += new System.EventHandler(this.btImagem_Click);
            // 
            // txtAvatar
            // 
            this.txtAvatar.Location = new System.Drawing.Point(71, 162);
            this.txtAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.txtAvatar.Name = "txtAvatar";
            this.txtAvatar.ReadOnly = true;
            this.txtAvatar.Size = new System.Drawing.Size(127, 20);
            this.txtAvatar.TabIndex = 11;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(17, 165);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(38, 13);
            this.label36.TabIndex = 10;
            this.label36.Text = "Avatar";
            // 
            // btnJogadoresCancelar
            // 
            this.btnJogadoresCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJogadoresCancelar.Location = new System.Drawing.Point(164, 287);
            this.btnJogadoresCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogadoresCancelar.Name = "btnJogadoresCancelar";
            this.btnJogadoresCancelar.Size = new System.Drawing.Size(62, 21);
            this.btnJogadoresCancelar.TabIndex = 9;
            this.btnJogadoresCancelar.Text = "Cancelar";
            this.btnJogadoresCancelar.UseVisualStyleBackColor = true;
            this.btnJogadoresCancelar.Click += new System.EventHandler(this.btnJogadoresCancelar_Click);
            // 
            // btnJogadoresAcao
            // 
            this.btnJogadoresAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJogadoresAcao.Location = new System.Drawing.Point(104, 287);
            this.btnJogadoresAcao.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogadoresAcao.Name = "btnJogadoresAcao";
            this.btnJogadoresAcao.Size = new System.Drawing.Size(56, 21);
            this.btnJogadoresAcao.TabIndex = 8;
            this.btnJogadoresAcao.Text = "Ação";
            this.btnJogadoresAcao.UseVisualStyleBackColor = true;
            this.btnJogadoresAcao.Click += new System.EventHandler(this.btnJogadoresAcao_Click);
            // 
            // nudIdadeJogador
            // 
            this.nudIdadeJogador.Location = new System.Drawing.Point(73, 130);
            this.nudIdadeJogador.Margin = new System.Windows.Forms.Padding(2);
            this.nudIdadeJogador.Name = "nudIdadeJogador";
            this.nudIdadeJogador.Size = new System.Drawing.Size(40, 20);
            this.nudIdadeJogador.TabIndex = 7;
            // 
            // txtNickJogador
            // 
            this.txtNickJogador.Location = new System.Drawing.Point(73, 96);
            this.txtNickJogador.Margin = new System.Windows.Forms.Padding(2);
            this.txtNickJogador.Name = "txtNickJogador";
            this.txtNickJogador.Size = new System.Drawing.Size(155, 20);
            this.txtNickJogador.TabIndex = 6;
            // 
            // txtEmailJogador
            // 
            this.txtEmailJogador.Location = new System.Drawing.Point(73, 63);
            this.txtEmailJogador.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailJogador.Name = "txtEmailJogador";
            this.txtEmailJogador.Size = new System.Drawing.Size(155, 20);
            this.txtEmailJogador.TabIndex = 5;
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(73, 28);
            this.txtNomeJogador.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(155, 20);
            this.txtNomeJogador.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Idade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nickname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome";
            // 
            // gbGJogadoresDados
            // 
            this.gbGJogadoresDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGJogadoresDados.Controls.Add(this.btnRemoverJogador);
            this.gbGJogadoresDados.Controls.Add(this.label1);
            this.gbGJogadoresDados.Controls.Add(this.btnAlterarJogador);
            this.gbGJogadoresDados.Controls.Add(this.dgvGListaJogadores);
            this.gbGJogadoresDados.Controls.Add(this.btnInserirJogador);
            this.gbGJogadoresDados.Controls.Add(this.txtGJogadoresPesquisa);
            this.gbGJogadoresDados.Location = new System.Drawing.Point(4, 0);
            this.gbGJogadoresDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGJogadoresDados.MaximumSize = new System.Drawing.Size(525, 0);
            this.gbGJogadoresDados.MinimumSize = new System.Drawing.Size(292, 317);
            this.gbGJogadoresDados.Name = "gbGJogadoresDados";
            this.gbGJogadoresDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGJogadoresDados.Size = new System.Drawing.Size(317, 317);
            this.gbGJogadoresDados.TabIndex = 3;
            this.gbGJogadoresDados.TabStop = false;
            this.gbGJogadoresDados.Text = "Jogadores";
            // 
            // btnRemoverJogador
            // 
            this.btnRemoverJogador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverJogador.Enabled = false;
            this.btnRemoverJogador.Location = new System.Drawing.Point(232, 289);
            this.btnRemoverJogador.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverJogador.Name = "btnRemoverJogador";
            this.btnRemoverJogador.Size = new System.Drawing.Size(62, 24);
            this.btnRemoverJogador.TabIndex = 2;
            this.btnRemoverJogador.Text = "Eliminar";
            this.btnRemoverJogador.UseVisualStyleBackColor = true;
            this.btnRemoverJogador.Click += new System.EventHandler(this.btnRemoverJogador_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquise:";
            // 
            // btnAlterarJogador
            // 
            this.btnAlterarJogador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarJogador.Enabled = false;
            this.btnAlterarJogador.Location = new System.Drawing.Point(170, 289);
            this.btnAlterarJogador.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterarJogador.Name = "btnAlterarJogador";
            this.btnAlterarJogador.Size = new System.Drawing.Size(58, 24);
            this.btnAlterarJogador.TabIndex = 1;
            this.btnAlterarJogador.Text = "Alterar";
            this.btnAlterarJogador.UseVisualStyleBackColor = true;
            this.btnAlterarJogador.Click += new System.EventHandler(this.btnAlterarJogador_Click);
            // 
            // dgvGListaJogadores
            // 
            this.dgvGListaJogadores.AllowUserToAddRows = false;
            this.dgvGListaJogadores.AllowUserToDeleteRows = false;
            this.dgvGListaJogadores.AutoGenerateColumns = false;
            this.dgvGListaJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGListaJogadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.nicknameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.avatarDataGridViewTextBoxColumn});
            this.dgvGListaJogadores.DataSource = this.playerSetBindingSource;
            this.dgvGListaJogadores.Location = new System.Drawing.Point(19, 76);
            this.dgvGListaJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGListaJogadores.Name = "dgvGListaJogadores";
            this.dgvGListaJogadores.ReadOnly = true;
            this.dgvGListaJogadores.RowHeadersVisible = false;
            this.dgvGListaJogadores.RowTemplate.Height = 24;
            this.dgvGListaJogadores.Size = new System.Drawing.Size(275, 187);
            this.dgvGListaJogadores.TabIndex = 0;
            this.dgvGListaJogadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGListaJogadores_CellContentClick);
            this.dgvGListaJogadores.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGListaJogadores_CellMouseClick);
            this.dgvGListaJogadores.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGListaJogadores_CellMouseDoubleClick);
            this.dgvGListaJogadores.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGListaJogadores_CellMouseEnter);
            // 
            // playerSetBindingSource
            // 
            this.playerSetBindingSource.AllowNew = true;
            this.playerSetBindingSource.DataMember = "PlayerSet";
            this.playerSetBindingSource.DataSource = this.bD_DA_ProjetoDataSet;
            // 
            // bD_DA_ProjetoDataSet
            // 
            this.bD_DA_ProjetoDataSet.DataSetName = "BD_DA_ProjetoDataSet";
            this.bD_DA_ProjetoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnInserirJogador
            // 
            this.btnInserirJogador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirJogador.Location = new System.Drawing.Point(103, 289);
            this.btnInserirJogador.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirJogador.Name = "btnInserirJogador";
            this.btnInserirJogador.Size = new System.Drawing.Size(62, 24);
            this.btnInserirJogador.TabIndex = 0;
            this.btnInserirJogador.Text = "Inserir";
            this.btnInserirJogador.UseVisualStyleBackColor = true;
            this.btnInserirJogador.Click += new System.EventHandler(this.btnInserirJogador_Click);
            // 
            // txtGJogadoresPesquisa
            // 
            this.txtGJogadoresPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGJogadoresPesquisa.Location = new System.Drawing.Point(74, 35);
            this.txtGJogadoresPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGJogadoresPesquisa.Name = "txtGJogadoresPesquisa";
            this.txtGJogadoresPesquisa.Size = new System.Drawing.Size(152, 20);
            this.txtGJogadoresPesquisa.TabIndex = 1;
            this.txtGJogadoresPesquisa.TextChanged += new System.EventHandler(this.txtGJogadoresPesquisa_TextChanged);
            // 
            // tbGestaoEquipas
            // 
            this.tbGestaoEquipas.Controls.Add(this.gbGEquipasForm);
            this.tbGestaoEquipas.Controls.Add(this.gbGEquipasDados);
            this.tbGestaoEquipas.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoEquipas.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoEquipas.Name = "tbGestaoEquipas";
            this.tbGestaoEquipas.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoEquipas.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoEquipas.TabIndex = 1;
            this.tbGestaoEquipas.Text = "Equipas";
            this.tbGestaoEquipas.UseVisualStyleBackColor = true;
            // 
            // gbGEquipasForm
            // 
            this.gbGEquipasForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGEquipasForm.Controls.Add(this.btnAvatarEquipa);
            this.gbGEquipasForm.Controls.Add(this.txtEquipaCancelar);
            this.gbGEquipasForm.Controls.Add(this.txtEquipaAcao);
            this.gbGEquipasForm.Controls.Add(this.txtGAvatarEquipa);
            this.gbGEquipasForm.Controls.Add(this.txtGNomeEquipa);
            this.gbGEquipasForm.Controls.Add(this.label8);
            this.gbGEquipasForm.Controls.Add(this.label7);
            this.gbGEquipasForm.Location = new System.Drawing.Point(323, 0);
            this.gbGEquipasForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGEquipasForm.Name = "gbGEquipasForm";
            this.gbGEquipasForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGEquipasForm.Size = new System.Drawing.Size(244, 325);
            this.gbGEquipasForm.TabIndex = 6;
            this.gbGEquipasForm.TabStop = false;
            this.gbGEquipasForm.Text = "Campos";
            // 
            // btnAvatarEquipa
            // 
            this.btnAvatarEquipa.Location = new System.Drawing.Point(207, 84);
            this.btnAvatarEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.btnAvatarEquipa.Name = "btnAvatarEquipa";
            this.btnAvatarEquipa.Size = new System.Drawing.Size(20, 19);
            this.btnAvatarEquipa.TabIndex = 12;
            this.btnAvatarEquipa.Text = "Q";
            this.btnAvatarEquipa.UseVisualStyleBackColor = true;
            // 
            // txtEquipaCancelar
            // 
            this.txtEquipaCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipaCancelar.Location = new System.Drawing.Point(164, 285);
            this.txtEquipaCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.txtEquipaCancelar.Name = "txtEquipaCancelar";
            this.txtEquipaCancelar.Size = new System.Drawing.Size(62, 21);
            this.txtEquipaCancelar.TabIndex = 11;
            this.txtEquipaCancelar.Text = "Cancelar";
            this.txtEquipaCancelar.UseVisualStyleBackColor = true;
            // 
            // txtEquipaAcao
            // 
            this.txtEquipaAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipaAcao.Location = new System.Drawing.Point(104, 285);
            this.txtEquipaAcao.Margin = new System.Windows.Forms.Padding(2);
            this.txtEquipaAcao.Name = "txtEquipaAcao";
            this.txtEquipaAcao.Size = new System.Drawing.Size(56, 21);
            this.txtEquipaAcao.TabIndex = 10;
            this.txtEquipaAcao.Text = "Ação";
            this.txtEquipaAcao.UseVisualStyleBackColor = true;
            // 
            // txtGAvatarEquipa
            // 
            this.txtGAvatarEquipa.Location = new System.Drawing.Point(80, 84);
            this.txtGAvatarEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGAvatarEquipa.Name = "txtGAvatarEquipa";
            this.txtGAvatarEquipa.Size = new System.Drawing.Size(124, 20);
            this.txtGAvatarEquipa.TabIndex = 4;
            // 
            // txtGNomeEquipa
            // 
            this.txtGNomeEquipa.Location = new System.Drawing.Point(80, 47);
            this.txtGNomeEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGNomeEquipa.Name = "txtGNomeEquipa";
            this.txtGNomeEquipa.Size = new System.Drawing.Size(148, 20);
            this.txtGNomeEquipa.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Avatar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nome";
            // 
            // gbGEquipasDados
            // 
            this.gbGEquipasDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGEquipasDados.Controls.Add(this.btnRemoverEquipa);
            this.gbGEquipasDados.Controls.Add(this.btnAlterarEquipa);
            this.gbGEquipasDados.Controls.Add(this.label6);
            this.gbGEquipasDados.Controls.Add(this.btnInserirEquipa);
            this.gbGEquipasDados.Controls.Add(this.dgvGListaEquipas);
            this.gbGEquipasDados.Controls.Add(this.txtGEquipasPesquisa);
            this.gbGEquipasDados.Location = new System.Drawing.Point(4, 0);
            this.gbGEquipasDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGEquipasDados.MaximumSize = new System.Drawing.Size(525, 0);
            this.gbGEquipasDados.MinimumSize = new System.Drawing.Size(292, 317);
            this.gbGEquipasDados.Name = "gbGEquipasDados";
            this.gbGEquipasDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGEquipasDados.Size = new System.Drawing.Size(317, 317);
            this.gbGEquipasDados.TabIndex = 0;
            this.gbGEquipasDados.TabStop = false;
            this.gbGEquipasDados.Text = "Equipas";
            // 
            // btnRemoverEquipa
            // 
            this.btnRemoverEquipa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverEquipa.Location = new System.Drawing.Point(232, 285);
            this.btnRemoverEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverEquipa.Name = "btnRemoverEquipa";
            this.btnRemoverEquipa.Size = new System.Drawing.Size(62, 24);
            this.btnRemoverEquipa.TabIndex = 2;
            this.btnRemoverEquipa.Text = "Eliminar";
            this.btnRemoverEquipa.UseVisualStyleBackColor = true;
            // 
            // btnAlterarEquipa
            // 
            this.btnAlterarEquipa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarEquipa.Location = new System.Drawing.Point(170, 285);
            this.btnAlterarEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterarEquipa.Name = "btnAlterarEquipa";
            this.btnAlterarEquipa.Size = new System.Drawing.Size(58, 24);
            this.btnAlterarEquipa.TabIndex = 1;
            this.btnAlterarEquipa.Text = "Alterar";
            this.btnAlterarEquipa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pesquise:";
            // 
            // btnInserirEquipa
            // 
            this.btnInserirEquipa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirEquipa.Location = new System.Drawing.Point(103, 285);
            this.btnInserirEquipa.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirEquipa.Name = "btnInserirEquipa";
            this.btnInserirEquipa.Size = new System.Drawing.Size(62, 24);
            this.btnInserirEquipa.TabIndex = 0;
            this.btnInserirEquipa.Text = "Inserir";
            this.btnInserirEquipa.UseVisualStyleBackColor = true;
            // 
            // dgvGListaEquipas
            // 
            this.dgvGListaEquipas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGListaEquipas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGListaEquipas.Location = new System.Drawing.Point(19, 76);
            this.dgvGListaEquipas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGListaEquipas.Name = "dgvGListaEquipas";
            this.dgvGListaEquipas.RowTemplate.Height = 24;
            this.dgvGListaEquipas.Size = new System.Drawing.Size(275, 183);
            this.dgvGListaEquipas.TabIndex = 3;
            // 
            // txtGEquipasPesquisa
            // 
            this.txtGEquipasPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGEquipasPesquisa.Location = new System.Drawing.Point(74, 35);
            this.txtGEquipasPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGEquipasPesquisa.Name = "txtGEquipasPesquisa";
            this.txtGEquipasPesquisa.Size = new System.Drawing.Size(152, 20);
            this.txtGEquipasPesquisa.TabIndex = 4;
            // 
            // tbGestaoTorneios
            // 
            this.tbGestaoTorneios.Controls.Add(this.gbGJogosDados);
            this.tbGestaoTorneios.Controls.Add(this.gbGTorneiosDados);
            this.tbGestaoTorneios.Controls.Add(this.gbGTorneiosInfo);
            this.tbGestaoTorneios.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoTorneios.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoTorneios.Name = "tbGestaoTorneios";
            this.tbGestaoTorneios.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoTorneios.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoTorneios.TabIndex = 2;
            this.tbGestaoTorneios.Text = "Torneios";
            this.tbGestaoTorneios.UseVisualStyleBackColor = true;
            // 
            // gbGJogosDados
            // 
            this.gbGJogosDados.Controls.Add(this.label17);
            this.gbGJogosDados.Controls.Add(this.txtGJogosPesquisa);
            this.gbGJogosDados.Controls.Add(this.dgvGJogosLista);
            this.gbGJogosDados.Controls.Add(this.btnAlterarJogo);
            this.gbGJogosDados.Controls.Add(this.btnInserirJogo);
            this.gbGJogosDados.Controls.Add(this.btnRemoverJogo);
            this.gbGJogosDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGJogosDados.Location = new System.Drawing.Point(2, 163);
            this.gbGJogosDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGJogosDados.Name = "gbGJogosDados";
            this.gbGJogosDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGJogosDados.Size = new System.Drawing.Size(229, 156);
            this.gbGJogosDados.TabIndex = 1;
            this.gbGJogosDados.TabStop = false;
            this.gbGJogosDados.Text = "Jogos";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 26);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Pesquise:";
            // 
            // txtGJogosPesquisa
            // 
            this.txtGJogosPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGJogosPesquisa.Location = new System.Drawing.Point(74, 24);
            this.txtGJogosPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGJogosPesquisa.Name = "txtGJogosPesquisa";
            this.txtGJogosPesquisa.Size = new System.Drawing.Size(112, 20);
            this.txtGJogosPesquisa.TabIndex = 8;
            // 
            // dgvGJogosLista
            // 
            this.dgvGJogosLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGJogosLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGJogosLista.Location = new System.Drawing.Point(19, 55);
            this.dgvGJogosLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGJogosLista.Name = "dgvGJogosLista";
            this.dgvGJogosLista.RowTemplate.Height = 24;
            this.dgvGJogosLista.Size = new System.Drawing.Size(197, 60);
            this.dgvGJogosLista.TabIndex = 4;
            // 
            // btnAlterarJogo
            // 
            this.btnAlterarJogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarJogo.Location = new System.Drawing.Point(96, 133);
            this.btnAlterarJogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterarJogo.Name = "btnAlterarJogo";
            this.btnAlterarJogo.Size = new System.Drawing.Size(58, 19);
            this.btnAlterarJogo.TabIndex = 3;
            this.btnAlterarJogo.Text = "Alterar";
            this.btnAlterarJogo.UseVisualStyleBackColor = true;
            // 
            // btnInserirJogo
            // 
            this.btnInserirJogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirJogo.Location = new System.Drawing.Point(33, 133);
            this.btnInserirJogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirJogo.Name = "btnInserirJogo";
            this.btnInserirJogo.Size = new System.Drawing.Size(58, 19);
            this.btnInserirJogo.TabIndex = 2;
            this.btnInserirJogo.Text = "Inserir";
            this.btnInserirJogo.UseVisualStyleBackColor = true;
            // 
            // btnRemoverJogo
            // 
            this.btnRemoverJogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverJogo.Location = new System.Drawing.Point(158, 133);
            this.btnRemoverJogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverJogo.Name = "btnRemoverJogo";
            this.btnRemoverJogo.Size = new System.Drawing.Size(58, 19);
            this.btnRemoverJogo.TabIndex = 1;
            this.btnRemoverJogo.Text = "Eliminar";
            this.btnRemoverJogo.UseVisualStyleBackColor = true;
            this.btnRemoverJogo.Click += new System.EventHandler(this.button5_Click);
            // 
            // gbGTorneiosDados
            // 
            this.gbGTorneiosDados.Controls.Add(this.label16);
            this.gbGTorneiosDados.Controls.Add(this.txtGTorneiosPesquisa);
            this.gbGTorneiosDados.Controls.Add(this.btnAlterarTorneio);
            this.gbGTorneiosDados.Controls.Add(this.btnInserirTorneio);
            this.gbGTorneiosDados.Controls.Add(this.dgvGTorneiosLista);
            this.gbGTorneiosDados.Controls.Add(this.btnRemoverTorneio);
            this.gbGTorneiosDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGTorneiosDados.Location = new System.Drawing.Point(2, 2);
            this.gbGTorneiosDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosDados.Name = "gbGTorneiosDados";
            this.gbGTorneiosDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosDados.Size = new System.Drawing.Size(229, 161);
            this.gbGTorneiosDados.TabIndex = 0;
            this.gbGTorneiosDados.TabStop = false;
            this.gbGTorneiosDados.Text = "Torneios";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Pesquise:";
            // 
            // txtGTorneiosPesquisa
            // 
            this.txtGTorneiosPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGTorneiosPesquisa.Location = new System.Drawing.Point(74, 20);
            this.txtGTorneiosPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGTorneiosPesquisa.Name = "txtGTorneiosPesquisa";
            this.txtGTorneiosPesquisa.Size = new System.Drawing.Size(112, 20);
            this.txtGTorneiosPesquisa.TabIndex = 6;
            // 
            // btnAlterarTorneio
            // 
            this.btnAlterarTorneio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarTorneio.Location = new System.Drawing.Point(96, 124);
            this.btnAlterarTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterarTorneio.Name = "btnAlterarTorneio";
            this.btnAlterarTorneio.Size = new System.Drawing.Size(58, 19);
            this.btnAlterarTorneio.TabIndex = 3;
            this.btnAlterarTorneio.Text = "Alterar";
            this.btnAlterarTorneio.UseVisualStyleBackColor = true;
            // 
            // btnInserirTorneio
            // 
            this.btnInserirTorneio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirTorneio.Location = new System.Drawing.Point(33, 124);
            this.btnInserirTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirTorneio.Name = "btnInserirTorneio";
            this.btnInserirTorneio.Size = new System.Drawing.Size(58, 19);
            this.btnInserirTorneio.TabIndex = 2;
            this.btnInserirTorneio.Text = "Inserir";
            this.btnInserirTorneio.UseVisualStyleBackColor = true;
            // 
            // dgvGTorneiosLista
            // 
            this.dgvGTorneiosLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGTorneiosLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGTorneiosLista.Location = new System.Drawing.Point(19, 51);
            this.dgvGTorneiosLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGTorneiosLista.Name = "dgvGTorneiosLista";
            this.dgvGTorneiosLista.RowTemplate.Height = 24;
            this.dgvGTorneiosLista.Size = new System.Drawing.Size(197, 60);
            this.dgvGTorneiosLista.TabIndex = 1;
            // 
            // btnRemoverTorneio
            // 
            this.btnRemoverTorneio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverTorneio.Location = new System.Drawing.Point(158, 124);
            this.btnRemoverTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverTorneio.Name = "btnRemoverTorneio";
            this.btnRemoverTorneio.Size = new System.Drawing.Size(58, 19);
            this.btnRemoverTorneio.TabIndex = 0;
            this.btnRemoverTorneio.Text = "Eliminar";
            this.btnRemoverTorneio.UseVisualStyleBackColor = true;
            this.btnRemoverTorneio.Click += new System.EventHandler(this.button4_Click);
            // 
            // gbGTorneiosInfo
            // 
            this.gbGTorneiosInfo.Controls.Add(this.gbGJogosForm);
            this.gbGTorneiosInfo.Controls.Add(this.gbGTorneiosForm);
            this.gbGTorneiosInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbGTorneiosInfo.Location = new System.Drawing.Point(231, 2);
            this.gbGTorneiosInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosInfo.Name = "gbGTorneiosInfo";
            this.gbGTorneiosInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosInfo.Size = new System.Drawing.Size(337, 317);
            this.gbGTorneiosInfo.TabIndex = 2;
            this.gbGTorneiosInfo.TabStop = false;
            // 
            // gbGJogosForm
            // 
            this.gbGJogosForm.Controls.Add(this.btnJogoCancelar);
            this.gbGJogosForm.Controls.Add(this.btnJogoAcao);
            this.gbGJogosForm.Controls.Add(this.label15);
            this.gbGJogosForm.Controls.Add(this.cmbJogador2Jogo);
            this.gbGJogosForm.Controls.Add(this.cmbJogador1Jogo);
            this.gbGJogosForm.Controls.Add(this.nudNJogo);
            this.gbGJogosForm.Controls.Add(this.label14);
            this.gbGJogosForm.Controls.Add(this.tpDataJogos);
            this.gbGJogosForm.Controls.Add(this.label13);
            this.gbGJogosForm.Controls.Add(this.txtDescricaoJogo);
            this.gbGJogosForm.Controls.Add(this.label12);
            this.gbGJogosForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGJogosForm.Location = new System.Drawing.Point(2, 15);
            this.gbGJogosForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGJogosForm.Name = "gbGJogosForm";
            this.gbGJogosForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGJogosForm.Size = new System.Drawing.Size(333, 300);
            this.gbGJogosForm.TabIndex = 2;
            this.gbGJogosForm.TabStop = false;
            this.gbGJogosForm.Text = "Campos";
            this.gbGJogosForm.Visible = false;
            // 
            // btnJogoCancelar
            // 
            this.btnJogoCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJogoCancelar.Location = new System.Drawing.Point(261, 276);
            this.btnJogoCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogoCancelar.Name = "btnJogoCancelar";
            this.btnJogoCancelar.Size = new System.Drawing.Size(62, 21);
            this.btnJogoCancelar.TabIndex = 19;
            this.btnJogoCancelar.Text = "Cancelar";
            this.btnJogoCancelar.UseVisualStyleBackColor = true;
            // 
            // btnJogoAcao
            // 
            this.btnJogoAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJogoAcao.Location = new System.Drawing.Point(200, 276);
            this.btnJogoAcao.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogoAcao.Name = "btnJogoAcao";
            this.btnJogoAcao.Size = new System.Drawing.Size(56, 21);
            this.btnJogoAcao.TabIndex = 18;
            this.btnJogoAcao.Text = "Ação";
            this.btnJogoAcao.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(128, 109);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "vs";
            // 
            // cmbJogador2Jogo
            // 
            this.cmbJogador2Jogo.FormattingEnabled = true;
            this.cmbJogador2Jogo.Location = new System.Drawing.Point(166, 106);
            this.cmbJogador2Jogo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbJogador2Jogo.Name = "cmbJogador2Jogo";
            this.cmbJogador2Jogo.Size = new System.Drawing.Size(79, 21);
            this.cmbJogador2Jogo.TabIndex = 16;
            // 
            // cmbJogador1Jogo
            // 
            this.cmbJogador1Jogo.FormattingEnabled = true;
            this.cmbJogador1Jogo.Location = new System.Drawing.Point(31, 106);
            this.cmbJogador1Jogo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbJogador1Jogo.Name = "cmbJogador1Jogo";
            this.cmbJogador1Jogo.Size = new System.Drawing.Size(79, 21);
            this.cmbJogador1Jogo.TabIndex = 15;
            // 
            // nudNJogo
            // 
            this.nudNJogo.Location = new System.Drawing.Point(92, 66);
            this.nudNJogo.Margin = new System.Windows.Forms.Padding(2);
            this.nudNJogo.Name = "nudNJogo";
            this.nudNJogo.Size = new System.Drawing.Size(38, 20);
            this.nudNJogo.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 70);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Nº Jogo";
            // 
            // tpDataJogos
            // 
            this.tpDataJogos.Location = new System.Drawing.Point(92, 28);
            this.tpDataJogos.Margin = new System.Windows.Forms.Padding(2);
            this.tpDataJogos.Name = "tpDataJogos";
            this.tpDataJogos.Size = new System.Drawing.Size(135, 20);
            this.tpDataJogos.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 32);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Data";
            // 
            // txtDescricaoJogo
            // 
            this.txtDescricaoJogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricaoJogo.Location = new System.Drawing.Point(22, 162);
            this.txtDescricaoJogo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescricaoJogo.MaximumSize = new System.Drawing.Size(301, 155);
            this.txtDescricaoJogo.MinimumSize = new System.Drawing.Size(271, 42);
            this.txtDescricaoJogo.Multiline = true;
            this.txtDescricaoJogo.Name = "txtDescricaoJogo";
            this.txtDescricaoJogo.Size = new System.Drawing.Size(301, 47);
            this.txtDescricaoJogo.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 144);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Descrição";
            // 
            // gbGTorneiosForm
            // 
            this.gbGTorneiosForm.Controls.Add(this.txtTorneioCancelar);
            this.gbGTorneiosForm.Controls.Add(this.txtTorneioAcao);
            this.gbGTorneiosForm.Controls.Add(this.txtDescricaoTorneio);
            this.gbGTorneiosForm.Controls.Add(this.tpDataTorneio);
            this.gbGTorneiosForm.Controls.Add(this.txtNomeTorneio);
            this.gbGTorneiosForm.Controls.Add(this.label11);
            this.gbGTorneiosForm.Controls.Add(this.label10);
            this.gbGTorneiosForm.Controls.Add(this.label9);
            this.gbGTorneiosForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGTorneiosForm.Location = new System.Drawing.Point(2, 15);
            this.gbGTorneiosForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosForm.Name = "gbGTorneiosForm";
            this.gbGTorneiosForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGTorneiosForm.Size = new System.Drawing.Size(333, 300);
            this.gbGTorneiosForm.TabIndex = 1;
            this.gbGTorneiosForm.TabStop = false;
            this.gbGTorneiosForm.Text = "Campos";
            this.gbGTorneiosForm.Visible = false;
            // 
            // txtTorneioCancelar
            // 
            this.txtTorneioCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTorneioCancelar.Location = new System.Drawing.Point(261, 191);
            this.txtTorneioCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.txtTorneioCancelar.Name = "txtTorneioCancelar";
            this.txtTorneioCancelar.Size = new System.Drawing.Size(62, 21);
            this.txtTorneioCancelar.TabIndex = 13;
            this.txtTorneioCancelar.Text = "Cancelar";
            this.txtTorneioCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTorneioAcao
            // 
            this.txtTorneioAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTorneioAcao.Location = new System.Drawing.Point(200, 191);
            this.txtTorneioAcao.Margin = new System.Windows.Forms.Padding(2);
            this.txtTorneioAcao.Name = "txtTorneioAcao";
            this.txtTorneioAcao.Size = new System.Drawing.Size(56, 21);
            this.txtTorneioAcao.TabIndex = 12;
            this.txtTorneioAcao.Text = "Ação";
            this.txtTorneioAcao.UseVisualStyleBackColor = true;
            // 
            // txtDescricaoTorneio
            // 
            this.txtDescricaoTorneio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricaoTorneio.Location = new System.Drawing.Point(22, 132);
            this.txtDescricaoTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescricaoTorneio.MaximumSize = new System.Drawing.Size(301, 123);
            this.txtDescricaoTorneio.MinimumSize = new System.Drawing.Size(289, 50);
            this.txtDescricaoTorneio.Multiline = true;
            this.txtDescricaoTorneio.Name = "txtDescricaoTorneio";
            this.txtDescricaoTorneio.Size = new System.Drawing.Size(301, 55);
            this.txtDescricaoTorneio.TabIndex = 8;
            // 
            // tpDataTorneio
            // 
            this.tpDataTorneio.Location = new System.Drawing.Point(92, 66);
            this.tpDataTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.tpDataTorneio.Name = "tpDataTorneio";
            this.tpDataTorneio.Size = new System.Drawing.Size(220, 20);
            this.tpDataTorneio.TabIndex = 7;
            // 
            // txtNomeTorneio
            // 
            this.txtNomeTorneio.Location = new System.Drawing.Point(92, 32);
            this.txtNomeTorneio.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeTorneio.Name = "txtNomeTorneio";
            this.txtNomeTorneio.Size = new System.Drawing.Size(220, 20);
            this.txtNomeTorneio.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 106);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Descrição";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 70);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Nome";
            // 
            // tbGestaoCartas
            // 
            this.tbGestaoCartas.Controls.Add(this.gbGCartasForm);
            this.tbGestaoCartas.Controls.Add(this.gbGCartasDados);
            this.tbGestaoCartas.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoCartas.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoCartas.Name = "tbGestaoCartas";
            this.tbGestaoCartas.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoCartas.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoCartas.TabIndex = 3;
            this.tbGestaoCartas.Text = "Cartas";
            this.tbGestaoCartas.UseVisualStyleBackColor = true;
            // 
            // gbGCartasForm
            // 
            this.gbGCartasForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGCartasForm.Controls.Add(this.btnCartaCancelar);
            this.gbGCartasForm.Controls.Add(this.btnAcaoCarta);
            this.gbGCartasForm.Controls.Add(this.nudGDefesaCarta);
            this.gbGCartasForm.Controls.Add(this.nudGAtaqueCarta);
            this.gbGCartasForm.Controls.Add(this.txtGRegrasCarta);
            this.gbGCartasForm.Controls.Add(this.nudGLealdadeCarta);
            this.gbGCartasForm.Controls.Add(this.txtGCustoCarta);
            this.gbGCartasForm.Controls.Add(this.cmbGTipoCarta);
            this.gbGCartasForm.Controls.Add(this.cmbFacaoCarta);
            this.gbGCartasForm.Controls.Add(this.txtGNomeCarta);
            this.gbGCartasForm.Controls.Add(this.label26);
            this.gbGCartasForm.Controls.Add(this.label25);
            this.gbGCartasForm.Controls.Add(this.label24);
            this.gbGCartasForm.Controls.Add(this.label23);
            this.gbGCartasForm.Controls.Add(this.label22);
            this.gbGCartasForm.Controls.Add(this.label21);
            this.gbGCartasForm.Controls.Add(this.label20);
            this.gbGCartasForm.Controls.Add(this.label19);
            this.gbGCartasForm.Location = new System.Drawing.Point(323, 0);
            this.gbGCartasForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGCartasForm.Name = "gbGCartasForm";
            this.gbGCartasForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGCartasForm.Size = new System.Drawing.Size(244, 323);
            this.gbGCartasForm.TabIndex = 1;
            this.gbGCartasForm.TabStop = false;
            this.gbGCartasForm.Text = "Campos";
            // 
            // btnCartaCancelar
            // 
            this.btnCartaCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCartaCancelar.Location = new System.Drawing.Point(166, 288);
            this.btnCartaCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCartaCancelar.Name = "btnCartaCancelar";
            this.btnCartaCancelar.Size = new System.Drawing.Size(62, 21);
            this.btnCartaCancelar.TabIndex = 17;
            this.btnCartaCancelar.Text = "Cancelar";
            this.btnCartaCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAcaoCarta
            // 
            this.btnAcaoCarta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcaoCarta.Location = new System.Drawing.Point(106, 288);
            this.btnAcaoCarta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAcaoCarta.Name = "btnAcaoCarta";
            this.btnAcaoCarta.Size = new System.Drawing.Size(56, 21);
            this.btnAcaoCarta.TabIndex = 16;
            this.btnAcaoCarta.Text = "Ação";
            this.btnAcaoCarta.UseVisualStyleBackColor = true;
            // 
            // nudGDefesaCarta
            // 
            this.nudGDefesaCarta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGDefesaCarta.Location = new System.Drawing.Point(188, 252);
            this.nudGDefesaCarta.Margin = new System.Windows.Forms.Padding(2);
            this.nudGDefesaCarta.Name = "nudGDefesaCarta";
            this.nudGDefesaCarta.Size = new System.Drawing.Size(41, 20);
            this.nudGDefesaCarta.TabIndex = 15;
            // 
            // nudGAtaqueCarta
            // 
            this.nudGAtaqueCarta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGAtaqueCarta.Location = new System.Drawing.Point(71, 252);
            this.nudGAtaqueCarta.Margin = new System.Windows.Forms.Padding(2);
            this.nudGAtaqueCarta.Name = "nudGAtaqueCarta";
            this.nudGAtaqueCarta.Size = new System.Drawing.Size(41, 20);
            this.nudGAtaqueCarta.TabIndex = 14;
            // 
            // txtGRegrasCarta
            // 
            this.txtGRegrasCarta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGRegrasCarta.Location = new System.Drawing.Point(20, 187);
            this.txtGRegrasCarta.Margin = new System.Windows.Forms.Padding(2);
            this.txtGRegrasCarta.Multiline = true;
            this.txtGRegrasCarta.Name = "txtGRegrasCarta";
            this.txtGRegrasCarta.Size = new System.Drawing.Size(210, 54);
            this.txtGRegrasCarta.TabIndex = 13;
            // 
            // nudGLealdadeCarta
            // 
            this.nudGLealdadeCarta.Location = new System.Drawing.Point(188, 127);
            this.nudGLealdadeCarta.Margin = new System.Windows.Forms.Padding(2);
            this.nudGLealdadeCarta.Name = "nudGLealdadeCarta";
            this.nudGLealdadeCarta.Size = new System.Drawing.Size(41, 20);
            this.nudGLealdadeCarta.TabIndex = 12;
            // 
            // txtGCustoCarta
            // 
            this.txtGCustoCarta.Location = new System.Drawing.Point(71, 127);
            this.txtGCustoCarta.Margin = new System.Windows.Forms.Padding(2);
            this.txtGCustoCarta.Name = "txtGCustoCarta";
            this.txtGCustoCarta.Size = new System.Drawing.Size(53, 20);
            this.txtGCustoCarta.TabIndex = 11;
            // 
            // cmbGTipoCarta
            // 
            this.cmbGTipoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGTipoCarta.FormattingEnabled = true;
            this.cmbGTipoCarta.Items.AddRange(new object[] {
            "Criatura",
            "Evento",
            "Equipamento",
            "Magia",
            "Encantamento",
            "Cidade"});
            this.cmbGTipoCarta.Location = new System.Drawing.Point(71, 93);
            this.cmbGTipoCarta.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGTipoCarta.Name = "cmbGTipoCarta";
            this.cmbGTipoCarta.Size = new System.Drawing.Size(158, 21);
            this.cmbGTipoCarta.TabIndex = 10;
            // 
            // cmbFacaoCarta
            // 
            this.cmbFacaoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacaoCarta.FormattingEnabled = true;
            this.cmbFacaoCarta.Items.AddRange(new object[] {
            "Gaian Love for Life",
            "Uneasy Alliance"});
            this.cmbFacaoCarta.Location = new System.Drawing.Point(71, 62);
            this.cmbFacaoCarta.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFacaoCarta.Name = "cmbFacaoCarta";
            this.cmbFacaoCarta.Size = new System.Drawing.Size(158, 21);
            this.cmbFacaoCarta.TabIndex = 9;
            // 
            // txtGNomeCarta
            // 
            this.txtGNomeCarta.Location = new System.Drawing.Point(71, 33);
            this.txtGNomeCarta.Margin = new System.Windows.Forms.Padding(2);
            this.txtGNomeCarta.Name = "txtGNomeCarta";
            this.txtGNomeCarta.Size = new System.Drawing.Size(158, 20);
            this.txtGNomeCarta.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(133, 256);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Defesa";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(17, 256);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Ataque";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(17, 160);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "Regras";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(133, 129);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "Lealdade";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 132);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "Custo";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 99);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Tipo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 69);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Fação";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 37);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Nome";
            // 
            // gbGCartasDados
            // 
            this.gbGCartasDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGCartasDados.Controls.Add(this.button1);
            this.gbGCartasDados.Controls.Add(this.button2);
            this.gbGCartasDados.Controls.Add(this.button3);
            this.gbGCartasDados.Controls.Add(this.dgvGCartasLista);
            this.gbGCartasDados.Controls.Add(this.label18);
            this.gbGCartasDados.Controls.Add(this.txtGCartasPesquisa);
            this.gbGCartasDados.Location = new System.Drawing.Point(4, 0);
            this.gbGCartasDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGCartasDados.MaximumSize = new System.Drawing.Size(525, 0);
            this.gbGCartasDados.MinimumSize = new System.Drawing.Size(292, 317);
            this.gbGCartasDados.Name = "gbGCartasDados";
            this.gbGCartasDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGCartasDados.Size = new System.Drawing.Size(317, 317);
            this.gbGCartasDados.TabIndex = 0;
            this.gbGCartasDados.TabStop = false;
            this.gbGCartasDados.Text = "Cartas";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(232, 289);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(170, 289);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "Alterar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(103, 289);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Inserir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dgvGCartasLista
            // 
            this.dgvGCartasLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGCartasLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGCartasLista.Location = new System.Drawing.Point(19, 76);
            this.dgvGCartasLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGCartasLista.Name = "dgvGCartasLista";
            this.dgvGCartasLista.RowTemplate.Height = 24;
            this.dgvGCartasLista.Size = new System.Drawing.Size(275, 184);
            this.dgvGCartasLista.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 37);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Pesquise:";
            // 
            // txtGCartasPesquisa
            // 
            this.txtGCartasPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGCartasPesquisa.Location = new System.Drawing.Point(74, 37);
            this.txtGCartasPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGCartasPesquisa.Name = "txtGCartasPesquisa";
            this.txtGCartasPesquisa.Size = new System.Drawing.Size(152, 20);
            this.txtGCartasPesquisa.TabIndex = 6;
            // 
            // tbGestaoBaralhos
            // 
            this.tbGestaoBaralhos.Controls.Add(this.btnGuardarAltBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.btnRemoverCartaBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.btnCancelarAltBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.gbGCartasnoBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.btnAdicionarCartaBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.gbGCartasparaBaralho);
            this.tbGestaoBaralhos.Controls.Add(this.gbGBaralhosDados);
            this.tbGestaoBaralhos.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoBaralhos.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoBaralhos.Name = "tbGestaoBaralhos";
            this.tbGestaoBaralhos.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoBaralhos.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoBaralhos.TabIndex = 4;
            this.tbGestaoBaralhos.Text = "Baralhos";
            this.tbGestaoBaralhos.UseVisualStyleBackColor = true;
            // 
            // btnGuardarAltBaralho
            // 
            this.btnGuardarAltBaralho.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarAltBaralho.Location = new System.Drawing.Point(254, 267);
            this.btnGuardarAltBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarAltBaralho.Name = "btnGuardarAltBaralho";
            this.btnGuardarAltBaralho.Size = new System.Drawing.Size(64, 19);
            this.btnGuardarAltBaralho.TabIndex = 12;
            this.btnGuardarAltBaralho.Text = "Guardar";
            this.btnGuardarAltBaralho.UseVisualStyleBackColor = true;
            // 
            // btnRemoverCartaBaralho
            // 
            this.btnRemoverCartaBaralho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoverCartaBaralho.Location = new System.Drawing.Point(266, 218);
            this.btnRemoverCartaBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverCartaBaralho.Name = "btnRemoverCartaBaralho";
            this.btnRemoverCartaBaralho.Size = new System.Drawing.Size(41, 24);
            this.btnRemoverCartaBaralho.TabIndex = 13;
            this.btnRemoverCartaBaralho.Text = ">>";
            this.btnRemoverCartaBaralho.UseVisualStyleBackColor = true;
            // 
            // btnCancelarAltBaralho
            // 
            this.btnCancelarAltBaralho.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelarAltBaralho.Location = new System.Drawing.Point(254, 291);
            this.btnCancelarAltBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarAltBaralho.Name = "btnCancelarAltBaralho";
            this.btnCancelarAltBaralho.Size = new System.Drawing.Size(64, 19);
            this.btnCancelarAltBaralho.TabIndex = 11;
            this.btnCancelarAltBaralho.Text = "Cancelar";
            this.btnCancelarAltBaralho.UseVisualStyleBackColor = true;
            // 
            // gbGCartasnoBaralho
            // 
            this.gbGCartasnoBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbGCartasnoBaralho.Controls.Add(this.dataGridView2);
            this.gbGCartasnoBaralho.Location = new System.Drawing.Point(2, 132);
            this.gbGCartasnoBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.gbGCartasnoBaralho.MaximumSize = new System.Drawing.Size(268, 0);
            this.gbGCartasnoBaralho.MinimumSize = new System.Drawing.Size(248, 183);
            this.gbGCartasnoBaralho.Name = "gbGCartasnoBaralho";
            this.gbGCartasnoBaralho.Padding = new System.Windows.Forms.Padding(2);
            this.gbGCartasnoBaralho.Size = new System.Drawing.Size(248, 183);
            this.gbGCartasnoBaralho.TabIndex = 2;
            this.gbGCartasnoBaralho.TabStop = false;
            this.gbGCartasnoBaralho.Text = "Cartas no baralho";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(4, 26);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(238, 150);
            this.dataGridView2.TabIndex = 10;
            // 
            // btnAdicionarCartaBaralho
            // 
            this.btnAdicionarCartaBaralho.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdicionarCartaBaralho.Location = new System.Drawing.Point(266, 158);
            this.btnAdicionarCartaBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCartaBaralho.Name = "btnAdicionarCartaBaralho";
            this.btnAdicionarCartaBaralho.Size = new System.Drawing.Size(41, 24);
            this.btnAdicionarCartaBaralho.TabIndex = 14;
            this.btnAdicionarCartaBaralho.Text = "<<";
            this.btnAdicionarCartaBaralho.UseVisualStyleBackColor = true;
            // 
            // gbGCartasparaBaralho
            // 
            this.gbGCartasparaBaralho.Controls.Add(this.dataGridView3);
            this.gbGCartasparaBaralho.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbGCartasparaBaralho.Location = new System.Drawing.Point(320, 131);
            this.gbGCartasparaBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.gbGCartasparaBaralho.Name = "gbGCartasparaBaralho";
            this.gbGCartasparaBaralho.Padding = new System.Windows.Forms.Padding(2);
            this.gbGCartasparaBaralho.Size = new System.Drawing.Size(248, 188);
            this.gbGCartasparaBaralho.TabIndex = 1;
            this.gbGCartasparaBaralho.TabStop = false;
            this.gbGCartasparaBaralho.Text = "Lista de cartas";
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(12, 26);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(231, 148);
            this.dataGridView3.TabIndex = 11;
            // 
            // gbGBaralhosDados
            // 
            this.gbGBaralhosDados.Controls.Add(this.gbGBaralhosForm);
            this.gbGBaralhosDados.Controls.Add(this.label27);
            this.gbGBaralhosDados.Controls.Add(this.dgvGBaralhosLista);
            this.gbGBaralhosDados.Controls.Add(this.btnInserirBaralho);
            this.gbGBaralhosDados.Controls.Add(this.txtGBaralhosPesquisa);
            this.gbGBaralhosDados.Controls.Add(this.btnGerirBaralho);
            this.gbGBaralhosDados.Controls.Add(this.btnEliminarBaralho);
            this.gbGBaralhosDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGBaralhosDados.Location = new System.Drawing.Point(2, 2);
            this.gbGBaralhosDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGBaralhosDados.Name = "gbGBaralhosDados";
            this.gbGBaralhosDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGBaralhosDados.Size = new System.Drawing.Size(566, 129);
            this.gbGBaralhosDados.TabIndex = 0;
            this.gbGBaralhosDados.TabStop = false;
            this.gbGBaralhosDados.Text = "Baralhos";
            // 
            // gbGBaralhosForm
            // 
            this.gbGBaralhosForm.Controls.Add(this.label28);
            this.gbGBaralhosForm.Controls.Add(this.btnGuardarBaralho);
            this.gbGBaralhosForm.Controls.Add(this.btnCancelarNovoBaralho);
            this.gbGBaralhosForm.Controls.Add(this.txtNomeBaralho);
            this.gbGBaralhosForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbGBaralhosForm.Location = new System.Drawing.Point(357, 15);
            this.gbGBaralhosForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGBaralhosForm.Name = "gbGBaralhosForm";
            this.gbGBaralhosForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGBaralhosForm.Size = new System.Drawing.Size(207, 112);
            this.gbGBaralhosForm.TabIndex = 18;
            this.gbGBaralhosForm.TabStop = false;
            this.gbGBaralhosForm.Text = "Campo";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 20);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 14;
            this.label28.Text = "Nome";
            // 
            // btnGuardarBaralho
            // 
            this.btnGuardarBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarBaralho.Location = new System.Drawing.Point(69, 82);
            this.btnGuardarBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarBaralho.Name = "btnGuardarBaralho";
            this.btnGuardarBaralho.Size = new System.Drawing.Size(64, 19);
            this.btnGuardarBaralho.TabIndex = 17;
            this.btnGuardarBaralho.Text = "Guardar";
            this.btnGuardarBaralho.UseVisualStyleBackColor = true;
            // 
            // btnCancelarNovoBaralho
            // 
            this.btnCancelarNovoBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarNovoBaralho.Location = new System.Drawing.Point(138, 82);
            this.btnCancelarNovoBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarNovoBaralho.Name = "btnCancelarNovoBaralho";
            this.btnCancelarNovoBaralho.Size = new System.Drawing.Size(64, 19);
            this.btnCancelarNovoBaralho.TabIndex = 16;
            this.btnCancelarNovoBaralho.Text = "Cancelar";
            this.btnCancelarNovoBaralho.UseVisualStyleBackColor = true;
            // 
            // txtNomeBaralho
            // 
            this.txtNomeBaralho.Location = new System.Drawing.Point(19, 37);
            this.txtNomeBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeBaralho.Name = "txtNomeBaralho";
            this.txtNomeBaralho.Size = new System.Drawing.Size(124, 20);
            this.txtNomeBaralho.TabIndex = 15;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(19, 20);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 13);
            this.label27.TabIndex = 13;
            this.label27.Text = "Pesquise:";
            // 
            // dgvGBaralhosLista
            // 
            this.dgvGBaralhosLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGBaralhosLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGBaralhosLista.Location = new System.Drawing.Point(22, 54);
            this.dgvGBaralhosLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGBaralhosLista.Name = "dgvGBaralhosLista";
            this.dgvGBaralhosLista.RowTemplate.Height = 24;
            this.dgvGBaralhosLista.Size = new System.Drawing.Size(250, 62);
            this.dgvGBaralhosLista.TabIndex = 9;
            // 
            // btnInserirBaralho
            // 
            this.btnInserirBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirBaralho.Location = new System.Drawing.Point(283, 17);
            this.btnInserirBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirBaralho.Name = "btnInserirBaralho";
            this.btnInserirBaralho.Size = new System.Drawing.Size(58, 19);
            this.btnInserirBaralho.TabIndex = 10;
            this.btnInserirBaralho.Text = "Inserir";
            this.btnInserirBaralho.UseVisualStyleBackColor = true;
            // 
            // txtGBaralhosPesquisa
            // 
            this.txtGBaralhosPesquisa.Location = new System.Drawing.Point(76, 18);
            this.txtGBaralhosPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGBaralhosPesquisa.Name = "txtGBaralhosPesquisa";
            this.txtGBaralhosPesquisa.Size = new System.Drawing.Size(98, 20);
            this.txtGBaralhosPesquisa.TabIndex = 12;
            // 
            // btnGerirBaralho
            // 
            this.btnGerirBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerirBaralho.Location = new System.Drawing.Point(283, 56);
            this.btnGerirBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnGerirBaralho.Name = "btnGerirBaralho";
            this.btnGerirBaralho.Size = new System.Drawing.Size(58, 19);
            this.btnGerirBaralho.TabIndex = 11;
            this.btnGerirBaralho.Text = "Gerir";
            this.btnGerirBaralho.UseVisualStyleBackColor = true;
            // 
            // btnEliminarBaralho
            // 
            this.btnEliminarBaralho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarBaralho.Location = new System.Drawing.Point(283, 97);
            this.btnEliminarBaralho.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarBaralho.Name = "btnEliminarBaralho";
            this.btnEliminarBaralho.Size = new System.Drawing.Size(58, 19);
            this.btnEliminarBaralho.TabIndex = 8;
            this.btnEliminarBaralho.Text = "Eliminar";
            this.btnEliminarBaralho.UseVisualStyleBackColor = true;
            // 
            // tbGestaoUtilizadores
            // 
            this.tbGestaoUtilizadores.Controls.Add(this.gbGUtilizadoresForm);
            this.tbGestaoUtilizadores.Controls.Add(this.gbGUtilizadoresDados);
            this.tbGestaoUtilizadores.Location = new System.Drawing.Point(4, 22);
            this.tbGestaoUtilizadores.Margin = new System.Windows.Forms.Padding(2);
            this.tbGestaoUtilizadores.Name = "tbGestaoUtilizadores";
            this.tbGestaoUtilizadores.Padding = new System.Windows.Forms.Padding(2);
            this.tbGestaoUtilizadores.Size = new System.Drawing.Size(570, 321);
            this.tbGestaoUtilizadores.TabIndex = 5;
            this.tbGestaoUtilizadores.Text = "Utilizadores";
            this.tbGestaoUtilizadores.UseVisualStyleBackColor = true;
            // 
            // gbGUtilizadoresForm
            // 
            this.gbGUtilizadoresForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGUtilizadoresForm.Controls.Add(this.btnCancelarUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.btnAcaoUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.txtGEmailUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.btnAvatarUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.txtGAvatarUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.txtGNomeUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.cmbGTipoUser);
            this.gbGUtilizadoresForm.Controls.Add(this.txtGPasswordUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.txtGUsernameUtilizador);
            this.gbGUtilizadoresForm.Controls.Add(this.label35);
            this.gbGUtilizadoresForm.Controls.Add(this.label34);
            this.gbGUtilizadoresForm.Controls.Add(this.label33);
            this.gbGUtilizadoresForm.Controls.Add(this.label32);
            this.gbGUtilizadoresForm.Controls.Add(this.label31);
            this.gbGUtilizadoresForm.Controls.Add(this.label30);
            this.gbGUtilizadoresForm.Location = new System.Drawing.Point(323, 0);
            this.gbGUtilizadoresForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbGUtilizadoresForm.Name = "gbGUtilizadoresForm";
            this.gbGUtilizadoresForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbGUtilizadoresForm.Size = new System.Drawing.Size(244, 326);
            this.gbGUtilizadoresForm.TabIndex = 1;
            this.gbGUtilizadoresForm.TabStop = false;
            this.gbGUtilizadoresForm.Text = "Campos";
            // 
            // btnCancelarUtilizador
            // 
            this.btnCancelarUtilizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarUtilizador.Location = new System.Drawing.Point(160, 294);
            this.btnCancelarUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarUtilizador.Name = "btnCancelarUtilizador";
            this.btnCancelarUtilizador.Size = new System.Drawing.Size(62, 21);
            this.btnCancelarUtilizador.TabIndex = 15;
            this.btnCancelarUtilizador.Text = "Cancelar";
            this.btnCancelarUtilizador.UseVisualStyleBackColor = true;
            // 
            // btnAcaoUtilizador
            // 
            this.btnAcaoUtilizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcaoUtilizador.Location = new System.Drawing.Point(100, 294);
            this.btnAcaoUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnAcaoUtilizador.Name = "btnAcaoUtilizador";
            this.btnAcaoUtilizador.Size = new System.Drawing.Size(56, 21);
            this.btnAcaoUtilizador.TabIndex = 14;
            this.btnAcaoUtilizador.Text = "Ação";
            this.btnAcaoUtilizador.UseVisualStyleBackColor = true;
            // 
            // txtGEmailUtilizador
            // 
            this.txtGEmailUtilizador.Location = new System.Drawing.Point(70, 195);
            this.txtGEmailUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.txtGEmailUtilizador.Name = "txtGEmailUtilizador";
            this.txtGEmailUtilizador.Size = new System.Drawing.Size(128, 20);
            this.txtGEmailUtilizador.TabIndex = 13;
            // 
            // btnAvatarUtilizador
            // 
            this.btnAvatarUtilizador.Location = new System.Drawing.Point(202, 160);
            this.btnAvatarUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnAvatarUtilizador.Name = "btnAvatarUtilizador";
            this.btnAvatarUtilizador.Size = new System.Drawing.Size(21, 19);
            this.btnAvatarUtilizador.TabIndex = 12;
            this.btnAvatarUtilizador.Text = "Q";
            this.btnAvatarUtilizador.UseVisualStyleBackColor = true;
            // 
            // txtGAvatarUtilizador
            // 
            this.txtGAvatarUtilizador.Location = new System.Drawing.Point(70, 161);
            this.txtGAvatarUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.txtGAvatarUtilizador.Name = "txtGAvatarUtilizador";
            this.txtGAvatarUtilizador.Size = new System.Drawing.Size(128, 20);
            this.txtGAvatarUtilizador.TabIndex = 11;
            // 
            // txtGNomeUtilizador
            // 
            this.txtGNomeUtilizador.Location = new System.Drawing.Point(70, 131);
            this.txtGNomeUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.txtGNomeUtilizador.Name = "txtGNomeUtilizador";
            this.txtGNomeUtilizador.Size = new System.Drawing.Size(128, 20);
            this.txtGNomeUtilizador.TabIndex = 10;
            // 
            // cmbGTipoUser
            // 
            this.cmbGTipoUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGTipoUser.FormattingEnabled = true;
            this.cmbGTipoUser.Items.AddRange(new object[] {
            "Administrador",
            "Árbitro"});
            this.cmbGTipoUser.Location = new System.Drawing.Point(106, 93);
            this.cmbGTipoUser.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGTipoUser.Name = "cmbGTipoUser";
            this.cmbGTipoUser.Size = new System.Drawing.Size(92, 21);
            this.cmbGTipoUser.TabIndex = 9;
            // 
            // txtGPasswordUtilizador
            // 
            this.txtGPasswordUtilizador.Location = new System.Drawing.Point(106, 64);
            this.txtGPasswordUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.txtGPasswordUtilizador.Name = "txtGPasswordUtilizador";
            this.txtGPasswordUtilizador.Size = new System.Drawing.Size(92, 20);
            this.txtGPasswordUtilizador.TabIndex = 8;
            this.txtGPasswordUtilizador.UseSystemPasswordChar = true;
            // 
            // txtGUsernameUtilizador
            // 
            this.txtGUsernameUtilizador.Location = new System.Drawing.Point(106, 37);
            this.txtGUsernameUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.txtGUsernameUtilizador.Name = "txtGUsernameUtilizador";
            this.txtGUsernameUtilizador.Size = new System.Drawing.Size(92, 20);
            this.txtGUsernameUtilizador.TabIndex = 7;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(13, 199);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 13);
            this.label35.TabIndex = 6;
            this.label35.Text = "Email";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(13, 165);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(38, 13);
            this.label34.TabIndex = 5;
            this.label34.Text = "Avatar";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 101);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(87, 13);
            this.label33.TabIndex = 4;
            this.label33.Text = "Tipo de utilizador";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 135);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 13);
            this.label32.TabIndex = 3;
            this.label32.Text = "Nome";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(13, 68);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Password";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 38);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 1;
            this.label30.Text = "Utilizador";
            // 
            // gbGUtilizadoresDados
            // 
            this.gbGUtilizadoresDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGUtilizadoresDados.Controls.Add(this.btnEliminarUtilizador);
            this.gbGUtilizadoresDados.Controls.Add(this.label29);
            this.gbGUtilizadoresDados.Controls.Add(this.btnAlterarUtilizador);
            this.gbGUtilizadoresDados.Controls.Add(this.dgvGUtilizadoresLista);
            this.gbGUtilizadoresDados.Controls.Add(this.btnInserirUtilizador);
            this.gbGUtilizadoresDados.Controls.Add(this.txtGUtilizadoresPesquisa);
            this.gbGUtilizadoresDados.Location = new System.Drawing.Point(4, 0);
            this.gbGUtilizadoresDados.Margin = new System.Windows.Forms.Padding(2);
            this.gbGUtilizadoresDados.MaximumSize = new System.Drawing.Size(525, 0);
            this.gbGUtilizadoresDados.MinimumSize = new System.Drawing.Size(292, 317);
            this.gbGUtilizadoresDados.Name = "gbGUtilizadoresDados";
            this.gbGUtilizadoresDados.Padding = new System.Windows.Forms.Padding(2);
            this.gbGUtilizadoresDados.Size = new System.Drawing.Size(317, 317);
            this.gbGUtilizadoresDados.TabIndex = 0;
            this.gbGUtilizadoresDados.TabStop = false;
            this.gbGUtilizadoresDados.Text = "Utilizadores";
            // 
            // btnEliminarUtilizador
            // 
            this.btnEliminarUtilizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarUtilizador.Location = new System.Drawing.Point(250, 293);
            this.btnEliminarUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarUtilizador.Name = "btnEliminarUtilizador";
            this.btnEliminarUtilizador.Size = new System.Drawing.Size(62, 24);
            this.btnEliminarUtilizador.TabIndex = 7;
            this.btnEliminarUtilizador.Text = "Eliminar";
            this.btnEliminarUtilizador.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 41);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 13);
            this.label29.TabIndex = 8;
            this.label29.Text = "Pesquise:";
            // 
            // btnAlterarUtilizador
            // 
            this.btnAlterarUtilizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarUtilizador.Location = new System.Drawing.Point(188, 293);
            this.btnAlterarUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterarUtilizador.Name = "btnAlterarUtilizador";
            this.btnAlterarUtilizador.Size = new System.Drawing.Size(58, 24);
            this.btnAlterarUtilizador.TabIndex = 5;
            this.btnAlterarUtilizador.Text = "Alterar";
            this.btnAlterarUtilizador.UseVisualStyleBackColor = true;
            // 
            // dgvGUtilizadoresLista
            // 
            this.dgvGUtilizadoresLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGUtilizadoresLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGUtilizadoresLista.Location = new System.Drawing.Point(11, 80);
            this.dgvGUtilizadoresLista.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGUtilizadoresLista.Name = "dgvGUtilizadoresLista";
            this.dgvGUtilizadoresLista.RowTemplate.Height = 24;
            this.dgvGUtilizadoresLista.Size = new System.Drawing.Size(302, 187);
            this.dgvGUtilizadoresLista.TabIndex = 3;
            // 
            // btnInserirUtilizador
            // 
            this.btnInserirUtilizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirUtilizador.Location = new System.Drawing.Point(122, 293);
            this.btnInserirUtilizador.Margin = new System.Windows.Forms.Padding(2);
            this.btnInserirUtilizador.Name = "btnInserirUtilizador";
            this.btnInserirUtilizador.Size = new System.Drawing.Size(62, 24);
            this.btnInserirUtilizador.TabIndex = 4;
            this.btnInserirUtilizador.Text = "Inserir";
            this.btnInserirUtilizador.UseVisualStyleBackColor = true;
            // 
            // txtGUtilizadoresPesquisa
            // 
            this.txtGUtilizadoresPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGUtilizadoresPesquisa.Location = new System.Drawing.Point(66, 38);
            this.txtGUtilizadoresPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGUtilizadoresPesquisa.Name = "txtGUtilizadoresPesquisa";
            this.txtGUtilizadoresPesquisa.Size = new System.Drawing.Size(179, 20);
            this.txtGUtilizadoresPesquisa.TabIndex = 6;
            // 
            // tbVer
            // 
            this.tbVer.Controls.Add(this.tcVer);
            this.tbVer.Location = new System.Drawing.Point(4, 22);
            this.tbVer.Margin = new System.Windows.Forms.Padding(2);
            this.tbVer.Name = "tbVer";
            this.tbVer.Padding = new System.Windows.Forms.Padding(2);
            this.tbVer.Size = new System.Drawing.Size(582, 351);
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
            this.tcVer.Location = new System.Drawing.Point(2, 2);
            this.tcVer.Margin = new System.Windows.Forms.Padding(2);
            this.tcVer.Name = "tcVer";
            this.tcVer.SelectedIndex = 0;
            this.tcVer.Size = new System.Drawing.Size(578, 347);
            this.tcVer.TabIndex = 0;
            // 
            // tbVerJogadores
            // 
            this.tbVerJogadores.Location = new System.Drawing.Point(4, 22);
            this.tbVerJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerJogadores.Name = "tbVerJogadores";
            this.tbVerJogadores.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerJogadores.Size = new System.Drawing.Size(570, 321);
            this.tbVerJogadores.TabIndex = 0;
            this.tbVerJogadores.Text = "Jogadores";
            this.tbVerJogadores.UseVisualStyleBackColor = true;
            // 
            // tbVerEquipas
            // 
            this.tbVerEquipas.Location = new System.Drawing.Point(4, 22);
            this.tbVerEquipas.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerEquipas.Name = "tbVerEquipas";
            this.tbVerEquipas.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerEquipas.Size = new System.Drawing.Size(570, 321);
            this.tbVerEquipas.TabIndex = 1;
            this.tbVerEquipas.Text = "Equipas";
            this.tbVerEquipas.UseVisualStyleBackColor = true;
            // 
            // tbVerTorneios
            // 
            this.tbVerTorneios.Location = new System.Drawing.Point(4, 22);
            this.tbVerTorneios.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerTorneios.Name = "tbVerTorneios";
            this.tbVerTorneios.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerTorneios.Size = new System.Drawing.Size(570, 321);
            this.tbVerTorneios.TabIndex = 2;
            this.tbVerTorneios.Text = "Torneios";
            this.tbVerTorneios.UseVisualStyleBackColor = true;
            // 
            // tbVerCartas
            // 
            this.tbVerCartas.Location = new System.Drawing.Point(4, 22);
            this.tbVerCartas.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerCartas.Name = "tbVerCartas";
            this.tbVerCartas.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerCartas.Size = new System.Drawing.Size(570, 321);
            this.tbVerCartas.TabIndex = 3;
            this.tbVerCartas.Text = "Cartas";
            this.tbVerCartas.UseVisualStyleBackColor = true;
            // 
            // tbVerBaralhos
            // 
            this.tbVerBaralhos.Location = new System.Drawing.Point(4, 22);
            this.tbVerBaralhos.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerBaralhos.Name = "tbVerBaralhos";
            this.tbVerBaralhos.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerBaralhos.Size = new System.Drawing.Size(570, 321);
            this.tbVerBaralhos.TabIndex = 4;
            this.tbVerBaralhos.Text = "Baralhos";
            this.tbVerBaralhos.UseVisualStyleBackColor = true;
            // 
            // tbVerUtilizadores
            // 
            this.tbVerUtilizadores.Location = new System.Drawing.Point(4, 22);
            this.tbVerUtilizadores.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerUtilizadores.Name = "tbVerUtilizadores";
            this.tbVerUtilizadores.Padding = new System.Windows.Forms.Padding(2);
            this.tbVerUtilizadores.Size = new System.Drawing.Size(570, 321);
            this.tbVerUtilizadores.TabIndex = 5;
            this.tbVerUtilizadores.Text = "Utilizadores";
            this.tbVerUtilizadores.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // playerSetTableAdapter
            // 
            this.playerSetTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nicknameDataGridViewTextBoxColumn
            // 
            this.nicknameDataGridViewTextBoxColumn.DataPropertyName = "Nickname";
            this.nicknameDataGridViewTextBoxColumn.HeaderText = "Nickname";
            this.nicknameDataGridViewTextBoxColumn.Name = "nicknameDataGridViewTextBoxColumn";
            this.nicknameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // avatarDataGridViewTextBoxColumn
            // 
            this.avatarDataGridViewTextBoxColumn.DataPropertyName = "Avatar";
            this.avatarDataGridViewTextBoxColumn.HeaderText = "Avatar";
            this.avatarDataGridViewTextBoxColumn.Name = "avatarDataGridViewTextBoxColumn";
            this.avatarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 377);
            this.Controls.Add(this.tbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(814, 495);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(606, 416);
            this.Name = "formMenuAdmin";
            this.Text = "Arcmage - Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMenuAdmin_FormClosed);
            this.Load += new System.EventHandler(this.formMenuAdmin_Load);
            this.tbMenu.ResumeLayout(false);
            this.tpGestao.ResumeLayout(false);
            this.tcGestao.ResumeLayout(false);
            this.tbGestaoJogadores.ResumeLayout(false);
            this.gbGJogadoresForm.ResumeLayout(false);
            this.gbGJogadoresForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdadeJogador)).EndInit();
            this.gbGJogadoresDados.ResumeLayout(false);
            this.gbGJogadoresDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaJogadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_DA_ProjetoDataSet)).EndInit();
            this.tbGestaoEquipas.ResumeLayout(false);
            this.gbGEquipasForm.ResumeLayout(false);
            this.gbGEquipasForm.PerformLayout();
            this.gbGEquipasDados.ResumeLayout(false);
            this.gbGEquipasDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGListaEquipas)).EndInit();
            this.tbGestaoTorneios.ResumeLayout(false);
            this.gbGJogosDados.ResumeLayout(false);
            this.gbGJogosDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGJogosLista)).EndInit();
            this.gbGTorneiosDados.ResumeLayout(false);
            this.gbGTorneiosDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGTorneiosLista)).EndInit();
            this.gbGTorneiosInfo.ResumeLayout(false);
            this.gbGJogosForm.ResumeLayout(false);
            this.gbGJogosForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNJogo)).EndInit();
            this.gbGTorneiosForm.ResumeLayout(false);
            this.gbGTorneiosForm.PerformLayout();
            this.tbGestaoCartas.ResumeLayout(false);
            this.gbGCartasForm.ResumeLayout(false);
            this.gbGCartasForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDefesaCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGAtaqueCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGLealdadeCarta)).EndInit();
            this.gbGCartasDados.ResumeLayout(false);
            this.gbGCartasDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGCartasLista)).EndInit();
            this.tbGestaoBaralhos.ResumeLayout(false);
            this.gbGCartasnoBaralho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gbGCartasparaBaralho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.gbGBaralhosDados.ResumeLayout(false);
            this.gbGBaralhosDados.PerformLayout();
            this.gbGBaralhosForm.ResumeLayout(false);
            this.gbGBaralhosForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGBaralhosLista)).EndInit();
            this.tbGestaoUtilizadores.ResumeLayout(false);
            this.gbGUtilizadoresForm.ResumeLayout(false);
            this.gbGUtilizadoresForm.PerformLayout();
            this.gbGUtilizadoresDados.ResumeLayout(false);
            this.gbGUtilizadoresDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGUtilizadoresLista)).EndInit();
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
        private System.Windows.Forms.Button btnRemoverEquipa;
        private System.Windows.Forms.Button btnAlterarEquipa;
        private System.Windows.Forms.Button btnInserirEquipa;
        private System.Windows.Forms.GroupBox gbGEquipasForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGNomeEquipa;
        private System.Windows.Forms.TextBox txtGAvatarEquipa;
        private System.Windows.Forms.Button txtEquipaCancelar;
        private System.Windows.Forms.Button txtEquipaAcao;
        private System.Windows.Forms.GroupBox gbGJogosDados;
        private System.Windows.Forms.GroupBox gbGTorneiosDados;
        private System.Windows.Forms.GroupBox gbGTorneiosInfo;
        private System.Windows.Forms.GroupBox gbGJogosForm;
        private System.Windows.Forms.GroupBox gbGTorneiosForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemoverJogo;
        private System.Windows.Forms.Button btnRemoverTorneio;
        private System.Windows.Forms.Button txtTorneioCancelar;
        private System.Windows.Forms.Button txtTorneioAcao;
        private System.Windows.Forms.TextBox txtDescricaoTorneio;
        private System.Windows.Forms.DateTimePicker tpDataTorneio;
        private System.Windows.Forms.TextBox txtNomeTorneio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnJogoCancelar;
        private System.Windows.Forms.Button btnJogoAcao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbJogador2Jogo;
        private System.Windows.Forms.ComboBox cmbJogador1Jogo;
        private System.Windows.Forms.NumericUpDown nudNJogo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker tpDataJogos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescricaoJogo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAvatarEquipa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGJogosPesquisa;
        private System.Windows.Forms.DataGridView dgvGJogosLista;
        private System.Windows.Forms.Button btnAlterarJogo;
        private System.Windows.Forms.Button btnInserirJogo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtGTorneiosPesquisa;
        private System.Windows.Forms.Button btnAlterarTorneio;
        private System.Windows.Forms.Button btnInserirTorneio;
        private System.Windows.Forms.DataGridView dgvGTorneiosLista;
        private System.Windows.Forms.GroupBox gbGCartasDados;
        private System.Windows.Forms.GroupBox gbGCartasForm;
        private System.Windows.Forms.DataGridView dgvGCartasLista;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGCartasPesquisa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCartaCancelar;
        private System.Windows.Forms.Button btnAcaoCarta;
        private System.Windows.Forms.NumericUpDown nudGDefesaCarta;
        private System.Windows.Forms.NumericUpDown nudGAtaqueCarta;
        private System.Windows.Forms.TextBox txtGRegrasCarta;
        private System.Windows.Forms.NumericUpDown nudGLealdadeCarta;
        private System.Windows.Forms.TextBox txtGCustoCarta;
        private System.Windows.Forms.ComboBox cmbGTipoCarta;
        private System.Windows.Forms.ComboBox cmbFacaoCarta;
        private System.Windows.Forms.TextBox txtGNomeCarta;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gbGBaralhosDados;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridView dgvGBaralhosLista;
        private System.Windows.Forms.Button btnInserirBaralho;
        private System.Windows.Forms.TextBox txtGBaralhosPesquisa;
        private System.Windows.Forms.Button btnGerirBaralho;
        private System.Windows.Forms.Button btnEliminarBaralho;
        private System.Windows.Forms.Button btnRemoverCartaBaralho;
        private System.Windows.Forms.Button btnGuardarAltBaralho;
        private System.Windows.Forms.Button btnCancelarAltBaralho;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAdicionarCartaBaralho;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox gbGCartasnoBaralho;
        private System.Windows.Forms.GroupBox gbGCartasparaBaralho;
        private System.Windows.Forms.GroupBox gbGBaralhosForm;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnGuardarBaralho;
        private System.Windows.Forms.Button btnCancelarNovoBaralho;
        private System.Windows.Forms.TextBox txtNomeBaralho;
        private System.Windows.Forms.GroupBox gbGUtilizadoresDados;
        private System.Windows.Forms.GroupBox gbGUtilizadoresForm;
        private System.Windows.Forms.Button btnAvatarUtilizador;
        private System.Windows.Forms.TextBox txtGAvatarUtilizador;
        private System.Windows.Forms.TextBox txtGNomeUtilizador;
        private System.Windows.Forms.ComboBox cmbGTipoUser;
        private System.Windows.Forms.TextBox txtGPasswordUtilizador;
        private System.Windows.Forms.TextBox txtGUsernameUtilizador;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnEliminarUtilizador;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnAlterarUtilizador;
        private System.Windows.Forms.DataGridView dgvGUtilizadoresLista;
        private System.Windows.Forms.Button btnInserirUtilizador;
        private System.Windows.Forms.TextBox txtGUtilizadoresPesquisa;
        private System.Windows.Forms.TextBox txtGEmailUtilizador;
        private System.Windows.Forms.Button btnCancelarUtilizador;
        private System.Windows.Forms.Button btnAcaoUtilizador;
        private System.Windows.Forms.Button btImagem;
        private System.Windows.Forms.TextBox txtAvatar;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BD_DA_ProjetoDataSet bD_DA_ProjetoDataSet;
        private System.Windows.Forms.BindingSource playerSetBindingSource;
        private BD_DA_ProjetoDataSetTableAdapters.PlayerSetTableAdapter playerSetTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nicknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avatarDataGridViewTextBoxColumn;
    }
}