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
    }
}
