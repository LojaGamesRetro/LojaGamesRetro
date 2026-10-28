
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class RelatorioForm : Form
{
    private readonly DataGridView tabelaVendas;
    private readonly Label lblSituacao;
    private readonly Label lblJogosVendidos;
    private readonly Label lblTotal;
    private readonly TextBox txtBusca;
    private readonly ComboBox cmbPeriodo;


    private readonly CultureInfo culturaBrasil =
        new CultureInfo("pt-BR");

    public RelatorioForm()
    {
        Text = "Loja Games Retrô - Relatório";
        ClientSize = new Size(940, 665);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(20, 20, 35);

        Label lblTitulo = new Label();
        lblTitulo.Text = "RELATÓRIO DE VENDAS";
        lblTitulo.Font = new Font(
            "Segoe UI", 26, FontStyle.Bold
        );
        lblTitulo.ForeColor = Color.Cyan;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(100, 35);
        lblTitulo.Size = new Size(740, 65);

        Label lblDescricao = new Label();
        lblDescricao.Text = "Histórico de pedidos da loja";
        lblDescricao.Font = new Font("Segoe UI", 13);
        lblDescricao.ForeColor = Color.White;
        lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
        lblDescricao.Location = new Point(150, 100);
        lblDescricao.Size = new Size(640, 35);

        Label lblBusca = new Label();
        lblBusca.Text = "Pesquisar pedido ou jogo:";
        lblBusca.Font = new Font("Segoe UI", 10);
        lblBusca.ForeColor = Color.White;
        lblBusca.Location = new Point(50, 145);
        lblBusca.Size = new Size(300, 25);

        txtBusca = new TextBox();
        txtBusca.Font = new Font("Segoe UI", 11);
        txtBusca.Location = new Point(50, 173);
        txtBusca.Size = new Size(460, 32);
        txtBusca.PlaceholderText = "Digite um jogo ou código do pedido";

        cmbPeriodo = new ComboBox();
        cmbPeriodo.Font = new Font("Segoe UI", 10);
        cmbPeriodo.Location = new Point(530, 173);
        cmbPeriodo.Size = new Size(185, 32);
        cmbPeriodo.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cmbPeriodo.Items.AddRange(new object[]
        {
    "Todos os períodos",
    "Hoje",
    "Últimos 7 dias",
    "Últimos 30 dias"
        });

        cmbPeriodo.SelectedIndex = 0;

        Button btnAtualizar = new Button();
        btnAtualizar.Text = "Atualizar";
        btnAtualizar.Font = new Font(
            "Segoe UI", 10, FontStyle.Bold
        );
        btnAtualizar.Size = new Size(155, 34);
        btnAtualizar.Location = new Point(735, 172);
        btnAtualizar.BackColor =
            Color.FromArgb(0, 140, 160);
        btnAtualizar.ForeColor = Color.White;
        btnAtualizar.FlatStyle = FlatStyle.Flat;
        btnAtualizar.FlatAppearance.BorderSize = 0;
        btnAtualizar.Cursor = Cursors.Hand;

        btnAtualizar.Click += (sender, e) =>
        {
            CarregarVendas();
        };

        tabelaVendas = new DataGridView();
        tabelaVendas.Location = new Point(50, 220);
        tabelaVendas.Size = new Size(840, 270);
        tabelaVendas.BackgroundColor =
            Color.FromArgb(30, 30, 50);

        tabelaVendas.ReadOnly = true;
        tabelaVendas.AllowUserToAddRows = false;
        tabelaVendas.AllowUserToDeleteRows = false;
        tabelaVendas.RowHeadersVisible = false;
        tabelaVendas.MultiSelect = false;

        tabelaVendas.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        tabelaVendas.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        tabelaVendas.EnableHeadersVisualStyles = false;

        tabelaVendas.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(45, 45, 75);

        tabelaVendas.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;

        tabelaVendas.DefaultCellStyle.BackColor =
            Color.FromArgb(35, 35, 60);

        tabelaVendas.DefaultCellStyle.ForeColor =
            Color.White;

        tabelaVendas.DefaultCellStyle.SelectionBackColor =
            Color.DarkSlateBlue;

        tabelaVendas.DefaultCellStyle.SelectionForeColor =
            Color.White;

        tabelaVendas.Columns.Add("colPedido", "Pedido");
        tabelaVendas.Columns.Add("colData", "Data");
        tabelaVendas.Columns.Add("colJogos", "Jogos");
        tabelaVendas.Columns.Add("colTotal", "Total");

        lblSituacao = new Label();
        lblSituacao.Text = "Carregando vendas...";
        lblSituacao.Font = new Font("Segoe UI", 11);
        lblSituacao.ForeColor = Color.LightGray;
        lblSituacao.Location = new Point(50, 500);
        lblSituacao.Size = new Size(500, 30);

        lblJogosVendidos = new Label();
        lblJogosVendidos.Text = "Jogos vendidos: 0";
        lblJogosVendidos.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        lblJogosVendidos.ForeColor = Color.White;
        lblJogosVendidos.Location = new Point(50, 540);
        lblJogosVendidos.Size = new Size(320, 30);

        lblTotal = new Label();
        lblTotal.Text = "Faturamento: R$ 0,00";
        lblTotal.Font = new Font(
            "Segoe UI", 15, FontStyle.Bold
        );
        lblTotal.ForeColor = Color.Cyan;
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        lblTotal.Location = new Point(400, 535);
        lblTotal.Size = new Size(490, 40);

        Button btnVoltar = new Button();
        btnVoltar.Text = "Voltar ao Menu";
        btnVoltar.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        btnVoltar.Size = new Size(220, 45);
        btnVoltar.Location = new Point(360, 595);
        btnVoltar.BackColor = Color.DarkSlateBlue;
        btnVoltar.ForeColor = Color.White;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Cursor = Cursors.Hand;

        btnVoltar.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblDescricao);
        Controls.Add(lblBusca);
        Controls.Add(txtBusca);
        Controls.Add(cmbPeriodo);
        Controls.Add(btnAtualizar);
        Controls.Add(tabelaVendas);
        Controls.Add(lblSituacao);
        Controls.Add(lblJogosVendidos);
        Controls.Add(lblTotal);
        Controls.Add(btnVoltar);

        txtBusca.TextChanged += (sender, e) =>
        {
            CarregarVendas();
        };

        cmbPeriodo.SelectedIndexChanged += (sender, e) =>
        {
            CarregarVendas();
        };

        CarregarVendas();
    }

