
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

    private readonly CultureInfo culturaBrasil =
        new CultureInfo("pt-BR");

    public RelatorioForm()
    {
        Text = "Loja Games Retrô - Relatório";
        ClientSize = new Size(940, 580);
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

        tabelaVendas = new DataGridView();
        tabelaVendas.Location = new Point(50, 155);
        tabelaVendas.Size = new Size(840, 275);
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
        lblSituacao.Location = new Point(50, 435);
        lblSituacao.Size = new Size(500, 30);

        lblJogosVendidos = new Label();
        lblJogosVendidos.Text = "Jogos vendidos: 0";
        lblJogosVendidos.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        lblJogosVendidos.ForeColor = Color.White;
        lblJogosVendidos.Location = new Point(50, 465);
        lblJogosVendidos.Size = new Size(320, 30);

        lblTotal = new Label();
        lblTotal.Text = "Faturamento: R$ 0,00";
        lblTotal.Font = new Font(
            "Segoe UI", 15, FontStyle.Bold
        );
        lblTotal.ForeColor = Color.Cyan;
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        lblTotal.Location = new Point(400, 460);
        lblTotal.Size = new Size(490, 40);

        Button btnVoltar = new Button();
        btnVoltar.Text = "Voltar ao Menu";
        btnVoltar.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        btnVoltar.Size = new Size(220, 45);
        btnVoltar.Location = new Point(360, 510);
        btnVoltar.BackColor = Color.DarkSlateBlue;
        btnVoltar.ForeColor = Color.White;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Cursor = Cursors.Hand;

        btnVoltar.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblDescricao);
        Controls.Add(tabelaVendas);
        Controls.Add(lblSituacao);
        Controls.Add(lblJogosVendidos);
        Controls.Add(lblTotal);
        Controls.Add(btnVoltar);

        CarregarVendas();
    }

    private void CarregarVendas()
    {
        try
        {
            tabelaVendas.Rows.Clear();

            var vendas = VendaRepository.Listar();

            foreach (Venda venda in vendas)
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
                        "dd/MM/yyyy HH:mm", culturaBrasil
                    ),
                    jogosComprados,
                    venda.Total.ToString("C", culturaBrasil)
                );
            }

            int totalPedidos = vendas.Count;

            int totalJogos = vendas.Sum(venda =>
                venda.Itens.Sum(item => item.Quantidade)
            );

            decimal faturamento = vendas.Sum(
                venda => venda.Total
            );

            lblSituacao.Text =
                $"Pedidos realizados: {totalPedidos}";

            lblJogosVendidos.Text =
                $"Jogos vendidos: {totalJogos}";

            lblTotal.Text =
                $"Faturamento: {faturamento.ToString("C", culturaBrasil)}";

        }
        catch (Exception ex)
        {
            lblSituacao.Text =
                "Erro ao carregar as vendas.";

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
