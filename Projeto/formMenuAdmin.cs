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

                }
            }

            else
            {
                if (txtUsernameArbitro.Text.Trim().Length > 0 && txtPasswordArbitro.Text.Trim().Length > 0 && txtNomeArbitro.Text.Trim().Length > 0 && txtAvatarArbitro.Text.Trim().Length > 0)
                {
                    foreach (User utilizador in containerDados.UserSet)
                    {
                        if(utilizador.Username != txtUsernameArbitro.Text.Trim())
                        {
                            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
                            {
                                if(arbitro.Name != txtNomeArbitro.Text.Trim() || arbitro.Avatar != txtAvatarArbitro.Text.Trim())
                                {
                                    AdicionarArbitro(txtUsernameArbitro.Text, txtPasswordArbitro.Text, txtNomeArbitro.Text, txtAvatarArbitro.Text);
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

        private void AdicionarArbitro(string usernameUtilizador, string passUtilizador, string nomeUtilizador, string avatarPathUtilizador)
        {
            Referee novoArbitro = new Referee
            {
                //Id = containerDados.UserSet.Local.Count() + 1,
                Username = usernameUtilizador,
                Password = HashPassword(passUtilizador),
                Name = nomeUtilizador,
                Avatar = avatarPathUtilizador
            };

            containerDados.UserSet.Add(novoArbitro);
            containerDados.SaveChanges();
            RefreshGridArbitros();
        }

        private void AdicionarAdministrador(string nomeUtilizador, string passUtilizador, string emailUtilizador)
        {
            Administrator novoAdministrador = new Administrator
            {
                //Id = containerDados.UserSet.Local.Count() + 1,
                Username = nomeUtilizador,
                Password = HashPassword(passUtilizador),
                Email = emailUtilizador                            
            };

            containerDados.UserSet.Add(novoAdministrador);
            containerDados.SaveChanges();
            RefreshGridAdministradores();
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

        private void RefreshGridAdministradores()
        {
            foreach(Administrator admin in containerDados.UserSet.OfType<Administrator>())
            {
                dgvGUtilizadoresLista.Rows.Add(admin.Id, admin.Username, admin.Email);
            }

            dgvGUtilizadoresLista.Update();
            dgvGUtilizadoresLista.Refresh();
        }

        private void RefreshGridArbitros()
        {
            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
            {
                dgvGUtilizadoresLista.Rows.Add(arbitro.Id, arbitro.Username, arbitro.Name);
            }

            dgvGUtilizadoresLista.Update();
            dgvGUtilizadoresLista.Refresh();
        }
    }
}
