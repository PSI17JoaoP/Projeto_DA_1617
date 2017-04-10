using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if(dgvGUtilizadoresLista.SelectedRows.Count == 1)
            {
                if(dgvGUtilizadoresLista.SelectedRows.OfType<Administrator>().Count() == 1)
                {
                    foreach (Administrator adminSelecionado in dgvGUtilizadoresLista.SelectedRows.OfType<Administrator>())
                    {
                        txtUsernameAdministrador.Text = adminSelecionado.Username;
                    }

                    btnAcaoAdministrador.Text = "Aplicar";
                    gbGAdministradorForm.Visible = true;
                    gbGArbitroForm.Visible = false;
                }

                else
                {
                    foreach (Referee arbitroSelecionado in dgvGUtilizadoresLista.SelectedRows.OfType<Referee>())
                    {
                        txtUsernameArbitro.Text = arbitroSelecionado.Username;
                        txtNomeArbitro.Text = arbitroSelecionado.Name;
                        txtAvatarArbitro.Text = arbitroSelecionado.Avatar;
                    }

                    btnAcaoArbitro.Text = "Aplicar";
                    gbGAdministradorForm.Visible = false;
                    gbGArbitroForm.Visible = true;
                }

                gbGUtilizadoresDados.Enabled = false;
            }
        }

        private void BotaoEliminarUtilizador(object sender, EventArgs e)
        {

        }

        private void BotaoAcaoAdministrador(object sender, EventArgs e)
        {
            string usernameForm = txtUsernameAdministrador.Text.Trim();
            string emailForm = txtEmailAdministrador.Text.Trim();

            if (btnAcaoAdministrador.Text == "Aplicar")
            {
                if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                {
                    foreach (User utilizador in containerDados.UserSet)
                    {
                        if (utilizador.Username != usernameForm)
                        {
                            foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                            {
                                if (admin.Email != emailForm)
                                {
                                    AlterarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                if (usernameForm.Length > 0 && txtPasswordAdministrador.Text.Length > 0 && emailForm.Length > 0)
                {
                    foreach (User utilizador in containerDados.UserSet)
                    {
                        if (utilizador.Username != usernameForm)
                        {
                            foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                            {
                                if (admin.Email != emailForm)
                                {
                                    AdicionarAdministrador(usernameForm, txtPasswordAdministrador.Text, emailForm);
                                }
                            }
                        }
                    }
                }
            }

            gbGUtilizadoresDados.Enabled = true;
            gbGAdministradorForm.Visible = false;
        }

        private void BotaoAcaoArbitro(object sender, EventArgs e)
        {
            string usernameForm = txtUsernameArbitro.Text.Trim();
            string nomeForm = txtNomeArbitro.Text.Trim();
            string avatarForm = txtAvatarArbitro.Text.Trim();

            if (btnAcaoArbitro.Text == "Aplicar")
            {
                if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarForm.Length > 0)
                {
                    foreach (User utilizador in containerDados.UserSet)
                    {
                        if (utilizador.Username != usernameForm)
                        {
                            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                            {
                                if (arbitro.Name != nomeForm || arbitro.Avatar != avatarForm)
                                {
                                    AlterarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarForm);
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                if (usernameForm.Length > 0 && txtPasswordArbitro.Text.Length > 0 && nomeForm.Length > 0 && avatarForm.Length > 0)
                {
                    foreach (User utilizador in containerDados.UserSet)
                    {
                        if (utilizador.Username != usernameForm)
                        {
                            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                            {
                                if (arbitro.Name != nomeForm || arbitro.Avatar != avatarForm)
                                {
                                    AdicionarArbitro(usernameForm, txtPasswordArbitro.Text, nomeForm, avatarForm);
                                }
                            }
                        }
                    }
                }
            }

            gbGUtilizadoresDados.Enabled = true;
            gbGArbitroForm.Visible = false;
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
        }

        private void AdicionarAdministrador(string nomeAdministrador, string passAdministrador, string emailAdministrador)
        {
            Administrator novoAdministrador = new Administrator
            {
                Username = nomeAdministrador,
                Password = HashPassword(passAdministrador),
                Email = emailAdministrador
            };

            containerDados.UserSet.Add(novoAdministrador);
            containerDados.SaveChanges();
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
            foreach (Referee arbitroSelecionado in dgvGUtilizadoresLista.SelectedRows.OfType<Referee>())
            {
                foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                {
                    if (arbitroSelecionado.Id == arbitro.Id)
                    {
                        arbitro.Username = usernameArbitro;
                        arbitro.Password = HashPassword(passArbitro);
                        arbitro.Name = nomeArbitro;
                        arbitro.Avatar = avatarPathArbitro;
                    }
                }
            }

            containerDados.SaveChanges();
        }

        private void AlterarAdministrador(string nomeAdministrador, string passAdministrador, string emailAdministrador)
        {
            foreach (Administrator adminSelecionado in dgvGUtilizadoresLista.SelectedRows.OfType<Administrator>())
            {
                foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
                {
                    if (adminSelecionado.Id == admin.Id)
                    {
                        admin.Username = nomeAdministrador;
                        admin.Password = HashPassword(passAdministrador);
                        admin.Email = emailAdministrador;
                    }
                }
            }

            containerDados.SaveChanges();
        }
    }
}
