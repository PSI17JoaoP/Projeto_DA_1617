using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
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
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet.UserSet' table. You can move, or remove it, as needed.
            userSetTableAdapter.Fill(bD_DA_ProjetoDataSet.UserSet);
            radioAdmins.Checked = true;
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
        /// Verifica qual é o tipo de uilizador selecionado, prepara e mostra o formulário para a inserção de novos dados.
        /// </summary>
        private void BotaoInserirUtilizador(object sender, EventArgs e)
        {
            if(radioAdmins.Checked == true)
            {
                txtUsernameAdministrador.Clear();
                txtPasswordAdministrador.Clear();
                txtEmailAdministrador.Clear();

                btnAcaoAdministrador.Text = "Adicionar";
                gbGAdministradorForm.Visible = true;
                gbGArbitroForm.Visible = false;
            }

            else
            {
                txtUsernameArbitro.Clear();
                txtPasswordArbitro.Clear();
                txtNomeArbitro.Clear();
                txtAvatarArbitro.Clear();

                btnAcaoArbitro.Text = "Adicionar";
                gbGAdministradorForm.Visible = false;
                gbGArbitroForm.Visible = true;
            }

            gbGUtilizadoresDados.Enabled = false;
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

                foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                {
                    if (admin.Id == idAdministrador)
                    {
                        txtUsernameAdministrador.Text = admin.Username;
                        txtEmailAdministrador.Text = admin.Email;
                    }
                }

                txtPasswordAdministrador.Clear();
                btnAcaoAdministrador.Text = "Aplicar";
                gbGAdministradorForm.Visible = true;
                gbGArbitroForm.Visible = false;
            }

            else if(VerificarTipoReferee(dgvGUtilizadoresLista.CurrentRow))
            {
                idArbitro = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                {
                    if (arbitro.Id == idArbitro)
                    {
                        txtUsernameArbitro.Text = arbitro.Username;
                        txtNomeArbitro.Text = arbitro.Name;
                        txtAvatarArbitro.Text = arbitro.Avatar;
                    }
                }

                txtPasswordArbitro.Clear();
                btnAcaoArbitro.Text = "Aplicar";
                gbGAdministradorForm.Visible = false;
                gbGArbitroForm.Visible = true;
            }

            gbGUtilizadoresDados.Enabled = false;
        }

        /// <summary>
        /// Evento do botão "Eliminar" da tab de Utilizadores.
        /// Mostra uma mensagem de confirmação a perguntar se deseja remover o utilizador. Se sim, verifica qual o tipo de utilizador selecionado e remove-o.
        /// </summary>
        private void BotaoEliminarUtilizador(object sender, EventArgs e)
        {
            DialogResult confirmacaoEliminar = MessageBox.Show("Tem a certeza que quer eliminar o utilizador '" + dgvGUtilizadoresLista.CurrentRow.Cells[1].Value.ToString() + "'?","Atenção", MessageBoxButtons.YesNo);

            if (confirmacaoEliminar == DialogResult.Yes)
            {
                if (VerificarTipoAdministrator(dgvGUtilizadoresLista.CurrentRow))
                {
                    idAdministrador = (int)dgvGUtilizadoresLista.CurrentRow.Cells[0].Value;

                    RemoverAdministrador();
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
                DialogResult confirmacaoAlterar = MessageBox.Show("Tem a certeza que quer alterar o administrador '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo);

                if (confirmacaoAlterar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarAlteracoesAdministrador(usernameForm, emailForm))
                            {
                                AlterarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                gbGUtilizadoresDados.Enabled = true;
                                gbGAdministradorForm.Visible = false;
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
                                gbGUtilizadoresDados.Enabled = true;
                                gbGAdministradorForm.Visible = false;
                            }
                        }
                    }
                }
            }

            else if (btnAcaoAdministrador.Text == "Adicionar")
            {
                DialogResult confirmacaoAdicionar = MessageBox.Show("Tem a certeza que quer adicionar o administrador '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo);

                if (confirmacaoAdicionar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarDadosAdmnistrador(usernameForm, emailForm))
                            {
                                AdicionarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                gbGUtilizadoresDados.Enabled = true;
                                gbGAdministradorForm.Visible = false;
                            }
                        }

                        else
                        {
                            AdicionarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                            gbGUtilizadoresDados.Enabled = true;
                            gbGAdministradorForm.Visible = false;
                        }
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
            string avatarForm = txtAvatarArbitro.Text.Trim();

            if (btnAcaoArbitro.Text == "Aplicar")
            {
                DialogResult confirmacaoAlterar = MessageBox.Show("Tem a certeza que quer alterar o arbitro '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo);

                if (confirmacaoAlterar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarAlteracoesArbitro(usernameForm, nomeForm, avatarForm))
                            {
                                AlterarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarForm);
                                gbGUtilizadoresDados.Enabled = true;
                                gbGArbitroForm.Visible = false;
                            }
                        }
                    }

                    else if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length == 0 && nomeForm.Length > 0 && avatarForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarAlteracoesArbitro(usernameForm, nomeForm, avatarForm))
                            {
                                AlterarArbitro(usernameForm, nomeForm, avatarForm);
                                gbGUtilizadoresDados.Enabled = true;
                                gbGArbitroForm.Visible = false;
                            }
                        }
                    }
                }
            }

            else if (btnAcaoArbitro.Text == "Adicionar")
            {
                DialogResult confirmacaoAdicionar = MessageBox.Show("Tem a certeza que quer adicionar o arbitro '" + usernameForm + "'?", "Atenção", MessageBoxButtons.YesNo);

                if (confirmacaoAdicionar == DialogResult.Yes)
                {
                    if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarForm.Length > 0)
                    {
                        if (containerDados.UserSet.Count() > 0)
                        {
                            if (VerificarDadosArbitro(usernameForm, nomeForm, avatarForm))
                            {
                                AdicionarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarForm);
                                gbGUtilizadoresDados.Enabled = true;
                                gbGArbitroForm.Visible = false;
                            }
                        }

                        else
                        {
                            AdicionarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarForm);
                            gbGUtilizadoresDados.Enabled = true;
                            gbGArbitroForm.Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Evento do botão "Cancelar" no formulário de preenchimento do Arbitro.
        /// Esconde o formulário.
        /// </summary>
        private void BotaoCancelarArbitro(object sender, EventArgs e)
        {
            gbGArbitroForm.Visible = false;
            gbGUtilizadoresDados.Enabled = true;
        }

        /// <summary>
        /// Evento do botão "Cancelar" no formulário de preenchimento do Administrador.
        /// Esconde o formulário.
        /// </summary>
        private void BotaoCancelarAdministrador(object sender, EventArgs e)
        {
            gbGAdministradorForm.Visible = false;
            gbGUtilizadoresDados.Enabled = true;
        }

        private void RadioFiltrarAdministradores(object sender, EventArgs e)
        {
            /*if(radioAdmins.Checked == true)
            {
                var queryLinq = from admins in containerDados.UserSet.OfType<Administrator>() where admins.Username.Contains(txtGUtilizadoresPesquisa.Text) select admins;

                dgvGUtilizadoresLista.DataSource = queryLinq.ToList();
            }

            else
            {
                var queryLinq = from arbitros in containerDados.UserSet.OfType<Referee>() where arbitros.Username.Contains(txtGUtilizadoresPesquisa.Text) select arbitros;

                dgvGUtilizadoresLista.DataSource = queryLinq.ToList();
            }*/
        }

        private void RadioFiltrarArbitros(object sender, EventArgs e)
        {
            /*if (radioArbitros.Checked == true)
            {
                var queryLinq = from arbitros in containerDados.UserSet.OfType<Referee>() where arbitros.Username.Contains(txtGUtilizadoresPesquisa.Text) select arbitros;

                dgvGUtilizadoresLista.DataSource = queryLinq.ToList();
            }

            else
            {
                var queryLinq = from admins in containerDados.UserSet.OfType<Administrator>() where admins.Username.Contains(txtGUtilizadoresPesquisa.Text) select admins;

                dgvGUtilizadoresLista.DataSource = queryLinq.ToList();
            }*/
        }

        /// <summary>
        /// Evento de pesquisar utilizadores, quando o utilizador insere dados na Textbox de pesquisar.
        /// </summary>
        private void PesquisarUtilizador(object sender, EventArgs e)
        {
            if (txtGUtilizadoresPesquisa.Text.Length > 0)
            {
                var queryLinq = from users in containerDados.UserSet where users.Username.Contains(txtGUtilizadoresPesquisa.Text) select users;

                dgvGUtilizadoresLista.DataSource = queryLinq.ToList();
            }

            else
            {
                RefreshTabelaUtilizadores();
            }
        }

        /// <summary>
        /// Método de inserção de um arbitro.
        /// Cria uma instancia da classe Referee com os dados enviados por parêmetro e insere a instância no DataSet "UserSet".
        /// No final, faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="passArbitro">Password do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AdicionarArbitro(string usernameArbitro, string passArbitro, string nomeArbitro, string avatarPathArbitro)
        {
            Referee novoArbitro = new Referee
            {
                Username = usernameArbitro,
                Password = HashPassword(passArbitro),
                Name = nomeArbitro,
                Avatar = avatarPathArbitro
            };

            containerDados.UserSet.Add(novoArbitro);
            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
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
        /// No final, guarda as alterações na base de dados e faz refresh da tabela através do método RefreshTabelaUtilizadores.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="passArbitro">Password do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AlterarArbitro(string usernameArbitro, string passArbitro, string nomeArbitro, string avatarPathArbitro)
        {
            Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

            arbitro.Username = usernameArbitro;
            arbitro.Password = HashPassword(passArbitro);
            arbitro.Name = nomeArbitro;
            arbitro.Avatar = avatarPathArbitro;

            containerDados.Entry(arbitro).State = EntityState.Modified;

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

        /// <summary>
        /// Overload no método AlterarArbitro, sem a password para o caso do utilizador querer manter a password existente.
        /// </summary>
        /// <param name="usernameArbitro">Username do Arbitro</param>
        /// <param name="nomeArbitro">Nome do Arbitro</param>
        /// <param name="avatarPathArbitro">Avatar do Arbitro</param>
        private void AlterarArbitro(string usernameArbitro, string nomeArbitro, string avatarPathArbitro)
        {
            Referee arbitro = (Referee)containerDados.UserSet.Find(idArbitro);

            arbitro.Username = usernameArbitro;
            arbitro.Name = nomeArbitro;
            arbitro.Avatar = avatarPathArbitro;

            containerDados.Entry(arbitro).State = EntityState.Modified;

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
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
            Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

            admin.Username = usernameAdministrador;
            admin.Password = HashPassword(passAdministrador);
            admin.Email = emailAdministrador;

            containerDados.Entry(admin).State = EntityState.Modified;

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

        /// <summary>
        /// Overload no método AlterarAdministrador, sem a password para o caso do utilizador querer manter a password existente.
        /// </summary>
        /// <param name="usernameAdministrador">Username do Admnistrador</param>
        /// <param name="emailAdministrador">Email do Administrador</param>
        private void AlterarAdministrador(string usernameAdministrador, string emailAdministrador)
        {
            Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

            admin.Username = usernameAdministrador;
            admin.Email = emailAdministrador;

            containerDados.Entry(admin).State = EntityState.Modified;

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

        /// <summary>
        /// Método de remoção de um administrador.
        /// Remove um administrador do Data Set "UserSet".
        /// De seguida, guarda as modificações do UserSet na base de dados e faz refresh à tabela.
        /// </summary>
        private void RemoverAdministrador()
        {
            foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
            {
                if(admin.Id == idAdministrador)
                {
                    containerDados.UserSet.Remove(admin);
                }
            }

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

        /// <summary>
        /// Método de remoção de um arbitro.
        /// Remove um arbitro do Data Set "UserSet".
        /// De seguida, guarda as modificações do UserSet na base de dados e faz refresh à tabela.
        /// </summary>
        private void RemoverArbitro()
        {
            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
            {
                if (arbitro.Id == idArbitro)
                {
                    containerDados.UserSet.Remove(arbitro);
                }
            }

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

        /// <summary>
        /// Método para fazer refresh à DataGridView (Tabela) na tab dos Utilizadores.
        /// </summary>
        private void RefreshTabelaUtilizadores()
        {
            dgvGUtilizadoresLista.DataSource = null;
            userSetTableAdapter.Fill(bD_DA_ProjetoDataSet.UserSet);
            dgvGUtilizadoresLista.DataSource = userSetBindingSource;
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
        /// De seguida, verifica se o nome e avatar inserido é igual ao nome e avatar de cada arbitro.
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
                        if (arbitro.Name == nomeArbitro && arbitro.Avatar == avatarPathArbitro)
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
        /// De seguida, verifica se o nome ou o avatar é igual ao nome ou o avatar de cada arbitro, exceto o arbitro a ser alterado.
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
                        if ((arbitro.Name == nomeArbitro || arbitro.Avatar == avatarPathArbitro) && arbitro.Id != idArbitro)
                        {
                            aplicaAlteracoes = false;
                        }
                    }
                }
            }

            return aplicaAlteracoes;
        }
    }
}
