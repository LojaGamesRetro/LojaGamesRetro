
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class CatalogoForm : Form
{
    private readonly List<Jogo> jogos = new List<Jogo>();

    private readonly CultureInfo culturaBrasil =
        new CultureInfo("pt-BR");

    public CatalogoForm()
    {
        Text = "Loja Games Retrô - Catálogo";
        ClientSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(20, 20, 35);

        Label lblTitulo = new Label();
        lblTitulo.Text = "CATÁLOGO DE JOGOS";
        lblTitulo.Font = new Font(
            "Segoe UI", 26, FontStyle.Bold
        );
        lblTitulo.ForeColor = Color.Cyan;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(50, 20);
        lblTitulo.Size = new Size(800, 65);

        Label lblMensagem = new Label();
        lblMensagem.Text =
            "Escolha seus jogos clássicos favoritos!";
        lblMensagem.Font = new Font("Segoe UI", 13);
        lblMensagem.ForeColor = Color.White;
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        lblMensagem.Location = new Point(100, 85);
        lblMensagem.Size = new Size(700, 35);

        FlowLayoutPanel painelJogos = new FlowLayoutPanel();
        painelJogos.Location = new Point(40, 130);
        painelJogos.Size = new Size(820, 385);
        painelJogos.AutoScroll = true;
        painelJogos.WrapContents = true;
        painelJogos.FlowDirection =
            FlowDirection.LeftToRight;
        painelJogos.BackColor =
            Color.FromArgb(25, 25, 43);

        CarregarJogos();

        foreach (Jogo jogo in jogos)
        {
            Panel card = CriarCard(jogo);
            painelJogos.Controls.Add(card);
        }

        Button btnVoltar = new Button();
        btnVoltar.Text = "Voltar ao Menu";
        btnVoltar.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        btnVoltar.Size = new Size(220, 45);
        btnVoltar.Location = new Point(340, 530);
        btnVoltar.BackColor = Color.DarkSlateBlue;
        btnVoltar.ForeColor = Color.White;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Cursor = Cursors.Hand;

        btnVoltar.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblMensagem);
        Controls.Add(painelJogos);
        Controls.Add(btnVoltar);
    }

    private void CarregarJogos()
    {
        jogos.Add(new Jogo
        {
            Nome = "Super Mario World",
            Console = "Super Nintendo",
            Preco = 129.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Sonic the Hedgehog",
            Console = "Mega Drive",
            Preco = 99.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Street Fighter II",
            Console = "Super Nintendo",
            Preco = 119.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Mortal Kombat 3",
            Console = "Mega Drive",
            Preco = 109.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Donkey Kong Country",
            Console = "Super Nintendo",
            Preco = 139.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Mega Man X",
            Console = "Super Nintendo",
            Preco = 149.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Chrono Trigger",
            Console = "Super Nintendo",
            Preco = 199.90m
        });

        jogos.Add(new Jogo
        {
            Nome = "Castlevania: Symphony of the Night",
            Console = "PlayStation 1",
            Preco = 179.90m
        });
    }
    private Panel CriarCard(Jogo jogo)
    {
        Panel card = new Panel();
        card.Size = new Size(245, 145);
        card.Margin = new Padding(10);
        card.BackColor =
            Color.FromArgb(40, 40, 65);
        card.BorderStyle = BorderStyle.FixedSingle;

        Label lblNome = new Label();
        lblNome.Text = jogo.Nome;
        lblNome.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        lblNome.ForeColor = Color.Cyan;
        lblNome.Location = new Point(12, 12);
        lblNome.Size = new Size(220, 48);

        Label lblConsole = new Label();
        lblConsole.Text = jogo.Console;
        lblConsole.Font = new Font("Segoe UI", 10);
        lblConsole.ForeColor = Color.LightGray;
        lblConsole.Location = new Point(12, 67);
        lblConsole.Size = new Size(220, 25);

        Label lblPreco = new Label();
        lblPreco.Text =
            jogo.Preco.ToString("C", culturaBrasil);
        lblPreco.Font = new Font(
            "Segoe UI", 14, FontStyle.Bold
        );
        lblPreco.ForeColor = Color.LightGreen;
        lblPreco.Location = new Point(12, 105);
        lblPreco.Size = new Size(220, 30);

        card.Controls.Add(lblNome);
        card.Controls.Add(lblConsole);
        card.Controls.Add(lblPreco);

        return card;
    }
}
