
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class MenuForm : Form
{
    public MenuForm()
    {
        Text = "Loja Games Retrô - Menu";
        Size = new Size(800, 450);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(20, 20, 35);

        Label lblTitulo = new Label();
        lblTitulo.Text = "MENU PRINCIPAL";
        lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
        lblTitulo.ForeColor = Color.Cyan;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Location = new Point(100, 100);
        lblTitulo.Size = new Size(600, 70);

        Label lblMensagem = new Label();
        lblMensagem.Text = "Bem-vindo à Loja Games Retrô!";
        lblMensagem.Font = new Font("Segoe UI", 14);
        lblMensagem.ForeColor = Color.White;
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        lblMensagem.Location = new Point(100, 190);
        lblMensagem.Size = new Size(600, 40);

        Button btnSair = new Button();
        btnSair.Text = "Sair";
        btnSair.Size = new Size(140, 45);
        btnSair.Location = new Point(330, 290);
        btnSair.BackColor = Color.DarkSlateBlue;
        btnSair.ForeColor = Color.White;
        btnSair.FlatStyle = FlatStyle.Flat;
        btnSair.Click += (sender, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(lblMensagem);
        Controls.Add(btnSair);
    }
}
