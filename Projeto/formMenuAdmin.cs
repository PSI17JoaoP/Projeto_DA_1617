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

        /// <summary>
        /// Variáveis usada para guardar o id do objeto selecionado para alterar/remover
        /// </summary>
        private int idCarta;
        private int idBaralho;


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
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet1.DeckSet' table. You can move, or remove it, as needed.
            this.deckSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet1.DeckSet);
            // TODO: This line of code loads data into the 'bD_DA_ProjetoDataSet.CardSet' table. You can move, or remove it, as needed.
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.CardSet);

        }


        /// <summary>
        /// Ativa o formulário para preencher os dados da nova carta.
        /// Ajusta o texto do botão de ações.
        /// </summary>
        private void btnInserirCarta_Click(object sender, EventArgs e)
        {
            gbGCartasForm.Enabled = true;
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
        /// Realiza a operação adequada
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
        /// Recebe como parâmetro o nome de uma carta
        /// Verifica se existe na base de dados
        /// Retorna o resultado da operação
        /// </summary>
        private Boolean VerificarCartaExiste(string nome)
        {
            Boolean result = false;

            foreach (Card carta in container.CardSet)
            {
                if (carta.Name.Equals(nome))
                {
                    result = true;
                }
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

        /// <summary>
        /// Recebe como parãmetros os novos dados da carta
        /// Procura a carta na base de dados
        /// Atualiza os dados
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

                carta = container.CardSet.Find(idCarta);

                carta.Name = name;
                carta.Faction = faction;
                carta.Type = type;
                carta.Cost = cost;
                carta.Loyalty = loyalty;
                carta.RuleText = rules;
                carta.Attack = attack;
                carta.Defense = defense;

                container.Entry(carta).State = System.Data.Entity.EntityState.Modified;
                container.SaveChanges();

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
                foreach (Card carta in container.CardSet)
                {
                    if (carta.Id == idCarta)
                    {
                        container.CardSet.Remove(carta);
                    }
                }

                container.SaveChanges();
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
        ///     Cria uma query e procura cartas cujo nome contenha o que foi escrito
        /// Senão
        ///     recarrega a tabela
        /// </summary>
        private void txtGCartasPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtGCartasPesquisa.Text.Length > 0)
            {
                
                var query =
                    from cards in container.CardSet
                    where cards.Name.Contains(txtGCartasPesquisa.Text)
                    select cards;

                dgvGCartasLista.DataSource = query.ToList();
            }
            else
            {
                RefreshTabelaCartas();
            }
        }


        private void dgvGBaralhosLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGBaralhosLista.SelectedCells.Count > 0)
            {
                btnGerirBaralho.Enabled = true;
                btnEliminarBaralho.Enabled = true;
            }
        }

        private void dgvGBaralhosLista_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGBaralhosLista.SelectedCells.Count == 0)
            {
                btnGerirBaralho.Enabled = false;
                btnEliminarBaralho.Enabled = false;
            }
        }

        private void btnInserirBaralho_Click(object sender, EventArgs e)
        {
            gbGBaralhosForm.Visible = true;
        }

        private void btnGerirBaralho_Click(object sender, EventArgs e)
        {
            idBaralho = (int)dgvGBaralhosLista.CurrentRow.Cells[0].Value;
            int ncartas = 0;
            Boolean nova = true;

            ListViewItem linhaCarta;

            //---------------------------------
            //Preencher Lista de cartas
            lvListaCartas.Items.Clear();

            foreach (Card carta in container.CardSet)
            {
                linhaCarta = new ListViewItem(carta.Name);
                linhaCarta.SubItems.Add(carta.Type);
                linhaCarta.SubItems.Add("3");
                lvListaCartas.Items.Add(linhaCarta);
            }

            //----------------------------------
            //Preencher cartas no baralho
            lvCartasBaralho.Items.Clear();

            Deck baralhoGerir = container.DeckSet.Find(idBaralho);

            foreach (Card carta in baralhoGerir.Cards)
            {
                foreach (ListViewItem item in lvCartasBaralho.Items)
                {
                    if (item.Text.Equals(carta.Name))
                    {
                        item.SubItems[2].Text = Convert.ToString(Convert.ToInt32(item.SubItems[2].Text) + 1);
                        nova = false;
                    }
                }
                if (nova)
                {
                    linhaCarta = new ListViewItem(carta.Name);
                    linhaCarta.SubItems.Add(carta.Type);
                    linhaCarta.SubItems.Add("1");
                    lvCartasBaralho.Items.Add(linhaCarta);
                }

                ncartas++;
            }

            //----------------------------------

            lblNCartasNoBaralho.Text = Convert.ToString(ncartas);
            panelGestaoBaralho.Enabled = true;
            
        }

        /// <summary>
        /// Confirma a intenção do utilizador de eliminar a carta selecionada
        /// Caso confirme, obtém o id da carta e chama a função para remover a carta
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
        /// Atualiza a fonte de dados da tabela e volta a carregá-la
        /// </summary>
        private void RefreshTabelaBaralhos()
        {
            dgvGBaralhosLista.DataSource = null;
            this.deckSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet1.DeckSet);
            dgvGBaralhosLista.DataSource = this.deckSetBindingSource;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            foreach (Deck baralho in container.DeckSet)
            {
                if (baralho.Name.Equals(nome))
                {
                    result = true;
                }
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
                
                container.DeckSet.Add(novoDeck);
                container.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Procura na base de dados o baralho com o mesmo id do baralho selecionado
        /// Tenta remover o baralho da base de dados
        /// Retorna o resultado da operação
        /// </summary>
        /// <returns></returns>
        private Boolean RemoverBaralho()
        {
            Boolean result;

            try
            {
                foreach (Deck baralho in container.DeckSet)
                {
                    if (baralho.Id == idBaralho)
                    {
                        container.DeckSet.Remove(baralho);
                    }
                }

                container.SaveChanges();
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
        ///     Cria uma query e procura baralhos cujo nome contenha o que foi escrito
        /// Senão
        ///     recarrega a tabela
        /// </summary>
        private void txtGBaralhosPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtGBaralhosPesquisa.Text.Length > 0)
            {

                var query =
                    from decks in container.DeckSet
                    where decks.Name.Contains(txtGBaralhosPesquisa.Text)
                    select decks;

                dgvGBaralhosLista.DataSource = query.ToList();
            }
            else
            {
                RefreshTabelaBaralhos();
            }
        }

        private void lvListaCartas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListaCartas.SelectedItems.Count > 0 && Convert.ToInt32(lblNCartasNoBaralho.Text) < 45)
            {
                btnAdicionarCartaBaralho.Enabled = true;
            }
            else
            {
                btnAdicionarCartaBaralho.Enabled = false;
            }
        }

        private void lvCartasBaralho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCartasBaralho.SelectedItems.Count > 0)
            {
                btnRemoverCartaBaralho.Enabled = true;
            }
            else
            {
                btnRemoverCartaBaralho.Enabled = false;
            }
        }

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

        private void btnCancelarAltBaralho_Click(object sender, EventArgs e)
        {
            RefreshGestaoBaralho();
        }

        private void btnGuardarAltBaralho_Click(object sender, EventArgs e)
        {
            Deck baralhoatual = container.DeckSet.Find(idBaralho);
            Card carta;
            int qtdcarta;
            
            baralhoatual.Cards.Clear();

            foreach (ListViewItem item in lvCartasBaralho.Items)
            {
                qtdcarta = Convert.ToInt32(item.SubItems[2].Text);

                var search = container.CardSet.Where(f => f.Name.Equals(item.Text));
                carta = search.ToList<Card>().First<Card>();

                baralhoatual.Cards.Add(carta);
                
            }

            container.SaveChanges();

            RefreshGestaoBaralho();
        }

        private void RefreshGestaoBaralho()
        {
            lvCartasBaralho.Items.Clear();
            lvListaCartas.Items.Clear();
            lblNCartasNoBaralho.Text = "0";
            btnAdicionarCartaBaralho.Enabled = false;
            btnRemoverCartaBaralho.Enabled = false;
            panelGestaoBaralho.Enabled = false;
        }
    }
}
