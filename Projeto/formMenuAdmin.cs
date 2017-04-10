using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            
            //Iniciar o contentor
            container = new DiagramaArcmageContainer();
        }

        /// <summary>
        /// Variável usada para interagir com a base de dados
        /// </summary>
        private DiagramaArcmageContainer container;

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

        private void formMenuAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet.CardSet' table. You can move, or remove it, as needed.
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.CardSet);

        }


        /// <summary>
        /// Ativa o formulário para preencher os dados da nova carta.
        /// Ajusta o texto do botao de ações.
        /// </summary>
        private void btnInserirCarta_Click(object sender, EventArgs e)
        {
            gbGCartasForm.Enabled = true;
            btnAcaoCarta.Text = "Criar";
        }

        private void btnAlterarCarta_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoverCarta_Click(object sender, EventArgs e)
        {

        }

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
                Int32 loyalty = (int)nudGLealdadeCarta.Value;
                string rules = txtGRegrasCarta.Text;
                Int32 attack = (int)nudGAtaqueCarta.Value;
                Int32 defense = (int)nudGDefesaCarta.Value;
                //-------------------------------------------


                // Verifica se o utilizador está a criar ou a alterar uma carta
                if (btnAcaoCarta.Text == "Criar")
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

                RefreshTabelaCartas();

                ResetFormCartas();
            }
        }

        private void btnCartaCancelar_Click(object sender, EventArgs e)
        {
            ResetFormCartas();
        }

        /// <summary>
        /// Limpa os dados do formulário das cartas para novo uso
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
        }

        /// <summary>
        /// Atualiza a fonte de dados da tabela e volta a carregá-la
        /// </summary>
        private void RefreshTabelaCartas()
        {
            dgvGCartasLista.DataSource = null;
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.CardSet);
            dgvGCartasLista.DataSource = this.cardSetBindingSource;
        }

        /// <summary>
        /// Recebe como parâmetros os dados de uma carta
        /// Cria um objeto para guardar os dados da nova carta
        /// Tenta adicionar a nova carta à base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean InserirCarta(string name, string faction, string type, string cost, 
            Int32 loyalty, string rules, Int32 attack, Int32 defense)
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

                container.CardSet.Add(novaCarta);
                container.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

     
    }
}
