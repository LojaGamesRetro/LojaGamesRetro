
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class CatalogoForm : Form
{
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
        lblTitulo.Location = new Point(100, 60);
        lblTitulo.Size = new Size(700, 70);

        Label lblMensagem = new Label();
        lblMensagem.Text = "Explore nossos jogos clássicos!";
        lblMensagem.Font = new Font("Segoe UI", 14);
        lblMensagem.ForeColor = Color.White;
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        lblMensagem.Location = new Point(100, 150);
        lblMensagem.Size = new Size(700, 40);

        Label lblCatalogo = new Label();
        lblCatalogo.Text =
            "Em breve: jogos, preços e pedidos!";
        lblCatalogo.Font = new Font("Segoe UI", 16);
        lblCatalogo.ForeColor = Color.LightGray;
        lblCatalogo.TextAlign = ContentAlignment.MiddleCenter;
        lblCatalogo.Location = new Point(150, 260);
        lblCatalogo.Size = new Size(600, 60);

        Button btnVoltar = new Button();
        btnVoltar.Text = "Voltar ao Menu";
        btnVoltar.Font = new Font(
            "Segoe UI", 12, FontStyle.Bold
        );
        btnVoltar.Size = new Size(220, 50);
        btnVoltar.Location = new Point(340, 460);
        btnVoltar.BackColor = Color.DarkSlateBlue;
        btnVoltar.ForeColor = Color.White;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Cursor = Cursors.Hand;

        btnVoltar.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblMensagem);
        Controls.Add(lblCatalogo);
        Controls.Add(btnVoltar);
    }
}
