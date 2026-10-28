
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaGamesRetro;

public class SplashForm : Form
{
    private readonly ProgressBar barraProgresso;
    private readonly Label lblStatus;
    private readonly System.Windows.Forms.Timer timerCarregamento;

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

        Panel painelCarregamento = new Panel();
        painelCarregamento.Dock = DockStyle.Bottom;
        painelCarregamento.Height = 110;
        painelCarregamento.BackColor = BackColor;

        lblStatus = new Label();
        lblStatus.Text = "Carregando jogos...";
        lblStatus.ForeColor = Color.White;
        lblStatus.Font = new Font("Segoe UI", 12);
        lblStatus.TextAlign = ContentAlignment.MiddleCenter;
        lblStatus.Dock = DockStyle.Top;
        lblStatus.Height = 35;

        barraProgresso = new ProgressBar();
        barraProgresso.Minimum = 0;
        barraProgresso.Maximum = 100;
        barraProgresso.Value = 0;
        barraProgresso.Style = ProgressBarStyle.Continuous;
        barraProgresso.Location = new Point(150, 55);
        barraProgresso.Size = new Size(500, 25);

        painelCarregamento.Controls.Add(lblStatus);
        painelCarregamento.Controls.Add(barraProgresso);

        Controls.Add(lblTitulo);
        Controls.Add(painelCarregamento);

        timerCarregamento = new System.Windows.Forms.Timer();
        timerCarregamento.Interval = 40;
        timerCarregamento.Tick += TimerCarregamento_Tick;

        Shown += (sender, e) => timerCarregamento.Start();

        FormClosed += (sender, e) => timerCarregamento.Dispose();
    }

    private void TimerCarregamento_Tick(object? sender, EventArgs e)
    {
        if (barraProgresso.Value < 100)
        {
            barraProgresso.Value += 2;
        }
        else
        {
            timerCarregamento.Stop();
            lblStatus.Text = "Carregamento concluído!";
        }
    }
}
