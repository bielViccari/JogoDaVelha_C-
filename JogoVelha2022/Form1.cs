using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoVelha2022
{
    public partial class Form1 : Form
    {
        string jogador = "X";
        int jogX = 0;
        int jogO = 0;
        int jogE = 0;
        int totalClicks = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BotaoClicado(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == "")
            {
                totalClicks++;
                if (jogador == "X")
                {
                    b.Text = jogador;
                    b.ForeColor = Color.Red;
                    Vencedor();
                    jogador = "O";
                }
                else
                {
                    b.Text = jogador;
                    b.ForeColor = Color.DarkGreen;
                    Vencedor();
                    jogador = "X";
                }
            }
        }

        private void Vencedor()
        {
            if (
                ((btn1.Text == jogador) && (btn2.Text == jogador) && (btn3.Text == jogador)) ||
                ((btn4.Text == jogador) && (btn5.Text == jogador) && (btn6.Text == jogador)) ||
                ((btn7.Text == jogador) && (btn8.Text == jogador) && (btn9.Text == jogador)) ||
                ((btn1.Text == jogador) && (btn4.Text == jogador) && (btn7.Text == jogador)) ||
                ((btn2.Text == jogador) && (btn5.Text == jogador) && (btn8.Text == jogador)) ||
                ((btn3.Text == jogador) && (btn6.Text == jogador) && (btn9.Text == jogador)) ||
                ((btn1.Text == jogador) && (btn5.Text == jogador) && (btn9.Text == jogador)) ||
                ((btn3.Text == jogador) && (btn5.Text == jogador) && (btn7.Text == jogador)) 
               )
            {
                MessageBox.Show("O jogador " + jogador + " ganhou!");
                if(jogador == "X")
                {
                    jogX++;
                    lblJogX.Text = jogX.ToString();
                }
                else
                {
                    jogO++;
                    lblJogO.Text = jogO.ToString();
                }
                limpaVelha();
            } else
            {
                if(totalClicks >= 9)
                {
                    MessageBox.Show("Deu velha!");
                    jogE++;
                    limpaVelha();
                    lblEmpate.Text = jogE.ToString();
                }
            }
        }

        private void limpaVelha()
        {
            foreach(Control c in this.Controls)
            {
                if(c is Button)
                {
                    c.Text = "";
                    c.ForeColor = Color.Black;
                    totalClicks = 0;
                }
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.Size = new Size(430, 843);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Size = new Size(430, 662);
        }
    }
}
