
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class MenuForm : Form
{
    private readonly Button btnCatalogo;
    private readonly Button btnRelatorio;

    public MenuForm()
    {
        Text = "Loja Games Retrô - Menu Principal";
        ClientSize = new Size(840, 500);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(20, 20, 35);

        Label lblLoja = new Label();
        lblLoja.Text = "LOJA GAMES RETRÔ";
        lblLoja.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblLoja.ForeColor = Color.Cyan;
        lblLoja.TextAlign = ContentAlignment.MiddleCenter;
        lblLoja.BackColor = Color.FromArgb(35, 35, 60);
        lblLoja.Location = new Point(0, 0);
        lblLoja.Size = new Size(840, 65);

        Label lblTitulo = new Label();
        lblTitulo.Text = "MENU PRINCIPAL";
        lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
        lblTitulo.ForeColor = Color.Cyan;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(120, 90);
        lblTitulo.Size = new Size(600, 60);

        Label lblMensagem = new Label();
        lblMensagem.Text = "Bem-vindo à sua loja de jogos clássicos!";
        lblMensagem.Font = new Font("Segoe UI", 13);
        lblMensagem.ForeColor = Color.White;
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        lblMensagem.Location = new Point(120, 155);
        lblMensagem.Size = new Size(600, 35);

        btnCatalogo = CriarBotao(
            "Catálogo de Jogos",
            220,
            Color.FromArgb(0, 150, 170)
        );
        btnCatalogo.Enabled = true;
        btnCatalogo.Click += AbrirCatalogo;

        btnRelatorio = CriarBotao(
            "Relatório de Vendas",
            290,
            Color.FromArgb(60, 110, 180)
        );
        btnRelatorio.Enabled = false;

        Button btnSair = CriarBotao(
            "Sair",
            360,
            Color.FromArgb(120, 60, 130)
        );

        btnSair.Click += (sender, e) => Close();

        Controls.Add(lblLoja);
        Controls.Add(lblTitulo);
        Controls.Add(lblMensagem);
        Controls.Add(btnCatalogo);
        Controls.Add(btnRelatorio);
        Controls.Add(btnSair);
    }

    private Button CriarBotao(
        string texto,
        int posicaoY,
        Color cor
    )
    {
        Button botao = new Button();

        botao.Text = texto;
        botao.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );

        botao.Size = new Size(320, 55);
        botao.Location = new Point(260, posicaoY);
        botao.BackColor = cor;
        botao.ForeColor = Color.White;
        botao.FlatStyle = FlatStyle.Flat;
        botao.FlatAppearance.BorderSize = 0;
        botao.Cursor = Cursors.Hand;

        return botao;
    }
    private void AbrirCatalogo(object? sender, EventArgs e)
    {
        using CatalogoForm catalogo = new CatalogoForm();
        catalogo.ShowDialog(this);
    }

}

