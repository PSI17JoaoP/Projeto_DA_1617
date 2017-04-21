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
    public partial class formLogin : Form
    {
        public DiagramaArcmageContainer containerDados;

        public formLogin()
        {
            InitializeComponent();

            containerDados = new DiagramaArcmageContainer();
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BotaoSairAplicacao(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento do botão Login. Executa o seguinte código para autenticar o utilizador com os dados na base de dados.
        /// </summary>
        private void BotaoLoginUtilizador(object sender, EventArgs e)
        {
            if (txtLoginUser.Text.Length > 0 && txtLoginPass.Text.Length > 0)
            {
                string usernameForm = txtLoginUser.Text;

                string passwordForm = HashPassword(txtLoginPass.Text);

                foreach(User utilizador in containerDados.UserSet)
                {
                    if(usernameForm == utilizador.Username && passwordForm == utilizador.Password)
                    {
                        int idUtilizador = utilizador.Id;

                        if (VerificarTipoAdministrator(idUtilizador))
                        {
                            formMenuAdmin menuAdmin = new formMenuAdmin();
                            menuAdmin.Show();
                            Hide();
                        }

                        else if(VerificarTipoReferee(idUtilizador))
                        {
                            formMenuArbitro menuArbitro = new formMenuArbitro();
                            menuArbitro.Show();
                            Hide();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método de encriptação da password de um utilizador.
        /// Encripta a password em hash de SHA1 e devolve a hash da password.
        /// </summary>
        /// <param name="password">Password do utilizador</param>
        /// <returns>Hash da Password</returns>
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
        /// Método para verificar se o utilizador é do tipo Administrator.
        /// Verifica se o id do utilizador é igual ao id de um administrador.
        /// Se for igual, a variavel Boolean "isTipoAdministrator" é igual a true.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="idUtilizador">Id do Utilizador</param>
        /// <returns>Variavel Boolean "isTipoAdministrator"</returns>
        private bool VerificarTipoAdministrator(int idUtilizador)
        {
            bool isTipoAdministrator = false;

            foreach (Administrator admin in containerDados.UserSet.OfType<Administrator>())
            {
                if (admin.Id == idUtilizador)
                {
                    isTipoAdministrator = true;
                }
            }

            return isTipoAdministrator;
        }

        /// <summary>
        /// Método para verificar se o utilizador é do tipo Referee.
        /// Verifica se o id do utilizador é igual ao id de um arbitro.
        /// Se for igual, a variavel Boolean "isTipoArbitro" é igual a true.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="idUtilizador">Id do Utilizador</param>
        /// <returns>Variavel Boolean "isTipoArbitro"</returns>
        private bool VerificarTipoReferee(int idUtilizador)
        {
            bool isTipoArbitro = false;

            foreach (Referee arbitro in containerDados.UserSet.OfType<Referee>())
            {
                if (arbitro.Id == idUtilizador)
                {
                    isTipoArbitro = true;
                }
            }

            return isTipoArbitro;
        }
    }
}
