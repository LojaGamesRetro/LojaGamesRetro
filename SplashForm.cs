
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class SplashForm : Form
{
    public SplashForm()
    {
        Text = "Loja Games Retrô";
        Size = new Size(800, 450);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(20, 20, 35);

        Label lblTitulo = new Label();
        lblTitulo.Text = "LOJA GAMES RETRÔ";
        lblTitulo.Font = new Font("Segoe UI", 30, FontStyle.Bold);
        lblTitulo.ForeColor = Color.Cyan;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Dock = DockStyle.Fill;

        Controls.Add(lblTitulo);
    }
}
