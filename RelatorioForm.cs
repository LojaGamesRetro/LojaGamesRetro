
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class RelatorioForm : Form
{
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

        DataGridView tabelaVendas = new DataGridView();
        tabelaVendas.Location = new Point(50, 155);
        tabelaVendas.Size = new Size(840, 275);
        tabelaVendas.BackgroundColor =
            Color.FromArgb(30, 30, 50);
        tabelaVendas.ForeColor = Color.Black;
        tabelaVendas.ReadOnly = true;

        tabelaVendas.AllowUserToAddRows = false;
        tabelaVendas.AllowUserToDeleteRows = false;
        tabelaVendas.RowHeadersVisible = false;
        tabelaVendas.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        tabelaVendas.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        tabelaVendas.Columns.Add("colPedido", "Pedido");
        tabelaVendas.Columns.Add("colData", "Data");
        tabelaVendas.Columns.Add("colJogos", "Jogos");
        tabelaVendas.Columns.Add("colTotal", "Total");

        Label lblTotal = new Label();
        lblTotal.Text = "Faturamento Total: R$ 0,00";
        lblTotal.Font = new Font(
            "Segoe UI", 16, FontStyle.Bold
        );
        lblTotal.ForeColor = Color.Cyan;
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        lblTotal.Location = new Point(400, 445);
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
        Controls.Add(lblTotal);
        Controls.Add(btnVoltar);
    }
}
