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

        /// <summary>
        /// Variavel privada que guarda o id do utilizador autenticado.
        /// </summary>
        private int idUtilizador;

        public formLogin()
        {
            InitializeComponent();

            containerDados = new DiagramaArcmageContainer();

            containerDados.Database.Connection.Open();
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento do botão Sair. Fecha a aplicação.
        /// </summary>
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

                if(AutenticarUser(usernameForm, passwordForm))
                {                
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

                else
                {
                    MessageBox.Show("O utilizador que introduziu não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Preencha todos os campos para efetuar login.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método para efetuar a autenticação do utilizador introduzido.
        /// Verifica se o username e a hash da password do utilizador inserido é igual ao username e a hash da password de um utilizador.
        /// Se for igual, a variavel Boolean "userAuteticado" é igual a true.
        /// No final, retorna a variavel anterior.
        /// </summary>
        /// <param name="username">Username do utilizador inserido</param>
        /// <param name="hashPassword">Hash da password do utlizador inserido</param>
        /// <returns>Variável Boolean "userAuteticado"</returns>
        private bool AutenticarUser(string username, string hashPassword)
        {
            bool userAuteticado = false;

            foreach (User utilizador in containerDados.UserSet)
            {
                if (username == utilizador.Username && hashPassword == utilizador.Password)
                {
                    idUtilizador = utilizador.Id;

                    userAuteticado = true;
                }
            }

            return userAuteticado;
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