private void CarregarVendas()
    {
        try
        {
            var vendas = VendaRepository.Listar();

            string busca = txtBusca.Text.Trim();

            DateTime agora = DateTime.Now;

            var consulta = vendas.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                consulta = consulta.Where(venda =>
                    venda.Id.ToString("N").Contains(
                        busca,
                        StringComparison.OrdinalIgnoreCase
                    )
                    ||
                    venda.Itens.Any(item =>
                        item.Nome.Contains(
                            busca,
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                );
            }

            switch (cmbPeriodo.SelectedIndex)
            {
                case 1: 
                    consulta = consulta.Where(venda =>
                        venda.Data.Date == agora.Date
                    );
                    break;

                case 2: 
                    consulta = consulta.Where(venda =>
                        venda.Data >= agora.AddDays(-7)
                        && venda.Data <= agora
                    );
                    break;

                case 3: 
                    consulta = consulta.Where(venda =>
                        venda.Data >= agora.AddDays(-30)
                        && venda.Data <= agora
                    );
                    break;
            }

            var vendasFiltradas = consulta
                .OrderByDescending(venda => venda.Data)
                .ToList();

            tabelaVendas.Rows.Clear();

            foreach (Venda venda in vendasFiltradas)
            {
                string jogosComprados = string.Join(
                    ", ",
                    venda.Itens.Select(item =>
                        $"{item.Nome} x{item.Quantidade}"
                    )
                );

                tabelaVendas.Rows.Add(
                    venda.Id.ToString("N")[..8].ToUpperInvariant(),
                    venda.Data.ToString(
                        "dd/MM/yyyy HH:mm",
                        culturaBrasil
                    ),
                    jogosComprados,
                    venda.Total.ToString("C", culturaBrasil)
                );
            }

            int totalPedidos = vendasFiltradas.Count;

            int totalJogos = vendasFiltradas.Sum(venda =>
                venda.Itens.Sum(item => item.Quantidade)
            );

            decimal faturamento = vendasFiltradas.Sum(
                venda => venda.Total
            );

            lblSituacao.Text = vendas.Count == 0
                ? "Nenhuma venda registrada."
                : $"Pedidos exibidos: {totalPedidos} de {vendas.Count}";

            if (vendas.Count > 0 && totalPedidos == 0)
            {
                lblSituacao.Text =
                    "Nenhum pedido encontrado para os filtros.";
            }

            lblJogosVendidos.Text =
                $"Jogos vendidos: {totalJogos}";

            lblTotal.Text =
                $"Faturamento: {faturamento.ToString("C", culturaBrasil)}";
        }
        catch (Exception ex)
        {
            tabelaVendas.Rows.Clear();

            lblSituacao.Text = "Erro ao carregar vendas.";
            lblJogosVendidos.Text = "Jogos vendidos: --";
            lblTotal.Text = "Faturamento: --";

            MessageBox.Show(
                "Não foi possível carregar o relatório.\n" +
                ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

}

