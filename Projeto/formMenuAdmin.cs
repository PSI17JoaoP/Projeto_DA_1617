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
        }

        private DiagramaArcmageContainer container;
        private int idJogador;

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
    }
}
