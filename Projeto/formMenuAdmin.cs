using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class formMenuAdmin : Form
    {
        public DiagramaArcmageContainer containerDados;

        /// <summary>
        /// Variavel privada que guarda o id do árbitro selecionado.
        /// </summary>
        private int idArbitro;

        /// <summary>
        /// Variavel privada que guarda o id do administrador selecionado.
        /// </summary>
        private int idAdministrador;

        /// <summary>
        /// Variável usada para guardar o id da carta selecionada para alterar/remover
        /// </summary>
        private int idCarta;
        /// <summary>
        /// Variável usada para guardar o id do baralho selecionado para alterar/remover
        /// </summary>
        private int idBaralho;

        private int idJogador;

        private int idEquipa;

        public formMenuAdmin()
        {
            InitializeComponent();

            containerDados = new DiagramaArcmageContainer();
        }

        private void formMenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin Login = new formLogin();
            Login.Show();
        }

        private void formMenuAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet_Players.PlayerSet' table. You can move, or remove it, as needed.
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Players.PlayerSet);
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet_Teams.TeamSet' table. You can move, or remove it, as needed.
            this.teamSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Teams.TeamSet);
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet_Decks.DeckSet' table. You can move, or remove it, as needed.
            this.deckSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Decks.DeckSet);
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet_Cards.CardSet' table. You can move, or remove it, as needed.
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Cards.CardSet);
            // TODO: This line of code loads data into the 'dataSetArbitros.UserSet' table. You can move, or remove it, as needed.
            this.userSetTableAdapterArbitros.Fill(this.dataSetArbitros.UserSet);
            // TODO: This line of code loads data into the 'dataSetAdministradores.UserSet' table. You can move, or remove it, as needed.
            this.userSetTableAdapterAdministradores.Fill(this.dataSetAdministradores.UserSet);

            radioAdmins.Checked = true;
            radioPesquisaAdministrador.Checked = true;
        }

        private void btnRemoverTorneio_Click(object sender, EventArgs e)
        {
            gbGTorneiosForm.Visible = true;
            gbGJogosForm.Visible = false;
        }

        private void btnRemoverJogo_Click(object sender, EventArgs e)
        {
            gbGTorneiosForm.Visible = false;
            gbGJogosForm.Visible = true;
        }

        #region Gestão de Utiilizadores

        /// <summary>
        /// Evento do botão "Inserir" da tab de Utilizadores.
        /// Verifica qual é o tipo de uilizador selecionado e faz reset ao formulário.
        /// </summary>
        private void BotaoInserirUtilizador(object sender, EventArgs e)
        {
            if(radioAdmins.Checked == true)
            {
                ResetFormAdministrador();
                btnAcaoAdministrador.Text = "Adicionar";
                gbGAdministradorForm.Visible = true;
                gbGArbitroForm.Visible = false;
            }

            else
            {
                ResetFormArbitro();
                btnAcaoArbitro.Text = "Adicionar";
                gbGAdministradorForm.Visible = false;
                gbGArbitroForm.Visible = true;
            }
        }

        /// <summary>
        /// Evento do botão "Alterar" da tab de Utilizadores.
        /// Verifica qual é o tipo de utilizador selecionado, prepara e mostra o formulário com os dados do utilizador selecionado.
        /// </summary>
        private void BotaoAlterarUtilizador(object sender, EventArgs e)
        {
            if(VerificarTipoAdministrator(dgvGUtilizadoresLista.CurrentRow))
            {
                idAdministrador = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

                txtUsernameAdministrador.Text = admin.Username;
                txtEmailAdministrador.Text = admin.Email;

                btnAcaoAdministrador.Text = "Aplicar";
                gbGAdministradorForm.Visible = true;
                gbGArbitroForm.Visible = false;
                gbGUtilizadoresDados.Enabled = false;
            }

            else if(VerificarTipoReferee(dgvGUtilizadoresLista.CurrentRow))
            {
                idArbitro = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

                txtUsernameArbitro.Text = arbitro.Username;
                txtNomeArbitro.Text = arbitro.Name;
                txtAvatarArbitro.Text = arbitro.Avatar;

                if (File.Exists(arbitro.Avatar))
                {
                    using (Bitmap imagemAvatar = new Bitmap(arbitro.Avatar))
                    {
                        Image avatarArbitro = new Bitmap(imagemAvatar);
                        pbAvatarArbitro.Image = avatarArbitro;
                    }
                }

                btnAcaoArbitro.Text = "Aplicar";
                txtAvatarArbitro.Enabled = true;
                gbGAdministradorForm.Visible = false;
                gbGArbitroForm.Visible = true;
                gbGUtilizadoresDados.Enabled = false;
            }
        }

        /// <summary>
        /// Evento do botão "Eliminar" da tab de Utilizadores.
        /// Mostra uma mensagem de confirmação a perguntar se deseja remover o utilizador. Se sim, verifica qual o tipo de utilizador selecionado e remove-o.
        /// </summary>
        private void BotaoEliminarUtilizador(object sender, EventArgs e)
        {
            DialogResult confirmacaoEliminar = MessageBox.Show("Tem a certeza que quer eliminar o utilizador '" + dgvGUtilizadoresLista.CurrentRow.Cells[1].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacaoEliminar == DialogResult.Yes)
            {
                if (VerificarTipoAdministrator(dgvGUtilizadoresLista.CurrentRow))
                {
                    if (containerDados.UserSet.OfType<Administrator>().Count() > 1)
                    {
                        idAdministrador = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                        RemoverAdministrador();
                    }

                    else
                    {
                        MessageBox.Show("Tem de existir, no mínimo, uma administrador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (VerificarTipoReferee(dgvGUtilizadoresLista.CurrentRow))
                {
                    idArbitro = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                    RemoverArbitro();
                }
            }
        }

        /// <summary>
        /// Evento do botão no formulário de preenchimento do Administrador, que realiza as funções de "Adicionar" ou "Aplicar".
        /// </summary>
        private void BotaoAcaoAdministrador(object sender, EventArgs e)
        {
            string usernameForm = txtUsernameAdministrador.Text.Trim();
            string emailForm = txtEmailAdministrador.Text.Trim();

            if (btnAcaoAdministrador.Text == "Aplicar")
            {
                DialogResult confirmacaoAlterar = MessageBox.Show("Tem a certeza que quer alterar o administrador '" + dgvGUtilizadoresLista.CurrentRow.Cells[1].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacaoAlterar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarAlteracoesAdministrador(usernameForm, emailForm))
                            {
                                AlterarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                ResetFormAdministrador();
                                gbGAdministradorForm.Visible = false;
                            }

                            else
                            {
                                MessageBox.Show("O administrador editado já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    else if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length == 0 && emailForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarAlteracoesAdministrador(usernameForm, emailForm))
                            {
                                AlterarAdministrador(usernameForm, emailForm);
                                ResetFormAdministrador();
                                gbGAdministradorForm.Visible = false;
                            }

                            else
                            {
                                MessageBox.Show("O administrador editado já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Tem de preencher os campos necessários para efetuar as alterações.\nSe pretender manter a password atual, deixe o campo da password em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (btnAcaoAdministrador.Text == "Adicionar")
            {
                DialogResult confirmacaoAdicionar = MessageBox.Show("Tem a certeza que quer adicionar o administrador '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacaoAdicionar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarDadosAdmnistrador(usernameForm, emailForm))
                            {
                                AdicionarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                ResetFormAdministrador();
                                gbGAdministradorForm.Visible = false;
                            }

                            else
                            {
                                MessageBox.Show("O administrador inserido já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else
                        {
                            AdicionarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                            ResetFormAdministrador();
                            gbGAdministradorForm.Visible = false;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Tem de preencher todos os campos para adicionar o Admin.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Evento do botão no formulário de preenchimento do Arbitro, que realiza as funções de "Adicionar" ou "Aplicar".
        /// </summary>
        private void BotaoAcaoArbitro(object sender, EventArgs e)
        {
            string usernameForm = txtUsernameArbitro.Text.Trim();
            string nomeForm = txtNomeArbitro.Text.Trim();
            string avatarPathRelative = GetPathRelativeAvatarArbitro(txtAvatarArbitro.Text.Trim(), usernameForm);
            string avatarPathAbsoluto = txtAvatarArbitro.Text.Trim();

            if (btnAcaoArbitro.Text == "Aplicar")
            {
                DialogResult confirmacaoAlterar = MessageBox.Show("Tem a certeza que quer alterar o arbitro '" + dgvGUtilizadoresLista.CurrentRow.Cells[1].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacaoAlterar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarPathAbsoluto.Length > 0)
                    {
                        if (File.Exists(avatarPathAbsoluto))
                        {
                            if (containerDados.UserSet.Count() > 0)
                            {
                                if (VerificarAlteracoesArbitro(usernameForm, nomeForm, avatarPathRelative))
                                {
                                    if (pbAvatarArbitro.Image.Width <= 128 && pbAvatarArbitro.Image.Height <= 128)
                                    {
                                        AlterarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarPathRelative, avatarPathAbsoluto);
                                        ResetFormArbitro();
                                        gbGArbitroForm.Visible = false;
                                    }
                                }


                                else
                                {
                                    MessageBox.Show("O arbitro editado já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }

                    else if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length == 0 && nomeForm.Length > 0 && avatarPathAbsoluto.Length > 0 && pbAvatarArbitro.Image.Height <= 128 && pbAvatarArbitro.Image.Width <= 128)
                    {
                        if (File.Exists(avatarPathAbsoluto))
                        {
                            if (containerDados.UserSet.Count() > 0)
                            {
                                if (VerificarAlteracoesArbitro(usernameForm, nomeForm, avatarPathRelative))
                                {
                                    if (pbAvatarArbitro.Image.Width <= 128 && pbAvatarArbitro.Image.Height <= 128)
                                    {
                                        AlterarArbitro(usernameForm, nomeForm, avatarPathRelative, avatarPathAbsoluto);
                                        ResetFormArbitro();
                                        gbGArbitroForm.Visible = false;
                                    }
                                }


                                else
                                {
                                    MessageBox.Show("O arbitro editado já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Tem de preencher os campos necessários para efetuar as alterações.\nSe pretender manter a password atual, deixe o campo da password em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (btnAcaoArbitro.Text == "Adicionar")
            {
                DialogResult confirmacaoAdicionar = MessageBox.Show("Tem a certeza que quer adicionar o arbitro '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacaoAdicionar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarPathAbsoluto.Length > 0 && pbAvatarArbitro.Image.Height <= 128 && pbAvatarArbitro.Image.Width <= 128)
                    {
                        if (File.Exists(avatarPathAbsoluto))
                        {
                            if (containerDados.UserSet.Count() > 0)
                            {
                                if (VerificarDadosArbitro(usernameForm, nomeForm, avatarPathRelative))
                                {
                                    if (pbAvatarArbitro.Image.Width <= 128 && pbAvatarArbitro.Image.Height <= 128)
                                    {
                                        AdicionarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarPathRelative, avatarPathAbsoluto);
                                        ResetFormArbitro();
                                        gbGArbitroForm.Visible = false;
                                    }
                                }


                                else
                                {
                                    MessageBox.Show("O arbitro inserido já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            else
                            {
                                if (pbAvatarArbitro.Image.Width <= 128 && pbAvatarArbitro.Image.Height <= 128)
                                {
                                    AdicionarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarPathRelative, avatarPathAbsoluto);
                                    ResetFormArbitro();
                                    gbGArbitroForm.Visible = false;
                                }
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Tem de preencher todos os campos para adicionar o Arbitro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Evento do botão "Cancelar" no formulário de preenchimento do Arbitro.
        /// Faz reset ao formulário.
        /// </summary>
        private void BotaoCancelarArbitro(object sender, EventArgs e)
        {
            ResetFormArbitro();
            gbGArbitroForm.Visible = false;
        }

        /// <summary>
        /// Evento do botão "Cancelar" no formulário de preenchimento do Administrador.
        /// Faz reset ao formulário.
        /// </summary>
        private void BotaoCancelarAdministrador(object sender, EventArgs e)
        {
            ResetFormAdministrador();
            gbGAdministradorForm.Visible = false;
        }

        /// <summary>
        /// Evento do radio button "Administradores".
        /// Apenas invoca o método RefreshTabelaUtilizadores para fazer refresh à tabela.
        /// </summary>
        private void RadioFiltrarAdministradores(object sender, EventArgs e)
        {
            if(radioAdmins.Checked == true)
            {
                txtGUtilizadoresPesquisa.Clear();
                RefreshTabelaUtilizadores();
            }
        }

        /// <summary>
        /// Evento do radio button "Arbitros".
        /// Apenas invoca o método RefreshTabelaUtilizadores para fazer refresh à tabela.
        /// </summary>
        private void RadioFiltrarArbitros(object sender, EventArgs e)
        {
            if (radioArbitros.Checked == true)
            {
                txtGUtilizadoresPesquisa.Clear();
                RefreshTabelaUtilizadores();
            }
        }

        /// <summary>
        /// Evento de pesquisar utilizadores, quando o utilizador insere dados na Textbox de pesquisar.
        /// Executa uma query Linq em que o nome do utilizador contem o que for inserido na Textbox e põe os resultados na Data Grid View correspondente.
        /// </summary>
        private void PesquisarUtilizador(object sender, EventArgs e)
        {
            if (txtGUtilizadoresPesquisa.Text.Length > 0)
            {
                if (radioAdmins.Checked == true)
                {
                    IEnumerable<BD_DA_ProjetoDataSet_Administradores.UserSetRow> queryLinq = from admins in dataSetAdministradores.UserSet
                                                                                             where admins.Field<string>("Username").Contains(txtGUtilizadoresPesquisa.Text)
                                                                                             select admins;
                    if (queryLinq.Any() == true)
                    {
                        DataTable queryTable = queryLinq.CopyToDataTable();

                        bindingSourceAdminstradores.DataSource = queryTable;

                        dgvGUtilizadoresLista.DataSource = bindingSourceAdminstradores;
                    }

                    else
                    {
                        dgvGUtilizadoresLista.DataSource = null;
                    }
                }

                else if (radioArbitros.Checked == true)
                {
                    IEnumerable<BD_DA_ProjetoDataSet_Arbitros.UserSetRow> queryLinq = from arbitros in dataSetArbitros.UserSet
                                                                                      where arbitros.Field<string>("Username").Contains(txtGUtilizadoresPesquisa.Text)
                                                                                      select arbitros;
                    if (queryLinq.Any() == true)
                    {
                        DataTable queryTable = queryLinq.CopyToDataTable();

                        bindingSourceArbitros.DataSource = queryTable;

                        dgvGUtilizadoresLista.DataSource = bindingSourceArbitros;
                    }

                    else
                    {
                        dgvGUtilizadoresLista.DataSource = null;
                    }
                }
            }

            else
            {
                txtGUtilizadoresPesquisa.Clear();
                RefreshTabelaUtilizadores();
            }
        }

        /// <summary>
        /// Método de inserção de um arbitro.
        /// Cria uma instancia da classe Referee com os dados enviados por parêmetro e insere a instância no DataSet "UserSet".
        /// Guarda o avatar escolhido na pasta "Documentos" da conta de utilizador atual.
        /// No final, faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="passArbitro">Password do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AdicionarArbitro(string usernameArbitro, string passArbitro, string nomeArbitro, string avatarPathArbitro, string avatarPathAbsoluto)
        {
            try
            {
                Referee novoArbitro = new Referee
                {
                    Username = usernameArbitro,
                    Password = HashPassword(passArbitro),
                    Name = nomeArbitro,
                    Avatar = avatarPathArbitro
                };

                GuardarImagem(avatarPathArbitro, avatarPathAbsoluto);

                containerDados.UserSet.Add(novoArbitro);
                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na inserção do arbitro." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método de inserção de um administrador.
        /// Cria uma instancia da classe Administrator com os dados enviados por parêmetro e insere a instância no DataSet "UserSet".
        /// No final, faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Administrador</param>
        /// <param name="passAdministrador">Password do Administrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        private void AdicionarAdministrador(string usernameAdministrador, string passAdministrador, string emailAdministrador)
        {
            try
            {
                Administrator novoAdministrador = new Administrator
                {
                    Username = usernameAdministrador,
                    Password = HashPassword(passAdministrador),
                    Email = emailAdministrador
                };

                containerDados.UserSet.Add(novoAdministrador);
                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na inserção do administrador." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método de encriptação da password de um utilizador.
        /// Encripta a password em hash de SHA1 e devolve a hash da password.
        /// </summary>
        /// <param name="password">Password do utilizador</param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            string passwordHash;

            using (SHA1 sha1Algorithm = new SHA1CryptoServiceProvider())
            {
                byte[] dadosBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha1Algorithm.ComputeHash(dadosBytes);

                passwordHash = BitConverter.ToString(hashBytes);
            }

            return passwordHash;
        }

        /// <summary>
        /// Método da alteração de um árbitro.
        /// Pesquisa pelo árbitro com o id idArbitro, e guarda os novos dados no mesmo.
        /// Guarda o avatar escolhido na pasta "Documentos" da conta de utilizador atual.
        /// No final, guarda as alterações na base de dados e faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="passArbitro">Password do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AlterarArbitro(string usernameArbitro, string passArbitro, string nomeArbitro, string avatarPathArbitro, string avatarPathAbsoluto)
        {
            try
            {
                Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

                arbitro.Username = usernameArbitro;
                arbitro.Password = HashPassword(passArbitro);
                arbitro.Name = nomeArbitro;
                arbitro.Avatar = avatarPathArbitro;

                GuardarImagem(avatarPathArbitro, avatarPathAbsoluto);

                containerDados.Entry(arbitro).State = EntityState.Modified;

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na edição do arbitro." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Overload no método AlterarArbitro, sem a password para o caso do utilizador querer manter a password existente.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AlterarArbitro(string usernameArbitro, string nomeArbitro, string avatarPathArbitro, string avatarPathAbsoluto)
        {
            try
            {
                Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

                arbitro.Username = usernameArbitro;
                arbitro.Name = nomeArbitro;
                arbitro.Avatar = avatarPathArbitro;

                GuardarImagem(avatarPathArbitro, avatarPathAbsoluto);

                containerDados.Entry(arbitro).State = EntityState.Modified;

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na edição do arbitro." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método da alteração de um administrador.
        /// Pesquisa pelo árbitro com o id idAdmininstrador, e guarda os novos dados no mesmo.
        /// No final, guarda as alterações na base de dados e faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Admnistrador</param>
        /// <param name="passAdministrador">Password do Administrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        private void AlterarAdministrador(string usernameAdministrador, string passAdministrador, string emailAdministrador)
        {
            try
            {
                Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

                admin.Username = usernameAdministrador;
                admin.Password = HashPassword(passAdministrador);
                admin.Email = emailAdministrador;

                containerDados.Entry(admin).State = EntityState.Modified;

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na edição do administrador." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Overload no método AlterarAdministrador, sem a password para o caso do utilizador querer manter a password existente.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Admnistrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        private void AlterarAdministrador(string usernameAdministrador, string emailAdministrador)
        {
            try
            {
                Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

                admin.Username = usernameAdministrador;
                admin.Email = emailAdministrador;

                containerDados.Entry(admin).State = EntityState.Modified;

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na edição do administrador." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método de remoção de um administrador.
        /// Remove um administrador do Data Set "UserSet".
        /// De seguida, guarda as modificações do UserSet na base de dados e faz refresh à tabela.
        /// </summary>
        private void RemoverAdministrador()
        {
            try
            {
                Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

                containerDados.UserSet.Remove(admin);

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na remoção do administrador." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método de remoção de um arbitro.
        /// Remove um arbitro do Data Set "UserSet".
        /// De seguida, guarda as modificações do UserSet na base de dados e faz refresh à tabela.
        /// </summary>
        private void RemoverArbitro()
        {
            try
            {
                Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

                if (File.Exists(arbitro.Avatar))
                {
                    File.Delete(arbitro.Avatar);
                }

                containerDados.UserSet.Remove(arbitro);

                containerDados.SaveChanges();
                RefreshTabelaUtilizadores();
            }

            catch (Exception excecaoErro)
            {
                MessageBox.Show("Ocorreu um erro na remoção do arbitro." + excecaoErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento do botão de Procurar o avatar do Arbitro.
        /// Abre um OpenFileDialog a perguntar ao utilizador qual a imagem a guardar como avatar.
        /// Coloca no formulário a imagem e o caminho absoluto da imagem selecionada.
        /// </summary>
        private void BotaoProcurarAvatar(object sender, EventArgs e)
        {
            ofdAvatarArbitro.Title = "Selecione uma imagem";
            ofdAvatarArbitro.Filter = "Image Files (JPG, JPEG,PNG)|*.JPG;*.JPEG;*.PNG";
            ofdAvatarArbitro.FileName = null;

            if (ofdAvatarArbitro.ShowDialog() == DialogResult.OK)
            {
                string avatarPath = ofdAvatarArbitro.FileName;

                using (Bitmap imagemAvatar = new Bitmap(avatarPath))
                {
                    if (imagemAvatar.Width <= 128 && imagemAvatar.Height <= 128)
                    {
                        Image avatarArbitro = new Bitmap(imagemAvatar);
                        pbAvatarArbitro.Image = avatarArbitro;
                        txtAvatarArbitro.Text = avatarPath;
                        txtAvatarArbitro.Enabled = true;
                    }

                    else
                    {
                        MessageBox.Show("Tem de escolher um avatar de dimensão igual ou inferior a 128x128.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Método para contruir o caminho relativo, isto é, o caminho onde o avatar irá ser guardado, através do caminho absoluto (onde a imagem se encontra).
        /// O avatar irá ter como nome, o username do arbitro.
        /// </summary>
        /// <param name="avatarPathAbsoluto">Caminho absoluto do avatar</param>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <returns></returns>
        private string GetPathRelativeAvatarArbitro(string avatarPathAbsoluto, string usernameArbitro)
        {
            DirectoryInfo avatarPath = Directory.CreateDirectory(Environment.CurrentDirectory + "/arbitros/avatars");

            string avatarPathRelative = avatarPath.FullName + "\\" + usernameArbitro + ".png";

            return avatarPathRelative;
        }

        /// <summary>
        /// Método para guardar a imagem na pasta "Documentos" da conta do utilizador atual.
        /// Encontra a imagem através do caminho absoluto (a pasta onde se encontra) e, se for diferente do caminho relativo (onde irá ser guardada),
        /// isto é, se a imagem escolhida é diferente do que a atual, elimina e faz uma nova cópia para o caminho relativo.
        /// </summary>
        /// <param name="avatarPathRelative">Caminho relativo do avatar</param>
        /// <param name="avatarPathAbsoluto">Caminho absoluto do avatar</param>
        private void GuardarImagem(string avatarPathRelative, string avatarPathAbsoluto)
        {
            if (File.Exists(avatarPathRelative))
            {
                if(avatarPathAbsoluto != avatarPathRelative)
                {
                    File.Delete(avatarPathRelative);

                    using (Bitmap imagemAvatar = new Bitmap(avatarPathAbsoluto))
                    {
                        if (imagemAvatar.Width <= 128 && imagemAvatar.Height <= 128)
                        {
                            Image avatarArbitro = new Bitmap(imagemAvatar);
                            avatarArbitro.Save(avatarPathRelative, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
            }

            else
            {
                using (Bitmap imagemAvatar = new Bitmap(avatarPathAbsoluto))
                {
                    if (imagemAvatar.Width <= 128 && imagemAvatar.Height <= 128)
                    {
                        Image avatarArbitro = new Bitmap(imagemAvatar);
                        avatarArbitro.Save(avatarPathRelative, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }

        /// <summary>
        /// Método para fazer refresh à DataGridView (Tabela) na tab dos Utilizadores.
        /// Muda a Data Source da Data Grid View para o tipo do utilizador correspondente.
        /// </summary>
        private void RefreshTabelaUtilizadores()
        {
            if(radioAdmins.Checked == true)
            {
                bindingSourceAdminstradores.DataSource = dataSetAdministradores.UserSet;
                userSetTableAdapterAdministradores.Fill(dataSetAdministradores.UserSet);
                dgvGUtilizadoresLista.DataSource = bindingSourceAdminstradores;
            }

            else if (radioArbitros.Checked == true)
            {
                bindingSourceArbitros.DataSource = dataSetArbitros.UserSet;
                userSetTableAdapterArbitros.Fill(dataSetArbitros.UserSet);
                dgvGUtilizadoresLista.DataSource = bindingSourceArbitros;
            }
        }

        /// <summary>
        /// Método para fazer reset ao formulário de preenchimento do Arbitro.
        /// Limpa os dados presentes de formulário.
        /// </summary>
        private void ResetFormAdministrador()
        {
            txtUsernameAdministrador.Clear();
            txtPasswordAdministrador.Clear();
            txtEmailAdministrador.Clear();
            gbGUtilizadoresDados.Enabled = true;
        }

        /// <summary>
        /// Método para fazer reset ao formulário de preenchimento do Administrador.
        /// Limpa os dados presentes de formulário.
        /// </summary>
        private void ResetFormArbitro()
        {
            txtUsernameArbitro.Clear();
            txtPasswordArbitro.Clear();
            txtNomeArbitro.Clear();
            txtAvatarArbitro.Clear();
            pbAvatarArbitro.Image = null;
            gbGUtilizadoresDados.Enabled = true;
        }

        /// <summary>
        /// Método para verificar se o utilizador inseriu dados já existentes na base de dados, sende estes o username e o email do administrador.
        /// Verifica se o username inserido é igual ao username de cada utilizador.
        /// De seguida, verifica se o email inserido é igual ao email de cada administrador.
        /// Se for igual para qualquer dos casos, a variável boolean "naoExisteDados" é igual a false.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Administrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        /// <returns></returns>
        private bool VerificarDadosAdmnistrador(string usernameAdministrador, string emailAdministrador)
        {
            bool naoExisteDados = true;

            foreach (User utilizador in containerDados.UserSet)
            {
                if (utilizador.Username == usernameAdministrador)
                {
                    naoExisteDados = false;
                }

                else
                {
                    foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                    {
                        if (admin.Email == emailAdministrador)
                        {
                            naoExisteDados = false;
                        }
                    }
                }
            }

            return naoExisteDados;
        }

        /// <summary>
        /// Método para verificar se o utilizador inseriu dados já existentes na base de dados, sende estes o username, o nome e avtar do arbitro.
        /// Verifica se o username inserido é igual ao username de cada utilizador.
        /// De seguida, verifica se o nome inserido é igual ao nome de cada arbitro.
        /// Se for igual para qualquer dos casos, a variável boolean "naoExisteDados" é igual a false.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        /// <returns>Variavel Boolean "naoExisteDados"</returns>
        private bool VerificarDadosArbitro(string usernameArbitro, string nomeArbitro, string avatarPathArbitro)
        {
            bool naoExisteDados = true;

            foreach (User utilizador in containerDados.UserSet)
            {
                if (utilizador.Username == usernameArbitro)
                {
                    naoExisteDados = false;
                }

                else
                {
                    foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                    {
                        if (arbitro.Name == nomeArbitro)
                        {
                            naoExisteDados = false;
                        }
                    }
                }
            }

            return naoExisteDados;
        }

        /// <summary>
        /// Método para verificar se a linha da tabela na tab dos Utilizadores é do tipo Administrator.
        /// Verifica se o id da linha selecionada é igual ao id de um administrador.
        /// Se for igual, a variavel Boolean "isTipoAdministrator" é igual a true.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="rowUtilizador">Linha da Tabela do utilizador selecionado</param>
        /// <returns>Variavel Boolean "isTipoAdministrator"</returns>
        private bool VerificarTipoAdministrator(DataGridViewRow rowUtilizador)
        {
            bool isTipoAdministrator = false;

            foreach(Administrator admin in containerDados.UserSet.OfType<Administrator>())
            {
                if(admin.Id == (int)rowUtilizador.Cells[0].Value)
                {
                    isTipoAdministrator = true;
                }
            }

            return isTipoAdministrator;
        }

        /// <summary>
        /// Método para verificar se a linha da tabela na tab dos Utilizadores é do tipo Referee.
        /// Verifica se o id da linha selecionada é igual ao id de um arbitro.
        /// Se for igual, a variavel Boolean "isTipoArbitro" é igual a true.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="rowUtilizador">Linha da Tabela do utilizador selecionado</param>
        /// <returns>Variavel Boolean "isTipoArbitro"</returns>
        private bool VerificarTipoReferee(DataGridViewRow rowUtilizador)
        {
            bool isTipoArbitro = false;

            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
            {
                if (arbitro.Id == (int)rowUtilizador.Cells[0].Value)
                {
                    isTipoArbitro = true;
                }
            }

            return isTipoArbitro;
        }

        /// <summary>
        /// Método para verificar se os dados alterados já existem na base de dados.
        /// Verifica se o username alterado é igual ao username de cada administrador, exceto o administrador a ser alterado.
        /// De seguida, verifica se o email é igual ao email de cada adminstrador, excetp o administrador a ser alterado.
        /// Se for igual para qualquer dos casos, a variavel Boolean "aplicaAlteracoes" é igual a false.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Administrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        /// <returns>Variavel Boolean "aplicaAlteracoes"</returns>
        private bool VerificarAlteracoesAdministrador(string usernameAdministrador, string emailAdministrador)
        {
            bool aplicaAlteracoes = true;

            foreach (User utilizador in containerDados.UserSet)
            {
                if(utilizador.Username == usernameAdministrador && utilizador.Id != idAdministrador)
                {
                    aplicaAlteracoes = false;
                }

                else
                {
                    foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                    {
                        if(admin.Email == emailAdministrador && admin.Id != idAdministrador)
                        {
                            aplicaAlteracoes = false;
                        }
                    }
                }
            }

            return aplicaAlteracoes;
        }

        /// <summary>
        /// Método para verificar se os dados alterados já existem na base de dados.
        /// Verifica se o username alterado é igual ao username de cada arbitro, exceto o arbitro a ser alterado.
        /// De seguida, verifica se o nome é igual ao nome de cada arbitro, exceto o arbitro a ser alterado.
        /// Se for igual para qualquer dos casos, a variavel Boolean "aplicaAlteracoes" é igual a false.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        /// <returns>Variavel Boolean "aplicaAlteracoes"</returns>
        private bool VerificarAlteracoesArbitro(string usernameArbitro, string nomeArbitro, string avatarPathArbitro)
        {
            bool aplicaAlteracoes = true;

            foreach (User utilizador in containerDados.UserSet)
            {
                if (utilizador.Username == usernameArbitro && utilizador.Id != idArbitro)
                {
                    aplicaAlteracoes = false;
                }

                else
                {
                    foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                    {
                        if (arbitro.Name == nomeArbitro && arbitro.Id != idArbitro)
                        {
                            aplicaAlteracoes = false;
                        }
                    }
                }
            }

            return aplicaAlteracoes;
        }

        #endregion

        #region Pesquisa de Utilizadores

        private void RadioPesquisarAdministrador(object sender, EventArgs e)
        {
            ResetPesquisaUtilizadoresForm();
            RefreshTabelaPesquisaUtilizadores();
        }

        private void RadioPesquisarArbitro(object sender, EventArgs e)
        {
            ResetPesquisaUtilizadoresForm();
            RefreshTabelaPesquisaUtilizadores();
        }

        private void CheckArbitroAtivo(object sender, EventArgs e)
        {
            if (checkPesquisaArbitroAtivo.Checked == true)
            {
                PesquisarArbitrosAtivos(txtPesquisaUsername.Text.Trim(), txtPesquisaNomeArbitro.Text.Trim());
            }

            else
            {
                PesquisarArbitros(txtPesquisaUsername.Text.Trim(), txtPesquisaNomeArbitro.Text.Trim());
            }
        }

        private void PesquisaAvancadaUtilizador(object sender, EventArgs e)
        {
            if (radioPesquisaAdministrador.Checked == true)
            {
                PesquisarAdminstrador(txtPesquisaUsername.Text.Trim(), txtPesquisaEmailAdministrador.Text.Trim());
            }

            else if (radioPesquisaArbitro.Checked == true)
            {
                if(checkPesquisaArbitroAtivo.Checked == true)
                {
                    PesquisarArbitrosAtivos(txtPesquisaUsername.Text.Trim(), txtPesquisaNomeArbitro.Text.Trim());
                }

                else
                {
                    PesquisarArbitros(txtPesquisaUsername.Text.Trim(), txtPesquisaNomeArbitro.Text.Trim());
                }
            }
        }

        private void BotaoResetPesquisa(object sender, EventArgs e)
        {
            ResetPesquisaUtilizadoresForm();
            RefreshTabelaPesquisaUtilizadores();
        }

        private void PesquisarAdminstrador(string username, string email)
        {
            IEnumerable<BD_DA_ProjetoDataSet_Administradores.UserSetRow> queryLinq;

            if (username.Length > 0 && email.Length > 0)
            {
                queryLinq = from admins in dataSetAdministradores.UserSet
                            where admins.Field<string>("Username").Contains(username)
                            && admins.Field<string>("Email").Contains(email)
                            select admins;
            }

            else if(username.Length > 0)
            {
                queryLinq = from admins in dataSetAdministradores.UserSet
                            where admins.Field<string>("Username").Contains(username)
                            select admins;
            }

            else if(email.Length > 0)
            {
                queryLinq = from admins in dataSetAdministradores.UserSet
                            where admins.Field<string>("Email").Contains(email)
                            select admins;
            }

            else
            {
                queryLinq = from admins in dataSetAdministradores.UserSet
                            select admins;
            }

            if (queryLinq.Any() == true)
            {
                DataTable queryTable = queryLinq.CopyToDataTable();

                bindingSourceAdminstradores.DataSource = queryTable;

                dgvPesquisaUtilizadores.DataSource = bindingSourceAdminstradores;
            }

            else
            {
                dgvPesquisaUtilizadores.DataSource = null;
            }
        }

        private void PesquisarArbitros(string username, string name)
        {
            IEnumerable<BD_DA_ProjetoDataSet_Arbitros.UserSetRow> queryLinq;

            if (username.Length > 0 && name.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            where arbitros.Field<string>("Username").Contains(username)
                            && arbitros.Field<string>("Name").Contains(name)
                            select arbitros;
            }

            else if (username.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            where arbitros.Field<string>("Username").Contains(username)
                            select arbitros;
            }

            else if (name.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            where arbitros.Field<string>("Name").Contains(name)
                            select arbitros;
            }

            else
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            select arbitros;
            }

            if (queryLinq.Any() == true)
            {
                DataTable queryTable = queryLinq.CopyToDataTable();

                bindingSourceArbitros.DataSource = queryTable;

                dgvPesquisaUtilizadores.DataSource = bindingSourceArbitros;
            }

            else
            {
                dgvPesquisaUtilizadores.DataSource = null;
            }
        }

        private void PesquisarArbitrosAtivos(string username, string name)
        {
            IEnumerable<BD_DA_ProjetoDataSet_Arbitros.UserSetRow> queryLinq;

            if (txtPesquisaUsername.Text.Length > 0 && txtPesquisaNomeArbitro.Text.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            join jogo in containerDados.GameSet
                            on arbitros.Id equals jogo.RefereeId
                            where arbitros.Field<string>("Username").Contains(username)
                            && arbitros.Field<string>("Name").Contains(name)
                            select arbitros;
            }

            else if (txtPesquisaUsername.Text.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            join jogo in containerDados.GameSet
                            on arbitros.Id equals jogo.RefereeId
                            where arbitros.Field<string>("Username").Contains(username)
                            select arbitros;
            }

            else if (txtPesquisaNomeArbitro.Text.Length > 0)
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            join jogo in containerDados.GameSet
                            on arbitros.Id equals jogo.RefereeId
                            where arbitros.Field<string>("Name").Contains(name)
                            select arbitros;
            }

            else
            {
                queryLinq = from arbitros in dataSetArbitros.UserSet
                            join jogo in containerDados.GameSet
                            on arbitros.Id equals jogo.RefereeId
                            select arbitros;
            }

            if (queryLinq.Any() == true)
            {
                DataTable queryTable = queryLinq.CopyToDataTable();

                bindingSourceArbitros.DataSource = queryTable;

                dgvPesquisaUtilizadores.DataSource = bindingSourceArbitros;
            }

            else
            {
                dgvPesquisaUtilizadores.DataSource = null;
            }
        }

        private void RefreshTabelaPesquisaUtilizadores()
        {
            if (radioPesquisaAdministrador.Checked == true)
            {
                bindingSourceAdminstradores.DataSource = dataSetAdministradores.UserSet;
                userSetTableAdapterAdministradores.Fill(dataSetAdministradores.UserSet);
                dgvPesquisaUtilizadores.DataSource = bindingSourceAdminstradores;
            }

            else
            {
                bindingSourceArbitros.DataSource = dataSetArbitros.UserSet;
                userSetTableAdapterArbitros.Fill(dataSetArbitros.UserSet);
                dgvPesquisaUtilizadores.DataSource = bindingSourceArbitros;
            }
        }

        private void ResetPesquisaUtilizadoresForm()
        {
            if (radioPesquisaAdministrador.Checked == true)
            {
                labPesquisaNomeEmail.Text = "Email:";
                txtPesquisaUsername.Clear();
                txtPesquisaEmailAdministrador.Clear();
                txtPesquisaEmailAdministrador.Visible = true;
                txtPesquisaNomeArbitro.Clear();
                txtPesquisaNomeArbitro.Visible = false;
                checkPesquisaArbitroAtivo.Visible = false;
            }

            else if (radioPesquisaArbitro.Checked == true)
            {
                labPesquisaNomeEmail.Text = "Nome:";
                txtPesquisaUsername.Clear();
                txtPesquisaEmailAdministrador.Clear();
                txtPesquisaEmailAdministrador.Visible = false;
                txtPesquisaNomeArbitro.Clear();
                txtPesquisaNomeArbitro.Visible = true;
                checkPesquisaArbitroAtivo.Checked = false;
                checkPesquisaArbitroAtivo.Visible = true;
            }
        }

        private void TabPesquisaUtilizadores(object sender, EventArgs e)
        {
            RefreshTabelaPesquisaUtilizadores();
        }

        #endregion

        #region GestaoCartas

        /// <summary>
        /// Ativa o formulário para preencher os dados da nova carta.
        /// Ajusta o texto do botão de ações.
        /// </summary>
        private void btnInserirCarta_Click(object sender, EventArgs e)
        {
            gbGCartasForm.Enabled = true;
            gbGCartasForm.Visible = true;
            btnAcaoCarta.Text = "Criar";
        }

        /// <summary>
        /// Ativa o formulário e carrega os valores da carta selecionada para
        /// os respetivos campos.
        /// Ajusta o texto do botão de ações
        /// </summary>
        private void btnAlterarCarta_Click(object sender, EventArgs e)
        {
            gbGCartasForm.Enabled = true;
            btnAcaoCarta.Text = "Guardar";

            idCarta = (int)dgvGCartasLista.CurrentRow.Cells[0].Value;

            txtGNomeCarta.Text = dgvGCartasLista.CurrentRow.Cells[1].Value.ToString();
            cmbFacaoCarta.SelectedItem = dgvGCartasLista.CurrentRow.Cells[2].Value.ToString();
            cmbGTipoCarta.SelectedItem = dgvGCartasLista.CurrentRow.Cells[3].Value.ToString();
            txtGCustoCarta.Text = dgvGCartasLista.CurrentRow.Cells[4].Value.ToString();
            nudGLealdadeCarta.Value = (int)dgvGCartasLista.CurrentRow.Cells[5].Value;
            txtGRegrasCarta.Text = dgvGCartasLista.CurrentRow.Cells[6].Value.ToString();
            nudGAtaqueCarta.Value = (int)dgvGCartasLista.CurrentRow.Cells[7].Value;
            nudGDefesaCarta.Value = (int)dgvGCartasLista.CurrentRow.Cells[8].Value;
        }

        /// <summary>
        /// Confirma a intenção do utilizador de eliminar a carta selecionada
        /// Caso confirme, obtém o id da carta e chama a função para remover a carta
        /// Informa o utilizador do resultado da operação
        /// </summary>
        private void btnRemoverCarta_Click(object sender, EventArgs e)
        {
            string nomeCarta = dgvGCartasLista.CurrentRow.Cells[1].Value.ToString();

            DialogResult confirm =
                MessageBox.Show("Tem a certeza que quer eliminar a carta '" + nomeCarta + "'?",
                "Atenção", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                idCarta = (int)dgvGCartasLista.CurrentRow.Cells[0].Value;

                if (RemoverCarta())
                {
                    MessageBox.Show("Carta eliminada com sucesso!", "Informação");
                }
                else
                {
                    MessageBox.Show("Erro ao eliminar a carta", "Informação");
                }

                RefreshTabelaCartas();
            }

        }

        /// <summary>
        /// Desbloqueia os botões para alterar e remover se estiver um registo selecionado
        /// </summary
        private void dgvGCartasLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGCartasLista.SelectedCells.Count > 0)
            {
                btnAlterarCarta.Enabled = true;
                btnRemoverCarta.Enabled = true;
            }
        }

        /// <summary>
        /// Bloqueia os botões para alterar e remover cartas se nenhum registo estiver selecionado
        /// </summary>
        private void dgvGCartasLista_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGCartasLista.SelectedCells.Count == 0)
            {
                btnAlterarCarta.Enabled = false;
                btnRemoverCarta.Enabled = false;
            }
        }

        /// <summary>
        /// Verifica se os dados obrigatórios do formulário estão preenchidos
        /// Verifica se a carta já existe
        /// Verifica se o utilizador tenta criar ou alterar uma carta
        /// Chama a função para realizar a operação adequada
        /// Atualiza a tabela com os dados e limpa o formulário
        /// </summary>
        private void btnAcaoCarta_Click(object sender, EventArgs e)
        {
            if (txtGNomeCarta.Text.Length == 0 || cmbFacaoCarta.SelectedIndex == -1 ||
                cmbGTipoCarta.SelectedIndex == -1 || txtGCustoCarta.Text.Length == 0 ||
                txtGRegrasCarta.Text.Length == 0)
            {
                MessageBox.Show("Tem de preencher todos os campos", "Informação");
            }
            else
            {
                // Guarda os dados da carta em variáveis para facilitar o uso
                string name = txtGNomeCarta.Text;
                string faction = cmbFacaoCarta.SelectedItem.ToString();
                string type = cmbGTipoCarta.SelectedItem.ToString();
                string cost = txtGCustoCarta.Text;
                int loyalty = (int)nudGLealdadeCarta.Value;
                string rules = txtGRegrasCarta.Text;
                int attack = (int)nudGAtaqueCarta.Value;
                int defense = (int)nudGDefesaCarta.Value;
                //-------------------------------------------


                // Verifica se o utilizador está a criar ou a alterar uma carta
                //Executa a função respetiva
                if (btnAcaoCarta.Text == "Criar")
                {
                    //Verifica se a carta já existe
                    if (VerificarCartaExiste(name))
                    {
                        MessageBox.Show("A carta '" + name + "' já existe", "Informação");
                    }
                    else
                    {

                        if (InserirCarta(name, faction, type, cost, loyalty, rules, attack, defense))
                        {
                            MessageBox.Show("Carta criada com sucesso!", "Informação");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao criar a carta", "Informação");
                        }
                    }
                }
                else if (btnAcaoCarta.Text == "Guardar")
                {
                    if (AlterarCarta(name, faction, type, cost, loyalty, rules, attack, defense))
                    {
                        MessageBox.Show("Carta alterada com sucesso!", "Informação");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar a carta", "Informação");
                    }

                }

                RefreshTabelaCartas();

                ResetFormCartas();

            }
        }

        /// <summary>
        /// Chama a função que prepara o formulário para novo uso
        /// </summary>
        private void btnCartaCancelar_Click(object sender, EventArgs e)
        {
            ResetFormCartas();
        }

        /// <summary>
        /// Limpa os dados do formulário das cartas para novo uso
        /// Volta a bloquá-lo
        /// </summary>
        private void ResetFormCartas()
        {
            txtGNomeCarta.ResetText();
            cmbFacaoCarta.SelectedIndex = -1;
            cmbGTipoCarta.SelectedIndex = -1;
            txtGCustoCarta.ResetText();
            nudGLealdadeCarta.Value = 0;
            txtGRegrasCarta.ResetText();
            nudGAtaqueCarta.Value = 0;
            nudGDefesaCarta.Value = 0;

            btnAcaoCarta.Text = "Ação";

            gbGCartasForm.Enabled = false;
            gbGCartasForm.Visible = false;
        }

        /// <summary>
        /// Atualiza a fonte de dados 
        /// Atribui a fonte de dados á DataGridView dgvGCartasLista
        /// Desloca a posição atual na DataGridViw para o último registo
        /// </summary>
        private void RefreshTabelaCartas()
        {
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Cards.CardSet);
            dgvGCartasLista.DataSource = cardSetBindingSource;

            int lastrow = dgvGCartasLista.Rows.GetLastRow(DataGridViewElementStates.Visible);
            dgvGCartasLista.CurrentCell = dgvGCartasLista[0, lastrow];

        }

        /// <summary>
        /// Recebe como parâmetro o nome de uma carta
        /// Verifica se existe na base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean VerificarCartaExiste(string nome)
        {
            Boolean result = false;

            int countResult = containerDados.CardSet.Where(card => card.Name.Equals(nome)).Count();

            if (countResult == 1)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Recebe como parâmetros os dados de uma carta
        /// Cria um objeto para guardar os dados da nova carta
        /// Tenta adicionar a nova carta à base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean InserirCarta(string name, string faction, string type, string cost,
            int loyalty, string rules, int attack, int defense)
        {
            Boolean result;

            try
            {
                Card novaCarta = new Card
                {
                    Name = name,
                    Faction = faction,
                    Type = type,
                    Cost = cost,
                    Loyalty = loyalty,
                    RuleText = rules,
                    Attack = attack,
                    Defense = defense
                };

                containerDados.CardSet.Add(novaCarta);
                containerDados.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Recebe como parametros os novos dados da carta
        /// Procura a carta na base de dados
        /// Atualiza os dados da carta
        /// Modifica e guarda alterações
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean AlterarCarta(string name, string faction, string type, string cost,
            int loyalty, string rules, int attack, int defense)
        {
            Boolean result;

            try
            {
                Card carta;

                carta = containerDados.CardSet.Find(idCarta);

                carta.Name = name;
                carta.Faction = faction;
                carta.Type = type;
                carta.Cost = cost;
                carta.Loyalty = loyalty;
                carta.RuleText = rules;
                carta.Attack = attack;
                carta.Defense = defense;

                containerDados.Entry(carta).State = System.Data.Entity.EntityState.Modified;
                containerDados.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        /// <summary>
        /// Procura na base de dados a carta com o mesmo id da carta selecionada
        /// Tenta remover a carta da base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean RemoverCarta()
        {
            Boolean result;

            try
            {
                Card carta = containerDados.CardSet.Where(c => c.Id.Equals(idCarta)).Single();

                containerDados.CardSet.Remove(carta);

                containerDados.SaveChanges();
                result = true;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Não pode eliminar uma carta que está a ser usada num baralho." + Environment.NewLine + ex.Message, "Erro");
                result = false;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Se a caixa de texto tiver algo
        ///     Cria uma query e seleciona as cartas cujo nome contenha o texto obtido
        /// Senão
        ///     Recarrega a tabela
        /// </summary>
        private void txtGCartasPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region GestaoBaralhos

        /// <summary>
        /// Ativa os botões de Gerir e Eliminar baralhos
        ///     se estiver um baralho selecionado
        /// </summary>
        private void dgvGBaralhosLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGBaralhosLista.SelectedCells.Count > 0)
            {
                btnGerirBaralho.Enabled = true;
                btnEliminarBaralho.Enabled = true;
            }
        }

        /// <summary>
        /// Desativa os botões de Gerir e Eliminar baralhos
        ///     se não estiver um baralho selecionado
        /// </summary>
        private void dgvGBaralhosLista_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGBaralhosLista.SelectedCells.Count == 0)
            {
                btnGerirBaralho.Enabled = false;
                btnEliminarBaralho.Enabled = false;
            }
        }

        /// <summary>
        /// Mostra a Groupbox com os capos para a criação de um baralho
        /// </summary>
        private void btnInserirBaralho_Click(object sender, EventArgs e)
        {
            gbGBaralhosForm.Visible = true;
        }

        /// <summary>
        /// Obtém o ID do baralho atual
        /// Limpa os dados as listviews
        /// Percorre todas as cartas existentes
        ///     Percorre os registos de cartas no baralho atual
        ///         Se o registo corresponder á carta, guarda-a na listview respetiva
        ///     Guarda a carta na listview respetiva
        /// Atualiza a label com o número de cartas no baralho
        /// </summary>
        private void btnGerirBaralho_Click(object sender, EventArgs e)
        {
            idBaralho = (int)dgvGBaralhosLista.CurrentRow.Cells[0].Value;
            int ncartas = 0;
            int qtdCartas;

            ListViewItem linhaCartasBaralho;
            ListViewItem linhaListaCartas;

            //---------------------------------
            //Limpar listviews
            lvListaCartas.Items.Clear();
            lvCartasBaralho.Items.Clear();

            //Percorrer todas as cartas
            foreach (Card carta in containerDados.CardSet)
            {
                //Recomeçar contador
                qtdCartas = 0;

                //Percorrer registos de cartas no baralho escolhido
                foreach (DeckCards registo in containerDados.DeckCardsSet.Where(dc => dc.DeckId.Equals(idBaralho)))
                {
                    //Se a carta estiver associada ao baralho, adiciona-a na respetiva listview

                    if (registo.CardId == carta.Id)
                    {
                        qtdCartas = registo.Qtd;
                        ncartas += qtdCartas;

                        //----------------------------------------
                        linhaCartasBaralho = new ListViewItem(carta.Name);
                        linhaCartasBaralho.SubItems.Add(carta.Type);
                        linhaCartasBaralho.SubItems.Add(qtdCartas.ToString());
                        lvCartasBaralho.Items.Add(linhaCartasBaralho);
                    }
                }

                //Adiciona a carta á respetiva listview
                //----------------------------------------
                linhaListaCartas = new ListViewItem(carta.Name);
                linhaListaCartas.SubItems.Add(carta.Type);
                linhaListaCartas.SubItems.Add((3 - qtdCartas).ToString());
                lvListaCartas.Items.Add(linhaListaCartas);

            }

            //Atualiza a label com o nº de cartas no baralho
            //----------------------------------

            lblNCartasNoBaralho.Text = Convert.ToString(ncartas);
            panelGestaoBaralho.Enabled = true;

        }

        /// <summary>
        /// Confirma a intenção do utilizador de eliminar o baralho selecionado
        /// Caso confirme, obtém o id do baralho e chama a função para remover o baralho
        /// Informa o utilizador do resultado da operação
        /// </summary>
        private void btnEliminarBaralho_Click(object sender, EventArgs e)
        {
            string nomeBaralho = dgvGBaralhosLista.CurrentRow.Cells[1].Value.ToString();

            DialogResult confirm =
                MessageBox.Show("Tem a certeza que quer eliminar o baralho '" + nomeBaralho + "'?",
                "Atenção", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                idBaralho = (int)dgvGBaralhosLista.CurrentRow.Cells[0].Value;

                if (RemoverBaralho())
                {
                    MessageBox.Show("Baralho eliminado com sucesso!", "Informação");
                }
                else
                {
                    MessageBox.Show("Erro ao eliminar o baralho", "Informação");
                }

                RefreshTabelaBaralhos();
            }
        }

        /// <summary>
        /// Atualiza a fonte de dados da tabela 
        /// Atribui a fonta de dados à DataGridView dgvGBaralhosLista
        /// Desloca a posição atual na DataGridView para a última linha
        /// </summary>
        private void RefreshTabelaBaralhos()
        {
            this.deckSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Decks.DeckSet);
            dgvGBaralhosLista.DataSource = deckSetBindingSource;

            int lastrow = dgvGBaralhosLista.Rows.GetLastRow(DataGridViewElementStates.Visible);
            dgvGBaralhosLista.CurrentCell = dgvGBaralhosLista[0, lastrow];
        }

        /// <summary>
        /// Limpa o formulário de criação de baralho para novo uso
        /// </summary>
        private void ResetFormBaralhos()
        {
            txtNomeBaralho.ResetText();
            gbGBaralhosForm.Visible = false;
        }

        /// <summary>
        /// Verifica se o nome do baralho está preenchido
        /// Verifica se o baralho já existe
        /// Insere o baralho na base de dados
        /// Recarrega a tabela e limpa o formulário
        /// </summary>
        private void btnCriarBaralho_Click(object sender, EventArgs e)
        {
            if (txtNomeBaralho.Text.Length == 0)
            {
                MessageBox.Show("Tem de preencher o nome do baralho", "Informação");
            }
            else
            {
                string name = txtNomeBaralho.Text;

                if (VerificarBaralhoExiste(name))
                {
                    MessageBox.Show("O baralho '" + name + "' já existe", "Informação");
                }
                else
                {
                    if (InserirBaralho(name))
                    {
                        MessageBox.Show("Baralho criado com sucesso", "Informação");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar o baralho", "Informação");
                    }

                    RefreshTabelaBaralhos();

                    ResetFormBaralhos();
                }
            }

        }

        /// <summary>
        /// Chama a função que prepara o formulário para novo uso
        /// </summary>
        private void btnCancelarNovoBaralho_Click(object sender, EventArgs e)
        {
            ResetFormBaralhos();
        }

        /// <summary>
        /// Recebe o nome do baralho como parâmetro
        /// Verifica se existe um baralho com o mesmo nome
        /// Retorna o resultado
        /// </summary>
        private Boolean VerificarBaralhoExiste(string nome)
        {
            Boolean result = false;

            int countRegisto = containerDados.DeckSet.Where(deck => deck.Name.Equals(nome)).Count();

            if (countRegisto == 1)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Recebe o nome do baralho como parâmetro
        /// Tenta criar um novo baralho na base de dados
        /// Retorna o resultado
        /// </summary>
        private Boolean InserirBaralho(string nome)
        {
            Boolean result;

            try
            {
                Deck novoDeck = new Deck
                {
                    Name = nome
                };

                containerDados.DeckSet.Add(novoDeck);
                containerDados.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Remove a associação de quaisquer cartas ao baralho
        /// Procura na base de dados o baralho com o mesmo id do baralho selecionado
        /// Tenta remover o baralho da base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean RemoverBaralho()
        {
            Boolean result;

            try
            {
                //Remover cartas associadas ao baralho 
                //(Registos de associação que tenham o id do baralho selecionado)

                List<DeckCards> cartasBaralho = containerDados.DeckCardsSet
                        .Where(dc => dc.DeckId.Equals(idBaralho)).ToList<DeckCards>();

                containerDados.DeckCardsSet.RemoveRange(cartasBaralho);

                //Remover baralho

                Deck baralho = containerDados.DeckSet.Where(d => d.Id.Equals(idBaralho)).Single();

                containerDados.DeckSet.Remove(baralho);

                containerDados.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Se a caixa de texto tiver algo
        ///     Cria uma query (Linq) e seleciona os baralhos cujo nome contenha o texto obtido
        ///     Atribui a lista de resultados á DataGridView
        /// Senão
        ///     Recarrega a tabela
        /// </summary>
        private void txtGBaralhosPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se o utilizador tiver selecionado uma carta na Lista de cartas (e o baralho tiver espaço)
        ///     Ativa o botão para adicionar a carta ao baralho
        /// Senão
        ///     Desativa-o
        /// </summary>
        private void lvListaCartas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se o utilizador tiver seleciona uma carta na lista de cartas no baralho
        ///     Ativa o botão para remover a carta do baralho
        /// Senão
        ///     Desativa-o
        /// </summary>
        private void lvCartasBaralho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Obtem os dados da carta selecionada
        /// Verifica se a carta selecionada já existe na Lista de cartas no baralho
        ///     Se sim, incrementa a quantidade
        ///     Se não, adiciona
        /// Decrementa a quantidade da carta na lista de cartas
        /// Remove carta selecionada da listview se a quantidade for zero
        /// </summary>
        private void btnAdicionarCartaBaralho_Click(object sender, EventArgs e)
        {
            ListViewItem cartaAdicionar = lvListaCartas.SelectedItems[0];
            int qtdCarta = Convert.ToInt32(cartaAdicionar.SubItems[2].Text);
            int numCartas = Convert.ToInt32(lblNCartasNoBaralho.Text);
            Boolean cartanova = true;

            lvListaCartas.SelectedItems[0].SubItems[2].Text = Convert.ToString(--qtdCarta);

            //---------------------------------------------------

            foreach (ListViewItem item in lvCartasBaralho.Items)
            {
                if (item.Text.Equals(cartaAdicionar.Text))
                {
                    item.SubItems[2].Text = Convert.ToString(3 - qtdCarta);
                    cartanova = false;
                }
            }

            if (cartanova)
            {
                ListViewItem novacarta = new ListViewItem(cartaAdicionar.Text);
                novacarta.SubItems.Add(cartaAdicionar.SubItems[1].Text);
                novacarta.SubItems.Add("1");

                lvCartasBaralho.Items.Add(novacarta);
            }

            //---------------------------------------------------

            if (qtdCarta == 0)
            {
                lvListaCartas.Items.Remove(cartaAdicionar);
            }

            //--------------------------------------------------

            lblNCartasNoBaralho.Text = Convert.ToString(++numCartas);

            if (numCartas == 45)
            {
                btnAdicionarCartaBaralho.Enabled = false;
            }

        }

        /// <summary>
        /// Obtem os dados da carta selecionada
        /// Verifica se a carta selecionada já existe na Lista de cartas
        ///     Se sim, incrementa a quantidade
        ///     Se não, adiciona
        /// Decrementa a quantidade da carta na lista de cartas no baralho
        /// Remove carta selecionada da listview se a quantidade for zero
        /// </summary>
        private void btnRemoverCartaBaralho_Click(object sender, EventArgs e)
        {
            ListViewItem cartaRemover = lvCartasBaralho.SelectedItems[0];
            int qtdCarta = Convert.ToInt32(cartaRemover.SubItems[2].Text);
            int numCartas = Convert.ToInt32(lblNCartasNoBaralho.Text);
            Boolean cartanova = true;

            lvCartasBaralho.SelectedItems[0].SubItems[2].Text = Convert.ToString(--qtdCarta);

            //---------------------------------------------------

            foreach (ListViewItem item in lvListaCartas.Items)
            {
                if (item.Text.Equals(cartaRemover.Text))
                {
                    item.SubItems[2].Text = Convert.ToString(3 - qtdCarta);
                    cartanova = false;
                }
            }

            if (cartanova)
            {
                ListViewItem novacarta = new ListViewItem(cartaRemover.Text);
                novacarta.SubItems.Add(cartaRemover.SubItems[1].Text);
                novacarta.SubItems.Add("1");

                lvListaCartas.Items.Add(novacarta);
            }

            //---------------------------------------------------

            if (qtdCarta == 0)
            {
                lvCartasBaralho.Items.Remove(cartaRemover);
            }

            //--------------------------------------------------

            lblNCartasNoBaralho.Text = Convert.ToString(--numCartas);
        }

        /// <summary>
        /// Chama a função que limpa os dados da gestão de baralhos
        /// </summary>
        private void btnCancelarAltBaralho_Click(object sender, EventArgs e)
        {
            RefreshGestaoBaralho();
        }

        /// <summary>
        /// Remova as cartas associadas ao baralho em gestão
        /// Adiciona a nova lista de cartas ao baralho em gestão
        /// </summary>
        private void btnGuardarAltBaralho_Click(object sender, EventArgs e)
        {
            Card carta;
            DeckCards cartaBaralho;
            int qtdcarta;

            //Limpar cartas antigas

            var idCartasAntigas =
                from bc in containerDados.DeckCardsSet
                where bc.DeckId == idBaralho
                select bc;

            containerDados.DeckCardsSet.RemoveRange(idCartasAntigas.ToList<DeckCards>());
            //--------------------------------

            foreach (ListViewItem item in lvCartasBaralho.Items)
            {
                qtdcarta = Convert.ToInt32(item.SubItems[2].Text);

                var search = containerDados.CardSet.Where(f => f.Name.Equals(item.Text));
                carta = search.ToList<Card>().First<Card>();

                cartaBaralho = new DeckCards();
                cartaBaralho.DeckId = idBaralho;
                cartaBaralho.CardId = carta.Id;
                cartaBaralho.Qtd = qtdcarta;

                containerDados.DeckCardsSet.Add(cartaBaralho);
            }

            containerDados.SaveChanges();

            RefreshGestaoBaralho();
        }

        /// <summary>
        /// Limpa todos os campos e prepara a área de gestão de cartas
        /// para novo uso
        /// </summary>
        private void RefreshGestaoBaralho()
        {
            lvCartasBaralho.Items.Clear();
            lvListaCartas.Items.Clear();
            lblNCartasNoBaralho.Text = "0";
            btnAdicionarCartaBaralho.Enabled = false;
            btnRemoverCartaBaralho.Enabled = false;
            panelGestaoBaralho.Enabled = false;
        }


        #endregion

        #region VerCartas

        /// <summary>
        /// Guarda os valores dos campos de pesquisa em variáveis
        /// Cria uma query (Linq) que seleciona as cartas com base nos campos de pesquisa
        /// Atribui a lista de resultados á DataGridView dgvVCartasLista
        /// </summary>
        private void pesquisaCartas(object sender, EventArgs e)
        {
            string nome = txtVNomeCarta.Text.Trim();

            string facao = "";
            if (cmbVFacaoCarta.SelectedIndex != -1)
            {
                facao = cmbVFacaoCarta.SelectedItem.ToString();
            }

            string tipo = "";
            if (cmbVTipoCarta.SelectedIndex != -1)
            {
                tipo = cmbVTipoCarta.SelectedItem.ToString();
            }

            string custo = txtVCustoCarta.Text.Trim();

            int lealdade = (int)nudVLealdadeCarta.Value;
            int ataque = (int)nudVAtaqueCarta.Value;
            int defesa = (int)nudVDefesaCarta.Value;

            //----------------------------------------

            IQueryable<Card> query = containerDados.CardSet;

            if (nome.Length > 0)
            {
                query = query.Where(card => card.Name.Contains(nome));
            }

            if (facao.Length > 0)
            {
                query = query.Where(card => card.Faction.Equals(facao));
            }

            if (tipo.Length > 0)
            {
                query = query.Where(card => card.Type.Equals(tipo));
            }

            if (custo.Length > 0)
            {
                query = query.Where(card => card.Cost.Equals(custo));
            }

            query = query.Where(card => card.Loyalty >= lealdade);
            query = query.Where(card => card.Attack >= ataque);
            query = query.Where(card => card.Defense >= defesa);

            dgvVCartasLista.DataSource = query.ToList();
        }

        /// <summary>
        /// Atribui á DataGridView dgvVCartasLista a lista de cartas original
        /// Limpa os valores dos campos de pesquisa
        /// </summary>
        private void btnVLimparCartas_Click(object sender, EventArgs e)
        {
            dgvVCartasLista.DataSource = cardSetBindingSource;

            txtVNomeCarta.ResetText();
            cmbVFacaoCarta.SelectedIndex = -1;
            cmbVTipoCarta.SelectedIndex = -1;
            txtVCustoCarta.ResetText();
            nudVLealdadeCarta.Value = 0;
            nudVAtaqueCarta.Value = 0;
            nudVDefesaCarta.Value = 0;
        }
        #endregion

        #region VerBaralhos

        /// <summary>
        /// Obtém os dados necessários dos campos de pesquisa e guarda-os em variáveis
        /// Cria uma query (Linq) que
        ///     relaciona as chaves primárias das entidades CardSet, DeckSet e DeckCardsSet
        ///     seleciona os baralho no DeckSet que correspondam aos filtros existentes
        /// Atribui a lista de resultados á DataGridView dgvVBaralhosLista
        /// </summary>
        private void pesquisaBaralhos(object sender, EventArgs e)
        {
            string nome = txtVNomeBaralho.Text.Trim();

            string cartaNome = "";

            if (cmbVCartasnoBaralho.SelectedIndex != -1)
            {
                cartaNome = cmbVCartasnoBaralho.SelectedItem.ToString();
            }

            //------------------------------------------------------

            IQueryable<Deck> query =
                from baralho in containerDados.DeckSet
                join cartabaralho in containerDados.DeckCardsSet on baralho.Id equals cartabaralho.DeckId
                join carta in containerDados.CardSet on cartabaralho.CardId equals carta.Id
                where carta.Name.Contains(cartaNome) && baralho.Name.Contains(nome)
                select baralho;

            dgvVBaralhosLista.DataSource = query.Distinct().ToList();

        }

        /// <summary>
        /// Limpa os dados da combobox com a lista de cartas
        /// Adiciona as cartas á combobox para uso futuro
        /// </summary>
        private void tbVerBaralhos_Enter(object sender, EventArgs e)
        {
            cmbVCartasnoBaralho.Items.Clear();

            foreach (Card carta in containerDados.CardSet)
            {
                cmbVCartasnoBaralho.Items.Add(carta.Name);
            }

        }

        /// <summary>
        /// Atribui á DataGridView dgvVBaralhosLista a lista de baralhos original 
        /// Limpa os campos do formulário para novo uso
        /// </summary>
        private void btnVLimparBaralhos_Click(object sender, EventArgs e)
        {
            dgvVBaralhosLista.DataSource = deckSetBindingSource;

            txtVNomeBaralho.ResetText();
            cmbVCartasnoBaralho.SelectedIndex = -1;
        }

        #endregion

        #region Parte do Cristiano (Tenta separar isto por tipo de gestão, como em cima, e comentar)


        private void btnInserirJogador_Click(object sender, EventArgs e)
        {
            //Ativa o group box dos jogadores.
            gbGJogadoresForm.Enabled = true;
            gbGJogadoresForm.Visible = true;
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
                if (nome.Length == 0 && email.Length == 0 && nickname.Length == 0 && idade == 0 && caminho.Length == 0)
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


                if (btnJogadoresAcao.Text == "Criar")
                {
                    //cria um novo.
                    //verificar se o jogador com esse nome já existe.
                    if (verificarNomeNickname(nome, email, nickname) == false)
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
                else if (btnJogadoresAcao.Text == "Guardar")
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
            foreach (Player player in containerDados.PlayerSet.OfType<Player>())
            {

                if (btnJogadoresAcao.Text.Equals("Criar"))
                {
                    if (nome.Equals(player.Name) || email.Equals(player.Email) || nickname.Equals(player.Nickname))
                    {
                        existe = true;
                        enviarMensagemRepeticaoDados(player, nome, email, nickname);
                    }
                }

                if (btnJogadoresAcao.Text.Equals("Guardar"))
                {
                    if (player.Id != idJogador)
                    {
                        if (nome.Equals(player.Name) || nickname.Equals(player.Nickname))
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

            jogador = containerDados.PlayerSet.Find(idJogador);

            jogador.Name = nome;
            jogador.Email = email;
            jogador.Nickname = nickname;
            jogador.Age = idade;
            jogador.Avatar = caminho;

            containerDados.Entry(jogador).State = EntityState.Modified;
            containerDados.SaveChanges();


        }

        private void atualizarTabelaJogadores()
        {
            //MessageBox.Show("Olá");
            //var query = from admins 
            dgvGListaJogadores.DataSource = null;
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Players.PlayerSet);
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

                containerDados.PlayerSet.Add(jogador);
                containerDados.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("O jogador não foi inserido.", "Registo de Jogadores");
            }


        }

        private void btImagem_Click(object sender, EventArgs e)
        {
            //filtra e só deixa selecionar imagens
            opfProcurarImagem.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            Image file;
            if (opfProcurarImagem.ShowDialog() == DialogResult.OK)
            {
                //caminho da imagem para guardar no ado.
                string caminho = opfProcurarImagem.FileName;
                //titulo da janela
                opfProcurarImagem.Title = "Selecione uma imagem";
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
            gbGJogadoresForm.Visible = false;

            btnAlterarJogador.Enabled = false;
            btnRemoverJogador.Enabled = false;
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
            if (dgvGListaJogadores.RowCount > 0 && dgvGListaJogadores.SelectedCells.Count > 0)
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
            if (dgvGListaJogadores.SelectedCells.Count > 0)
            {

                gbGJogadoresForm.Enabled = true;
                idJogador = (int)dgvGListaJogadores.CurrentRow.Cells[0].Value;

                foreach (Player player in containerDados.PlayerSet.OfType<Player>())
                {
                    if (player.Id == idJogador)
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

            try
            {

                foreach (Player jogador in containerDados.PlayerSet)
                {
                    if (jogador.Id == idJogador)
                    {
                        containerDados.PlayerSet.Remove(jogador);
                    }
                }
                containerDados.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
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

        }

        private void btnInserirEquipa_Click(object sender, EventArgs e)
        {
            gbGEquipasForm.Enabled = true;
            gbGEquipasForm.Visible = true;
            btnEquipaAcao.Text = "Criar";
        }

        private void btnEquipaAcao_Click(object sender, EventArgs e)
        {
            string nome = txtGNomeEquipa.Text;
            string caminho = txtGAvatarEquipa.Text;

            if (nome.Equals("") || caminho.Equals(""))
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
            foreach (Team team in containerDados.TeamSet.OfType<Team>())
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
                    if (team.Id != idEquipa)
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

            equipa = containerDados.TeamSet.Find(idEquipa);

            equipa.Name = nome;
            equipa.Avatar = caminho;

            containerDados.Entry(equipa).State = EntityState.Modified;
            containerDados.SaveChanges();
        }

        private void atualizarTabelaEquipas()
        {
            dgvGListaEquipas.DataSource = null;
            this.teamSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Teams.TeamSet);
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

                containerDados.TeamSet.Add(equipa);
                containerDados.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("A equipa não foi inserida.", "Registo de Equipas");
            }
        }

        private void btnAvatarEquipa_Click(object sender, EventArgs e)
        {
            opfProcurarImagem.Filter = "Image File (JPG,PNG,GIF)|*.JPG;*.JPG;*.PNG;*.GIF";
            Image file;
            if (opfProcurarImagem.ShowDialog() == DialogResult.OK)
            {
                string caminho = opfProcurarImagem.FileName;
                opfProcurarImagem.Title = "Selecione uma imagem";
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
            gbGEquipasForm.Visible = false;

            btnAlterarEquipa.Enabled = false;
            btnRemoverEquipa.Enabled = false;
        }

        private void btnAlterarEquipa_Click(object sender, EventArgs e)
        {
            carregarCancelarEquipas();
            gbGEquipasForm.Enabled = true;
            btnEquipaAcao.Text = "Guardar";

            Image file;
            if (dgvGListaEquipas.SelectedCells.Count > 0)
            {
                gbGEquipasForm.Enabled = true;
                idEquipa = (int)dgvGListaEquipas.CurrentRow.Cells[0].Value;

                foreach (Team team in containerDados.TeamSet.OfType<Team>())
                {
                    if (team.Id == idEquipa)
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
            if (dgvGListaEquipas.RowCount > 0 && dgvGListaEquipas.SelectedCells.Count > 0)
            {
                btnAlterarEquipa.Enabled = true;
                btnRemoverEquipa.Enabled = true;
            }
        }

        private void btnRemoverEquipa_Click(object sender, EventArgs e)
        {
            if (dgvGListaEquipas.SelectedCells.Count > 0)
            {
                idEquipa = (int)dgvGListaEquipas.CurrentRow.Cells[0].Value;
                string nome = dgvGListaEquipas.CurrentRow.Cells[1].Value.ToString();

                DialogResult confirmar = MessageBox.Show("Deseja eliminar a equipa com o nome " + nome + "?", "Eliminar dados", MessageBoxButtons.YesNo);

                if (confirmar == DialogResult.Yes)
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
                foreach (Team equipa in containerDados.TeamSet)
                {
                    if (equipa.Id == idEquipa)
                    {
                        containerDados.TeamSet.Remove(equipa);
                    }
                }
                containerDados.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao eliminar a equipa.", "Eliminar dados");
            }
        }

        private void txtGEquipasPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtGEquipasPesquisa.Text.Length > 0)
            {
                var query = from team in containerDados.TeamSet
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
            this.playerSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet_Players.PlayerSet);
            dgvGListaJogadoresPesquisa.DataSource = this.playerSetBindingSource;

            int i = dgvGListaJogadoresPesquisa.Rows.Count;

            dgvGListaJogadoresPesquisa.CurrentCell = dgvGListaJogadoresPesquisa.Rows[i - 1].Cells[0];
        }

        private void btnExportar_Click(object sender, EventArgs e)
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

            IQueryable<Player> query = containerDados.PlayerSet;

            if (nome.Length > 0)
            {
                query = query.Where(player => player.Name.Contains(nome));
            }

            if (email.Length > 0)
            {
                query = query.Where(player => player.Email.Contains(email));
            }

            if (nickname.Length > 0)
            {
                query = query.Where(player => player.Nickname.Contains(nickname));
            }
            if (idade != 0)
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
            //int nrequipas = 0;

            ListViewItem linhaJogadoresEquipa;
            ListViewItem linhaListaJogadores;

            lcListaJogadores.Items.Clear();
            lvJogadoresEquipa.Items.Clear();

            foreach (Player jogador in containerDados.PlayerSet)
            {
                nrjogadores = 0;

                foreach (TeamPlayers equipasjogadores in containerDados.TeamPlayersSet.Where(tp => tp.TeamId.Equals(idEquipa)))
                {
                    if (equipasjogadores.PlayerId == jogador.Id)
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


            foreach (Player jogador in containerDados.PlayerSet)
            {
                Boolean temEquipa = false;
                foreach (TeamPlayers equipasjogadores in containerDados.TeamPlayersSet)
                {
                    if (equipasjogadores.PlayerId == jogador.Id)
                    {
                        temEquipa = true;
                    }
                }

                if (temEquipa == false)
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

            if (nrjogadores < 2)
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

            containerDados.TeamPlayersSet.Where(tp => tp.TeamId == idEquipa)
                .ToList().ForEach(tp => containerDados.TeamPlayersSet.Remove(tp));
            containerDados.SaveChanges();

            foreach (ListViewItem item in lvJogadoresEquipa.Items)
            {
                var pesquisa = containerDados.PlayerSet.Where(p => p.Name.Equals(item.Text));
                jogador = pesquisa.ToList().First<Player>();

                equipajogadores = new TeamPlayers();
                equipajogadores.TeamId = idEquipa;
                equipajogadores.PlayerId = jogador.Id;

                containerDados.TeamPlayersSet.Add(equipajogadores);
            }

            containerDados.SaveChanges();

        }

        private void btnRetirarJogador_Click(object sender, EventArgs e)
        {
            if (lvJogadoresEquipa.SelectedItems.Count > 0)
            {
                ListViewItem jogador = lvJogadoresEquipa.SelectedItems[0];
                lvJogadoresEquipa.Items.Remove(jogador);
                lcListaJogadores.Items.Add(jogador);
            }

            int nrjogadoresequipa = lvJogadoresEquipa.Items.Count;

            if (nrjogadoresequipa == 0)
            {
                btnRetirarJogador.Enabled = false;
            }
            else
            {
                btnRetirarJogador.Enabled = true;

                if (nrjogadoresequipa < 2)
                {
                    btnGuardarJogadorEquipa.Enabled = false;
                    btnAdicionarJogador.Enabled = true;
                }
            }
        }

        private void tbVerEquipas_Enter(object sender, EventArgs e)
        {
            cbnomejogadorpesquisa.Items.Clear();


            foreach (Player jogador in containerDados.PlayerSet)
            {
                cbnomejogadorpesquisa.Items.Add(jogador.Name);
            }
        }

        private void pesquisarEquipas(object sender, EventArgs e)
        {
            string nomeequipa = tbxnomeequipapesquisa.Text;

            string nomejogador = "";

            if (cbnomejogadorpesquisa.SelectedIndex != -1)
            {
                nomejogador = cbnomejogadorpesquisa.SelectedItem.ToString();
            }


            if (!nomeequipa.Equals("") && cbnomejogadorpesquisa.SelectedIndex != -1)
            {
                //MessageBox.Show("Olá1");
                var query =
                    from equipa in containerDados.TeamSet
                    join equipajogadores in containerDados.TeamPlayersSet on equipa.Id equals equipajogadores.TeamId
                    join jogador in containerDados.PlayerSet on equipajogadores.PlayerId equals jogador.Id
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
                        from equipa in containerDados.TeamSet
                        where equipa.Name.Contains(nomeequipa)
                        select equipa;

                    dgvGListaEquipasPesquisa.DataSource = query.ToList();
                }
                if (cbnomejogadorpesquisa.SelectedIndex != -1)
                {
                    //MessageBox.Show("Olá3");
                    var query =
                    from equipa in containerDados.TeamSet
                    join equipajogadores in containerDados.TeamPlayersSet on equipa.Id equals equipajogadores.TeamId
                    join jogador in containerDados.PlayerSet on equipajogadores.PlayerId equals jogador.Id
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

        #endregion

    }
}
