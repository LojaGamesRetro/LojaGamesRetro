
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class CatalogoForm : Form
{
    private readonly List<Jogo> jogos = new();
    private readonly List<ItemCarrinho> carrinho = new();

    private readonly CultureInfo culturaBrasil =
        new CultureInfo("pt-BR");

    private readonly ListBox listaCarrinho;
    private readonly Label lblTotal;
    private readonly Label lblQuantidade;

    public CatalogoForm()
    {
        Text = "Loja Games Retrô - Catálogo";
        ClientSize = new Size(1050, 650);
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
        lblTitulo.Size = new Size(950, 65);

        Label lblMensagem = new Label();
        lblMensagem.Text =
            "Escolha seus jogos clássicos favoritos!";
        lblMensagem.Font = new Font("Segoe UI", 13);
        lblMensagem.ForeColor = Color.White;
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        lblMensagem.Location = new Point(100, 85);
        lblMensagem.Size = new Size(850, 35);

        FlowLayoutPanel painelJogos = new FlowLayoutPanel();
        painelJogos.Location = new Point(30, 130);
        painelJogos.Size = new Size(620, 445);
        painelJogos.AutoScroll = true;
        painelJogos.WrapContents = true;
        painelJogos.FlowDirection =
            FlowDirection.LeftToRight;
        painelJogos.BackColor =
            Color.FromArgb(25, 25, 43);

        Panel painelCarrinho = new Panel();
        painelCarrinho.Location = new Point(670, 130);
        painelCarrinho.Size = new Size(350, 445);
        painelCarrinho.BackColor =
            Color.FromArgb(35, 35, 60);

        Label lblCarrinho = new Label();
        lblCarrinho.Text = "MEU CARRINHO";
        lblCarrinho.Font = new Font(
            "Segoe UI", 17, FontStyle.Bold
        );
        lblCarrinho.ForeColor = Color.Cyan;
        lblCarrinho.TextAlign = ContentAlignment.MiddleCenter;
        lblCarrinho.Location = new Point(15, 12);
        lblCarrinho.Size = new Size(320, 35);

        listaCarrinho = new ListBox();
        listaCarrinho.Location = new Point(15, 60);
        listaCarrinho.Size = new Size(320, 225);
        listaCarrinho.Font = new Font("Segoe UI", 10);
        listaCarrinho.BackColor =
            Color.FromArgb(25, 25, 43);
        listaCarrinho.ForeColor = Color.White;
        listaCarrinho.BorderStyle = BorderStyle.FixedSingle;

        lblQuantidade = new Label();
        lblQuantidade.Text = "Quantidade: 0";
        lblQuantidade.Font = new Font("Segoe UI", 11);
        lblQuantidade.ForeColor = Color.White;
        lblQuantidade.Location = new Point(15, 300);
        lblQuantidade.Size = new Size(320, 30);

        lblTotal = new Label();
        lblTotal.Text = "Total: R$ 0,00";
        lblTotal.Font = new Font(
            "Segoe UI", 16, FontStyle.Bold
        );
        lblTotal.ForeColor = Color.LightGreen;
        lblTotal.Location = new Point(15, 335);
        lblTotal.Size = new Size(320, 35);

        Button btnRemover = new Button();
        btnRemover.Text = "Remover Item";
        btnRemover.Font = new Font(
            "Segoe UI", 11, FontStyle.Bold
        );
        btnRemover.Location = new Point(65, 380);
        btnRemover.Size = new Size(220, 40);
        btnRemover.BackColor = Color.Firebrick;
        btnRemover.ForeColor = Color.White;
        btnRemover.FlatStyle = FlatStyle.Flat;
        btnRemover.FlatAppearance.BorderSize = 0;
        btnRemover.Cursor = Cursors.Hand;
        btnRemover.Click += RemoverItem;

        painelCarrinho.Controls.Add(lblCarrinho);
        painelCarrinho.Controls.Add(listaCarrinho);
        painelCarrinho.Controls.Add(lblQuantidade);
        painelCarrinho.Controls.Add(lblTotal);
        painelCarrinho.Controls.Add(btnRemover);

        CarregarJogos();

        foreach (Jogo jogo in jogos)
        {
            painelJogos.Controls.Add(CriarCard(jogo));
        }

        Button btnVoltar = new Button();
        btnVoltar.Text = "Voltar ao Menu";
        btnVoltar.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        btnVoltar.Size = new Size(220, 45);
        btnVoltar.Location = new Point(415, 590);
        btnVoltar.BackColor = Color.DarkSlateBlue;
        btnVoltar.ForeColor = Color.White;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Cursor = Cursors.Hand;
        btnVoltar.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblMensagem);
        Controls.Add(painelJogos);
        Controls.Add(painelCarrinho);
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
        card.Size = new Size(275, 178);
        card.Margin = new Padding(8);
        card.BackColor =
            Color.FromArgb(40, 40, 65);
        card.BorderStyle = BorderStyle.FixedSingle;

        Label lblNome = new Label();
        lblNome.Text = jogo.Nome;
        lblNome.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        lblNome.ForeColor = Color.Cyan;
        lblNome.Location = new Point(12, 10);
        lblNome.Size = new Size(250, 48);

        Label lblConsole = new Label();
        lblConsole.Text = jogo.Console;
        lblConsole.Font = new Font("Segoe UI", 10);
        lblConsole.ForeColor = Color.LightGray;
        lblConsole.Location = new Point(12, 62);
        lblConsole.Size = new Size(250, 25);

        Label lblPreco = new Label();
        lblPreco.Text =
            jogo.Preco.ToString("C", culturaBrasil);
        lblPreco.Font = new Font(
            "Segoe UI", 14, FontStyle.Bold
        );
        lblPreco.ForeColor = Color.LightGreen;
        lblPreco.Location = new Point(12, 95);
        lblPreco.Size = new Size(250, 30);

        Button btnAdicionar = new Button();
        btnAdicionar.Text = "Adicionar ao Carrinho";
        btnAdicionar.Font = new Font(
            "Segoe UI", 10, FontStyle.Bold
        );
        btnAdicionar.Size = new Size(245, 32);
        btnAdicionar.Location = new Point(12, 132);
        btnAdicionar.BackColor =
            Color.FromArgb(0, 140, 160);
        btnAdicionar.ForeColor = Color.White;
        btnAdicionar.FlatStyle = FlatStyle.Flat;
        btnAdicionar.FlatAppearance.BorderSize = 0;
        btnAdicionar.Cursor = Cursors.Hand;

        btnAdicionar.Click += (sender, e) =>
        {
            AdicionarAoCarrinho(jogo);
        };

        card.Controls.Add(lblNome);
        card.Controls.Add(lblConsole);
        card.Controls.Add(lblPreco);
        card.Controls.Add(btnAdicionar);

        return card;
    }

    private void AdicionarAoCarrinho(Jogo jogo)
    {
        ItemCarrinho? item = carrinho
            .FirstOrDefault(i => i.Jogo == jogo);

        if (item == null)
        {
            carrinho.Add(new ItemCarrinho(jogo));
        }
        else
        {
            item.Quantidade++;
        }

        AtualizarCarrinho();
    }

    private void RemoverItem(object? sender, EventArgs e)
    {
        int indice = listaCarrinho.SelectedIndex;

        if (indice < 0 || indice >= carrinho.Count)
        {
            MessageBox.Show(
                "Selecione um jogo no carrinho.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        ItemCarrinho item = carrinho[indice];

        if (item.Quantidade > 1)
        {
            item.Quantidade--;
        }
        else
        {
            carrinho.RemoveAt(indice);
        }

        AtualizarCarrinho();
    }

    private void AtualizarCarrinho()
    {
        listaCarrinho.Items.Clear();

        foreach (ItemCarrinho item in carrinho)
        {
            string texto =
                $"{item.Jogo.Nome} x{item.Quantidade} - " +
                item.Subtotal.ToString("C", culturaBrasil);

            listaCarrinho.Items.Add(texto);
        }

        int quantidadeTotal =
            carrinho.Sum(i => i.Quantidade);

        decimal valorTotal =
            carrinho.Sum(i => i.Subtotal);

        lblQuantidade.Text =
            $"Quantidade: {quantidadeTotal}";

        lblTotal.Text =
            $"Total: {valorTotal.ToString("C", culturaBrasil)}";
    }
}
