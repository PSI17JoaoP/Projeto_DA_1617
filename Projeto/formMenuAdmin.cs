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
        /// Variável usada para guardar o id da carta selecionada para alterar/remover
        /// </summary>
        private int idCarta;
        /// <summary>
        /// Variável usada para guardar o id do baralho selecionado para alterar/remover
        /// </summary>
        private int idBaralho;

        /// <summary>
        /// Ao fechar o menu do administrador
        /// O menu de login volta a ser mostrado
        /// </summary>
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

        #region GestaoCartas

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
        }

        /// <summary>
        /// Atualiza a fonte de dados 
        /// Atribui a fonte de dados á DataGridView dgvGCartasLista
        /// Desloca a posição atual na DataGridViw para o último registo
        /// </summary>
        private void RefreshTabelaCartas()
        {
            this.cardSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet.CardSet);
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

            int countResult = container.CardSet.Where(card => card.Name.Equals(nome)).Count();

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
                Card carta = container.CardSet.Where(c => c.Id.Equals(idCarta)).Single();

                container.CardSet.Remove(carta);

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
        ///     Cria uma query e seleciona as cartas cujo nome contenha o texto obtido
        /// Senão
        ///     Recarrega a tabela
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
            foreach (Card carta in container.CardSet)
            {
                //Recomeçar contador
                qtdCartas = 0;

                //Percorrer registos de cartas no baralho escolhido
                foreach (DeckCards registo in container.DeckCardsSet.Where(dc => dc.DeckId.Equals(idBaralho)))
                {
                    //Se a carta estiver associada ao baralho, adiciona-a na respetiva listview

                    if (registo.CardId == carta.Id)
                    {
                        qtdCartas = registo.Qtd;
                        ncartas+=qtdCartas;

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
                linhaListaCartas.SubItems.Add((3-qtdCartas).ToString());
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
            this.deckSetTableAdapter.Fill(this.bD_DA_ProjetoDataSet1.DeckSet);
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

            int countRegisto = container.DeckSet.Where(deck => deck.Name.Equals(nome)).Count();

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

                List<DeckCards> cartasBaralho = container.DeckCardsSet
                        .Where(dc => dc.DeckId.Equals(idBaralho)).ToList<DeckCards>();

                container.DeckCardsSet.RemoveRange(cartasBaralho);

                //Remover baralho

                Deck baralho = container.DeckSet.Where(d => d.Id.Equals(idBaralho)).Single();

                container.DeckSet.Remove(baralho);

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
        ///     Cria uma query (Linq) e seleciona os baralhos cujo nome contenha o texto obtido
        ///     Atribui a lista de resultados á DataGridView
        /// Senão
        ///     Recarrega a tabela
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

        /// <summary>
        /// Se o utilizador tiver selecionado uma carta na Lista de cartas (e o baralho tiver espaço)
        ///     Ativa o botão para adicionar a carta ao baralho
        /// Senão
        ///     Desativa-o
        /// </summary>
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

        /// <summary>
        /// Se o utilizador tiver seleciona uma carta na lista de cartas no baralho
        ///     Ativa o botão para remover a carta do baralho
        /// Senão
        ///     Desativa-o
        /// </summary>
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
                from bc in container.DeckCardsSet
                where bc.DeckId == idBaralho
                select bc;
 
            container.DeckCardsSet.RemoveRange(idCartasAntigas.ToList<DeckCards>());
            //--------------------------------

            foreach (ListViewItem item in lvCartasBaralho.Items)
            {
                qtdcarta = Convert.ToInt32(item.SubItems[2].Text);

                var search = container.CardSet.Where(f => f.Name.Equals(item.Text));
                carta = search.ToList<Card>().First<Card>();

                cartaBaralho = new DeckCards();
                cartaBaralho.DeckId = idBaralho;
                cartaBaralho.CardId = carta.Id;
                cartaBaralho.Qtd = qtdcarta;

                container.DeckCardsSet.Add(cartaBaralho);
            }

            container.SaveChanges();

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

            IQueryable<Card> query = container.CardSet;

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
                from baralho in container.DeckSet
                join cartabaralho in container.DeckCardsSet on baralho.Id equals cartabaralho.DeckId
                join carta in container.CardSet on cartabaralho.CardId equals carta.Id
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

            foreach (Card carta in container.CardSet)
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


    }
}
