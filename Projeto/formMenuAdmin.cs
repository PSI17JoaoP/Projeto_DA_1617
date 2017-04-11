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

        private int idArbitro;

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

        private void BotaoCancelarArbitro(object sender, EventArgs e)
        {
            gbGArbitroForm.Visible = false;
            gbGUtilizadoresDados.Enabled = true;
        }

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

        private void AlterarAdministrador(string usernameAdministrador, string emailAdministrador)
        {
            Administrator admin = (Administrator)containerDados.UserSet.Find(idAdministrador);

            admin.Username = usernameAdministrador;
            admin.Email = emailAdministrador;

            containerDados.Entry(admin).State = EntityState.Modified;

            containerDados.SaveChanges();
            RefreshTabelaUtilizadores();
        }

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

        private void RefreshTabelaUtilizadores()
        {
            dgvGUtilizadoresLista.DataSource = null;
            userSetTableAdapter.Fill(bD_DA_ProjetoDataSet.UserSet);
            dgvGUtilizadoresLista.DataSource = userSetBindingSource;
        }

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
