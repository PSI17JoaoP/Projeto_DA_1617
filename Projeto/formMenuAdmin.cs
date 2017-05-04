//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class formMenuAdmin : Form
    {

        public formMenuAdmin()
        {
            InitializeComponent();
            container = new DiagramaArcmageContainer();
            //cbxpesquisarpor.SelectedIndex = 0;
        }

        private DiagramaArcmageContainer container;
        private int idJogador;
        private int idEquipa;

        private void formMenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin Login = new formLogin();
            Login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gbGTorneiosForm.Visible = true;
            gbGJogosForm.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gbGTorneiosForm.Visible = false;
            gbGJogosForm.Visible = true;
        }

        private void btnInserirJogador_Click(object sender, EventArgs e)
        {

            //Ativa o group box dos jogadores.
            gbGJogadoresForm.Enabled = true;
            //muda o nome do botão para criar.
            btnJogadoresAcao.Text = "Criar";
        }

        private void btnJogadoresAcao_Click(object sender, EventArgs e)
        {
            //recolher os dados referentes aos jogadores
            string nome = txtNomeJogador.Text;
            string email = txtEmailJogador.Text;
            string nickname = txtNickJogador.Text;
            int idade = (int)nudIdadeJogador.Value;
            string caminho = txtAvatar.Text;

            //validar se estão preenchidos
            if (nome.Length == 0 || email.Length == 0 || nickname.Length == 0 || idade == 0 || caminho.Length == 0)
            {
                if(nome.Length == 0 && email.Length == 0 && nickname.Length == 0 && idade == 0 && caminho.Length == 0)
                {
                    MessageBox.Show("Preencha todos os dados", "Preenchimento de dados");
                }
                else
                {
                    MessageBox.Show("Preencha os campos em branco", "Preenchimento de dados");
                }
            }
            else
            {
                //significa que todos os dados estão preenchidos e válidos.


                if(btnJogadoresAcao.Text == "Criar")
                {
                    //cria um novo.
                    //verificar se o jogador com esse nome já existe.
                    if(verificarNomeNickname(nome, email, nickname) == false)
                    {
                        inserirNovoJogador(nome, email, nickname, idade, caminho);
                        atualizarTabelaJogadores();
                    }
                     
                     /*if(inseriu == true)
                    {
                        MessageBox.Show("Jogador inserido com sucesso.");
                    }
                    else
                    {
                        MessageBox.Show("Jogador não inserido com sucesso.");
                    }
                    */

                }
                else if(btnJogadoresAcao.Text == "Guardar")
                {
                    //alterar o jogador
                    //verificar se o jogador com esse nome já existe.
                        
                    if (verificarNomeNickname(nome, email, nickname) == false)
                    {
                        alterarJogadorExistente(nome, email, nickname, idade, caminho);
                        atualizarTabelaJogadores();
                    }
                    
                }
            }
        }

        private Boolean verificarNomeNickname(string nome, string email, string nickname)
        {
            Boolean existe = false;
            foreach(Player player in container.PlayerSet.OfType<Player>())
            {

                if (btnJogadoresAcao.Text.Equals("Criar"))
                {
                    if(nome.Equals(player.Name) || email.Equals(player.Email)  || nickname.Equals(player.Nickname)){
                            existe = true;
                            enviarMensagemRepeticaoDados(player, nome, email, nickname);
                    }
                }

                if (btnJogadoresAcao.Text.Equals("Guardar"))
                {
                    if(player.Id != idJogador)
                    {
                        if(nome.Equals(player.Name) || nickname.Equals(player.Nickname))
                        {
                            existe = true;
                            enviarMensagemRepeticaoDados(player, nome, email, nickname);
                        }
                    }
                }
                
            }
            return existe;
        }

        private void enviarMensagemRepeticaoDados(Player player, string nome, string email, string nickname)
        {
            if (nome.Equals(player.Name))
            {
                MessageBox.Show("O nome tem de ser único.");
            }
            else if (email.Equals(player.Email))
            {
                MessageBox.Show("O email tem de ser único.");
            }
            else if (nickname.Equals(player.Nickname))
            {
                MessageBox.Show("O nickname tem de ser único.");
            }
        }

        private void alterarJogadorExistente(string nome, string email, string nickname, int idade, string caminho)
        {
            Player jogador;

            jogador = container.PlayerSet.Find(idJogador);

            jogador.Name = nome;
            jogador.Email = email;
            jogador.Nickname = nickname;
            jogador.Age = idade;
            jogador.Avatar = caminho;

            container.Entry(jogador).State = EntityState.Modified;
            container.SaveChanges();

            
        }

        private void atualizarTabelaJogadores()
        {
            //MessageBox.Show("Olá");
            //var query = from admins 
            dgvGListaJogadores.DataSource = null;
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.PlayerSet);
            dgvGListaJogadores.DataSource = this.playerSetBindingSource;


            //int i = dgvGListaJogadores.RowCount;
            //dgvGListaJogadores.Rows[i-1].Selected = true;


            //dgvGListaJogadores.Rows[]
            int i = dgvGListaJogadores.Rows.Count;

            dgvGListaJogadores.CurrentCell = dgvGListaJogadores.Rows[i - 1].Cells[0];


            //dgvGListaJogadores.CurrentCell = dgvGListaJogadores.Rows[dgvGListaJogadores.NewRowIndex].Cells[0];


            /*dgvGListaJogadores.Refresh();
            dgvGListaJogadores.Update();
            */

        }

        private void inserirNovoJogador(string nome, string email, string nickname, int idade, string caminho)
        {

            try
            {
                Player jogador = new Player
                {
                    Name = nome,
                    Email = email,
                    Nickname = nickname,
                    Age = idade,
                    Avatar = caminho
                };

                container.PlayerSet.Add(jogador);
                container.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("O jogador não foi inserido.", "Registo de Jogadores");
            }

            
        }

        private void btImagem_Click(object sender, EventArgs e)
        {
            //filtra e só deixa selecionar imagens
            openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            Image file;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //caminho da imagem para guardar no ado.
                string caminho = openFileDialog1.FileName;
                //titulo da janela
                openFileDialog1.Title = "Selecione uma imagem";
                txtAvatar.Text = caminho;
                //vai buscar a imagem
                file = Image.FromFile(caminho);
                //coloca a imagem na picture box.
                pictureBox1.Image = file;
            }
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnJogadoresCancelar_Click(object sender, EventArgs e)
        {
            carregarCancelarJogadores();
        }

        private void carregarCancelarJogadores()
        {
            txtNomeJogador.ResetText();
            txtEmailJogador.ResetText();
            txtNickJogador.ResetText();
            nudIdadeJogador.Value = 0;
            txtAvatar.ResetText();
            pictureBox1.Image = null;

            btnJogadoresAcao.Text = "Acção";

            gbGJogadoresForm.Enabled = false;

            btnAlterarJogador.Enabled = false;
            btnRemoverJogador.Enabled = false;
        }

        private void formMenuAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet.TeamSet' table. You can move, or remove it, as needed.
            this.teamSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.TeamSet);
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet1.PlayerSet' table. You can move, or remove it, as needed.
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.PlayerSet);

        }

        private void dgvGListaJogadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dgvGListaJogadores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvGListaJogadores_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
                
         }

        private void dgvGListaJogadores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvGListaJogadores.RowCount>0 && dgvGListaJogadores.SelectedCells.Count > 0)
            {
                    btnAlterarJogador.Enabled = true;
                    btnRemoverJogador.Enabled = true;
            }
        }

        private void btnAlterarJogador_Click(object sender, EventArgs e)
        {

            carregarCancelarJogadores();
            gbGJogadoresForm.Enabled = true;
            btnJogadoresAcao.Text = "Guardar";

            
            Image file;
            if(dgvGListaJogadores.SelectedCells.Count > 0)
            {

                gbGJogadoresForm.Enabled = true;
                idJogador = (int)dgvGListaJogadores.CurrentRow.Cells[0].Value;

                foreach(Player player in container.PlayerSet.OfType<Player>())
                {
                    if(player.Id == idJogador)
                    {
                        txtNomeJogador.Text = player.Name;
                        txtEmailJogador.Text = player.Email;
                        txtNickJogador.Text = player.Nickname;
                        nudIdadeJogador.Value = (int)player.Age;

                        file = Image.FromFile(player.Avatar);

                        txtAvatar.Text = player.Avatar;

                        pictureBox1.Image = file;

                        
                        
                    }
                }
                
                }

            
        }

        private void btnRemoverJogador_Click(object sender, EventArgs e)
        {
            if (dgvGListaJogadores.SelectedCells.Count > 0)
            {
                idJogador = (int)dgvGListaJogadores.CurrentRow.Cells[0].Value;
                string nome = dgvGListaJogadores.CurrentRow.Cells[1].Value.ToString();

                DialogResult confirmar = MessageBox.Show("Deseja eliminar o jogador com o nome " + nome + "?", "Eliminar dados", MessageBoxButtons.YesNo);

                if (confirmar == DialogResult.Yes)
                {
                    removerJogador();
                    atualizarTabelaJogadores();
                }
            }
        }

        private void removerJogador()
        {

            try {
            
                foreach(Player jogador in container.PlayerSet)
                {
                    if(jogador.Id == idJogador)
                    {
                        container.PlayerSet.Remove(jogador);
                    }
                }
                container.SaveChanges();
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Não é possível eliminar um jogador que está associado a uma equipa. Erro:" + ex.Message, "Eliminar dados");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao eliminar o jogador.", "Eliminar dados");
            }
            

        }

        private void txtGJogadoresPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(txtGJogadoresPesquisa.Text.Length > 0)
            {
                //atualizarTabelaJogadores();
                var query = from player in container.PlayerSet
                            where player.Name.Contains(txtGJogadoresPesquisa.Text)
                            select player;

                dgvGListaJogadores.DataSource = query.ToList();
            }
            else
            {
                atualizarTabelaJogadores();
            }
        }

        private void btnInserirEquipa_Click(object sender, EventArgs e)
        {
            gbGEquipasForm.Enabled = true;
            btnEquipaAcao.Text = "Criar";
        }

        private void btnEquipaAcao_Click(object sender, EventArgs e)
        {
            string nome = txtGNomeEquipa.Text;
            string caminho = txtGAvatarEquipa.Text;

            if(nome.Equals("") || caminho.Equals(""))
            {
                MessageBox.Show("Preencha os dados.", "Preenchimento de dados");
            }
            else
            {
                if (verificarNomeEquipa(nome) == false)
                {
                    if (btnEquipaAcao.Text.Equals("Criar"))
                    {
                        inserirNovaEquipa(nome, caminho);
                        atualizarTabelaEquipas();
                    }

                    else if (btnEquipaAcao.Text == "Guardar")
                    {
                        alterarEquipaExistente(nome, caminho);
                        atualizarTabelaEquipas();
                    }
                }
            }
        }

        private Boolean verificarNomeEquipa(string nome)
        {
            Boolean existe = false;
            foreach(Team team in container.TeamSet.OfType<Team>())
            {
                if (btnEquipaAcao.Text.Equals("Criar"))
                {
                    if (nome.Equals(team.Name))
                    {
                        existe = true;
                        MessageBox.Show("O nome tem de ser único.");
                    }
                }

                if (btnEquipaAcao.Text.Equals("Guardar"))
                {
                    if(team.Id != idEquipa)
                    {
                        if (nome.Equals(team.Name))
                        {
                            existe = true;
                            MessageBox.Show("O nome tem de ser único.");
                        }
                    }
                }

            }
            return existe;
        }

        private void alterarEquipaExistente(string nome, string caminho)
        {
            Team equipa;

            equipa = container.TeamSet.Find(idEquipa);

            equipa.Name = nome;
            equipa.Avatar = caminho;

            container.Entry(equipa).State = EntityState.Modified;
            container.SaveChanges();
        }

        private void atualizarTabelaEquipas()
        {
            dgvGListaEquipas.DataSource = null;
            this.teamSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.TeamSet);
            dgvGListaEquipas.DataSource = this.teamSetBindingSource;

            int i = dgvGListaEquipas.Rows.Count;

            dgvGListaEquipas.CurrentCell = dgvGListaEquipas.Rows[i - 1].Cells[0];
        }

        private void inserirNovaEquipa(string nome, string caminho)
        {

            try
            {
                Team equipa = new Team
                {
                    Name = nome,
                    Avatar = caminho
                };

                container.TeamSet.Add(equipa);
                container.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("A equipa não foi inserida.", "Registo de Equipas");
            }
        }

        private void btnAvatarEquipa_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File (JPG,PNG,GIF)|*.JPG;*.JPG;*.PNG;*.GIF";
            Image file;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string caminho = openFileDialog1.FileName;
                openFileDialog1.Title = "Selecione uma imagem";
                txtGAvatarEquipa.Text = caminho;
                file = Image.FromFile(caminho);
                pictureBoxAvatarEquipa.Image = file;
            }
            
        }

        private void txtEquipaCancelar_Click(object sender, EventArgs e)
        {
            carregarCancelarEquipas();
        }

        private void carregarCancelarEquipas()
        {
            txtGNomeEquipa.ResetText();
            txtGAvatarEquipa.ResetText();
            pictureBoxAvatarEquipa.Image = null;

            btnEquipaAcao.Text = "Acção";

            gbGEquipasForm.Enabled = false;

            btnAlterarEquipa.Enabled = false;
            btnRemoverEquipa.Enabled = false;
        }

        private void btnAlterarEquipa_Click(object sender, EventArgs e)
        {
            carregarCancelarEquipas();
            gbGEquipasForm.Enabled = true;
            btnEquipaAcao.Text = "Guardar";

            Image file;
            if(dgvGListaEquipas.SelectedCells.Count > 0)
            {
                gbGEquipasForm.Enabled = true;
                idEquipa = (int)dgvGListaEquipas.CurrentRow.Cells[0].Value;

                foreach(Team team in container.TeamSet.OfType<Team>())
                {
                    if(team.Id == idEquipa)
                    {
                        txtGNomeEquipa.Text = team.Name;
                        txtGAvatarEquipa.Text = team.Avatar;
                        file = Image.FromFile(team.Avatar);
                        pictureBoxAvatarEquipa.Image = file;
                    }
                }
            }
        }

        private void gbGEquipasForm_Enter(object sender, EventArgs e)
        {

        }

        private void dgvGListaEquipas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvGListaEquipas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgvGListaEquipas.RowCount>0 && dgvGListaEquipas.SelectedCells.Count > 0)
            {
                btnAlterarEquipa.Enabled = true;
                btnRemoverEquipa.Enabled = true;
            }
        }

        private void btnRemoverEquipa_Click(object sender, EventArgs e)
        {
            if(dgvGListaEquipas.SelectedCells.Count > 0)
            {
                idEquipa = (int)dgvGListaEquipas.CurrentRow.Cells[0].Value;
                string nome = dgvGListaEquipas.CurrentRow.Cells[1].Value.ToString();

                DialogResult confirmar = MessageBox.Show("Deseja eliminar a equipa com o nome " + nome + "?", "Eliminar dados", MessageBoxButtons.YesNo);

                if(confirmar == DialogResult.Yes)
                {
                    removerEquipa();
                    atualizarTabelaEquipas();
                }
            }
        }

        private void removerEquipa()
        {
            try
            {
                foreach(Team equipa in container.TeamSet)
                {
                    if(equipa.Id == idEquipa) {
                        container.TeamSet.Remove(equipa);
                    }
                }
                container.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao eliminar a equipa.", "Eliminar dados");
            }
        }

        private void txtGEquipasPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(txtGEquipasPesquisa.Text.Length > 0)
            {
                var query = from team in container.TeamSet
                            where team.Name.Contains(txtGEquipasPesquisa.Text)
                            select team;

                dgvGListaEquipas.DataSource = query.ToList();
            }
            else
            {
                atualizarTabelaEquipas();
            }
        }

        

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(cbxpesquisarpor.SelectedIndex != -1)
            {
                string pesquisapor = cbxpesquisarpor.SelectedItem.ToString();
                string pesquisa = txtpesquisa.Text;
                if (!pesquisa.Equals(""))
                {
                    
                    if (pesquisapor.Equals("Nome"))
                    {
                        var query = from player in container.PlayerSet
                                    where player.Name.Contains(pesquisa)
                                    select player;
                        dgvGListaJogadoresPesquisa.DataSource = query.ToList();
                    }
                    else if (pesquisapor.Equals("Email"))
                    {
                        var query1 = from player in container.PlayerSet
                                where player.Email.Contains(pesquisa)
                                select player;
                        dgvGListaJogadoresPesquisa.DataSource = query1.ToList();
                    }
                    else if (pesquisapor.Equals("Nickname"))
                    {
                        var query2 = from player in container.PlayerSet
                                    where player.Nickname.Contains(pesquisa)
                                    select player;
                        dgvGListaJogadoresPesquisa.DataSource = query2.ToList();
                    }
                    else if (pesquisapor.Equals("Idade"))
                    {
                        //int idade = int.Parse(txtpesquisa.Text);
                        int idade = 0;
                       
                        if(int.TryParse(pesquisa, out idade))
                        {
                          var query3 = from player in container.PlayerSet
                                        where player.Age == idade
                                        select player;
                          dgvGListaJogadoresPesquisa.DataSource = query3.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Insira valores numéricos.");
                        }


                            
                    
                        
                    }
                    
                }
                else
                {
                    atualizarTabelaJogadoresPesquisa();
                }
            }
        }
        */

        private void atualizarTabelaJogadoresPesquisa()
        {
            dgvGListaJogadoresPesquisa.DataSource = null;
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.PlayerSet);
            dgvGListaJogadoresPesquisa.DataSource = this.playerSetBindingSource;

            int i = dgvGListaJogadoresPesquisa.Rows.Count;

            dgvGListaJogadoresPesquisa.CurrentCell = dgvGListaJogadoresPesquisa.Rows[i - 1].Cells[0];
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            /*string filtro = " ";
            if (txtNomeJogador2.Text.Equals("") && txtEmailJogador2.Text.Equals("") && txtNicknameJogador2.Text.Equals("") && nudIdadeJogador2.Value == 0)
            {
                filtro = "Nenhum filtro aplicado. Todos os jogadores.";
            }
            else
            {
                filtro = "Filtro Aplicado\n";
                if (!txtNomeJogador2.Text.Equals(""))
                {
                    filtro += "Nome: " + txtNomeJogador2.Text;
                }
                if (!txtEmailJogador2.Text.Equals(""))
                {
                    filtro += "\nEmail: " + txtEmailJogador2.Text;
                }
                if (!txtNicknameJogador2.Text.Equals(""))
                {
                    filtro += "\nNickname: " + txtNicknameJogador2.Text;
                }
                if ((int)nudIdadeJogador2.Value != 0)
                {
                    filtro += "\nIdade: " + nudIdadeJogador2.Value;
                }



                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
                doc.Open();

                Paragraph paragraph = new Paragraph(filtro);

                doc.Add(paragraph);
                

                string[] tit = { "Id", "Nome", "Email", "Nickname", "Idade" };
                float[] larg = { 0.08f, 0.3f, 0.2f, 0.2f, 0.1f };

                PdfPTable tabela = new PdfPTable(tit.Length);

                tabela.SetWidths(larg);

                for(int i=0, n=tit.Length; i<n; i++){
                    string titulo = tit[i];
                    Paragraph p = new Paragraph(tit[i]);
                    iTextSharp.text.Font tipoletra = FontFactory.GetFont("Arial", 12.0f, 3, new BaseColor(255, 255, 255));
                    PdfPCell cel = new PdfPCell(p);
                    tabela.AddCell(cel);
                }

                //List<Class> myClass = DataGridView.Datasource as List<Class>;

                List<Player> jogadores = dgvGListaJogadoresPesquisa.DataSource as List<Player>;
                for(int i=0; i<jogadores.Count; i++)
                {
                    Player jogador = jogadores[i];
                    Paragraph id = new Paragraph(jogador.Id.ToString());
                    PdfPCell cel1 = new PdfPCell(id);
                    Paragraph nome = new Paragraph(jogador.Name);
                    PdfPCell cel = new PdfPCell(nome);
                    Paragraph email = new Paragraph(jogador.Email);
                    PdfPCell cel2 = new PdfPCell(email);
                    Paragraph nickname = new Paragraph(jogador.Nickname);
                    PdfPCell cel3 = new PdfPCell(nickname);
                    Paragraph idade = new Paragraph(jogador.Age.ToString());
                    PdfPCell cel4 = new PdfPCell(idade);
                    tabela.AddCell(cel1);
                    tabela.AddCell(cel);
                    tabela.AddCell(cel2);
                    tabela.AddCell(cel3);
                    tabela.AddCell(cel4);


                }



                doc.Add(tabela);
                doc.Close();

                



            }
            */
            

            

        }


        private void pesquisarJogadores(object sender, EventArgs e)
        {
            string nome = txtNomeJogador2.Text;
            string email = txtEmailJogador2.Text;
            string nickname = txtNicknameJogador2.Text;
            int idade = (int)nudIdadeJogador2.Value;

            IQueryable<Player> query = container.PlayerSet;

            if(nome.Length > 0)
            {
                query = query.Where(player => player.Name.Contains(nome));
            }

            if(email.Length > 0)
            {
                query = query.Where(player => player.Email.Contains(email));
            }

            if(nickname.Length > 0)
            {
                query = query.Where(player => player.Nickname.Contains(nickname));
            }
            if(idade != 0)
            {
                query = query.Where(player => player.Age == idade);
            }

            dgvGListaJogadoresPesquisa.DataSource = query.ToList();


            
                         

        }

        private void tbVerJogadores_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGerirEquipa_Click(object sender, EventArgs e)
        {
            idEquipa = (int)dgvGListaEquipas.CurrentRow.Cells[0].Value;
            int nrjogadores = 0;
            int nrequipas = 0;

            ListViewItem linhaJogadoresEquipa;
            ListViewItem linhaListaJogadores;

            lcListaJogadores.Items.Clear();
            lvJogadoresEquipa.Items.Clear();

            foreach(Player jogador in container.PlayerSet)
            {
                nrjogadores = 0;

                foreach(TeamPlayers equipasjogadores in container.TeamPlayersSet.Where(tp => tp.TeamId.Equals(idEquipa)))
                {
                    if(equipasjogadores.PlayerId == jogador.Id)
                    {
                        nrjogadores += 1;

                        linhaJogadoresEquipa = new ListViewItem(jogador.Name);
                        linhaJogadoresEquipa.SubItems.Add(jogador.Email);
                        linhaJogadoresEquipa.SubItems.Add(jogador.Age.ToString());
                        linhaJogadoresEquipa.SubItems.Add(jogador.Nickname);

                        lvJogadoresEquipa.Items.Add(linhaJogadoresEquipa);

                    }
                }
            }
            
            
            foreach (Player jogador in container.PlayerSet)
            {
                Boolean temEquipa = false;
                foreach(TeamPlayers equipasjogadores in container.TeamPlayersSet)
                {
                    if(equipasjogadores.PlayerId == jogador.Id)
                    {
                        temEquipa = true;
                    }
                }

                if(temEquipa == false)
                {
                    linhaListaJogadores = new ListViewItem(jogador.Name);
                    linhaListaJogadores.SubItems.Add(jogador.Email);
                    linhaListaJogadores.SubItems.Add(jogador.Age.ToString());
                    linhaListaJogadores.SubItems.Add(jogador.Nickname);
                    lcListaJogadores.Items.Add(linhaListaJogadores);
                }
            }
            
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            if (lcListaJogadores.SelectedItems.Count > 0)
            {
                ListViewItem jogador = lcListaJogadores.SelectedItems[0];
                //ListViewItem jogador1 = lcListaJogadores.SelectedItems;
                lcListaJogadores.Items.Remove(jogador);
                lvJogadoresEquipa.Items.Add(jogador);
            }
            int nrjogadores = lvJogadoresEquipa.Items.Count;

            if(nrjogadores < 2)
            {
                btnAdicionarJogador.Enabled = true;
                btnRetirarJogador.Enabled = true;
                btnGuardarJogadorEquipa.Enabled = false;

            }
            else
            {
                btnAdicionarJogador.Enabled = false;
                btnRetirarJogador.Enabled = true;
                btnGuardarJogadorEquipa.Enabled = true;
            }



            
            

            /*var selectedItems = lcListaJogadores.SelectedItems;
            foreach(ListViewItem selectedItem in selectedItems)
            {
                
            }*/

            
            

            //MessageBox.Show(jogador1.Text);
            //Player jogador = getJogador(jogador.Text);
            
        }

        private void btnGuardarJogadorEquipa_Click(object sender, EventArgs e)
        {
            Player jogador;
            TeamPlayers equipajogadores;

            /*var idJogadoresAnteriores = from equipasjogadores in container.TeamPlayersSet
                                        where equipasjogadores.TeamId == idEquipa
                                        select equipasjogadores;
            */

            /*context.Projects.Where(p => p.ProjectId == projectId)
               .ToList().ForEach(p => context.Projects.Remove(p));
            context.SaveChanges();
            */
    
            container.TeamPlayersSet.Where(tp => tp.TeamId == idEquipa)
                .ToList().ForEach(tp => container.TeamPlayersSet.Remove(tp));
            container.SaveChanges();

            foreach(ListViewItem item in lvJogadoresEquipa.Items)
            {
                var pesquisa = container.PlayerSet.Where(p => p.Name.Equals(item.Text));
                jogador = pesquisa.ToList().First<Player>();

                equipajogadores = new TeamPlayers();
                equipajogadores.TeamId = idEquipa;
                equipajogadores.PlayerId = jogador.Id;

                container.TeamPlayersSet.Add(equipajogadores);
            }

            container.SaveChanges();

        }

        private void btnRetirarJogador_Click(object sender, EventArgs e)
        {
            if(lvJogadoresEquipa.SelectedItems.Count > 0)
            {
                ListViewItem jogador = lvJogadoresEquipa.SelectedItems[0];
                lvJogadoresEquipa.Items.Remove(jogador);
                lcListaJogadores.Items.Add(jogador);
            }

            int nrjogadoresequipa = lvJogadoresEquipa.Items.Count;

            if(nrjogadoresequipa == 0)
            {
                btnRetirarJogador.Enabled = false;
            }
            else
            {
                btnRetirarJogador.Enabled = true;

                if(nrjogadoresequipa < 2)
                {
                    btnGuardarJogadorEquipa.Enabled = false;
                    btnAdicionarJogador.Enabled = true;
                }
            }
        }

        private void tbVerEquipas_Enter(object sender, EventArgs e)
        {
            cbnomejogadorpesquisa.Items.Clear();


            foreach(Player jogador in container.PlayerSet)
            {
                cbnomejogadorpesquisa.Items.Add(jogador.Name);
            }
        }

        private void pesquisarEquipas(object sender, EventArgs e)
        {
            string nomeequipa = tbxnomeequipapesquisa.Text;

            string nomejogador = "";

            if(cbnomejogadorpesquisa.SelectedIndex != -1)
            {
                nomejogador = cbnomejogadorpesquisa.SelectedItem.ToString();
            }

            
            if(!nomeequipa.Equals("") && cbnomejogadorpesquisa.SelectedIndex != -1) {
                //MessageBox.Show("Olá1");
                var query =
                    from equipa in container.TeamSet
                    join equipajogadores in container.TeamPlayersSet on equipa.Id equals equipajogadores.TeamId
                    join jogador in container.PlayerSet on equipajogadores.PlayerId equals jogador.Id
                    where jogador.Name.Equals(nomejogador) && equipa.Name.Contains(nomeequipa)
                    select equipa;
            
                dgvGListaEquipasPesquisa.DataSource = query.ToList();
            }
            else
            {
                if (!nomeequipa.Equals(""))
                {
                    //MessageBox.Show("Ola2");
                    var query =
                        from equipa in container.TeamSet
                        where equipa.Name.Contains(nomeequipa)
                        select equipa;

                    dgvGListaEquipasPesquisa.DataSource = query.ToList();
                }
                if (cbnomejogadorpesquisa.SelectedIndex != -1){
                    //MessageBox.Show("Olá3");
                    var query =
                    from equipa in container.TeamSet
                    join equipajogadores in container.TeamPlayersSet on equipa.Id equals equipajogadores.TeamId
                    join jogador in container.PlayerSet on equipajogadores.PlayerId equals jogador.Id
                    where jogador.Name.Equals(nomejogador) 
                    select equipa;

                    dgvGListaEquipasPesquisa.DataSource = query.ToList();
                }
            }

        }

        

        private void btlimpar_Click(object sender, EventArgs e)
        {
            tbxnomeequipapesquisa.ResetText();
            cbnomejogadorpesquisa.SelectedIndex = -1;
            dgvGListaEquipasPesquisa.DataSource = teamSetBindingSource;
            
            

        }

        private void limparTabelaPesquisas()
        {
            dgvGListaEquipasPesquisa.DataSource = teamSetBindingSource;

            tbxnomeequipapesquisa.ResetText();
            cbnomejogadorpesquisa.SelectedIndex = -1;
        }
    }
}
