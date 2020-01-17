using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        TictactoeField tictactoeField00;
        TictactoeField tictactoeField01;
        TictactoeField tictactoeField02;
        TictactoeField tictactoeField10;
        TictactoeField tictactoeField11;
        TictactoeField tictactoeField12;
        TictactoeField tictactoeField20;
        TictactoeField tictactoeField21;
        TictactoeField tictactoeField22;
        public Form1()
        {
            InitializeComponent();
            tictactoeField00 = new TictactoeField();
            tictactoeField01 = new TictactoeField();
            tictactoeField02 = new TictactoeField();
            tictactoeField10 = new TictactoeField();
            tictactoeField11 = new TictactoeField();
            tictactoeField12 = new TictactoeField();
            tictactoeField20 = new TictactoeField();
            tictactoeField21 = new TictactoeField();
            tictactoeField22 = new TictactoeField();

            flowLayoutPanel1.Controls.Add(tictactoeField00);
            flowLayoutPanel1.Controls.Add(tictactoeField01);
            flowLayoutPanel1.Controls.Add(tictactoeField02);
            flowLayoutPanel1.Controls.Add(tictactoeField10);
            flowLayoutPanel1.Controls.Add(tictactoeField11);
            flowLayoutPanel1.Controls.Add(tictactoeField12);
            flowLayoutPanel1.Controls.Add(tictactoeField20);
            flowLayoutPanel1.Controls.Add(tictactoeField21);
            flowLayoutPanel1.Controls.Add(tictactoeField22);

            tictactoeField00.Size = new Size(130, 130);
            tictactoeField01.Size = new Size(130, 130);
            tictactoeField02.Size = new Size(130, 130);
            tictactoeField10.Size = new Size(130, 130);
            tictactoeField11.Size = new Size(130, 130);
            tictactoeField12.Size = new Size(130, 130);
            tictactoeField20.Size = new Size(130, 130);
            tictactoeField21.Size = new Size(130, 130);
            tictactoeField22.Size = new Size(130, 130);

            tictactoeField00.Click += PositionChosedClick;
            tictactoeField01.Click += PositionChosedClick;
            tictactoeField02.Click += PositionChosedClick;
            tictactoeField10.Click += PositionChosedClick;
            tictactoeField11.Click += PositionChosedClick;
            tictactoeField12.Click += PositionChosedClick;
            tictactoeField20.Click += PositionChosedClick;
            tictactoeField21.Click += PositionChosedClick;
            tictactoeField22.Click += PositionChosedClick;

            this.CurrentPlayer = TypeOfBox.Cross;
        }

        public void PositionChosedClick(object sender, EventArgs e)
        {
            TictactoeField buttonPressed = (TictactoeField)sender;
            if (buttonPressed.elementes != null)
            {
                return;
            }
            turns++;
            buttonPressed.elementes = this.CurrentPlayer;
            if (this.CurrentPlayer == TypeOfBox.Cross)
            {
                buttonPressed.BackgroundImage = new Bitmap(Resources.mark, new Size(130, 130));
                this.CurrentPlayer = TypeOfBox.Circle;
            }
            else
            {
                buttonPressed.BackgroundImage = new Bitmap(Resources.circle, new Size(130, 130));
                this.CurrentPlayer = TypeOfBox.Cross;
            }

            if (this.CheckWiner())
            {
                if (this.CurrentPlayer == TypeOfBox.Circle)
                {
                    DisableButtons();
                    MessageBox.Show("Winner cross");
                    this.PlayerXWins++;
                    this.textBox2.Text = this.PlayerXWins.ToString();
                    this.turns = 0;
                    return;
                }
                DisableButtons();
                this.PlayerOWins++;
                this.textBox1.Text = this.PlayerOWins.ToString();
                this.turns = 0;
                MessageBox.Show("Winner circle");
            }
            else if (turns == 9)
            {
                DisableButtons();
                MessageBox.Show("Draw");
                Draws++;
                this.turns = 0;
                this.textBox3.Text = this.Draws.ToString();
            }
        }

        public void DisableButtons()
        {
            tictactoeField00.Enabled = false;
            tictactoeField01.Enabled = false;
            tictactoeField02.Enabled = false;
            tictactoeField10.Enabled = false;
            tictactoeField11.Enabled = false;
            tictactoeField12.Enabled = false;
            tictactoeField20.Enabled = false;
            tictactoeField21.Enabled = false;
            tictactoeField22.Enabled = false;
        }

        public TypeOfBox CurrentPlayer { get; set; }

        public int PlayerXWins = 0;
        public int PlayerOWins = 0;
        public int Draws = 0;
        public int turns = 0;
        
        private bool CheckWiner()
        {
            if ((this.tictactoeField00.elementes == this.tictactoeField01.elementes)
                && (this.tictactoeField02.elementes == tictactoeField01.elementes)
                && this.tictactoeField00.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField10.elementes == this.tictactoeField11.elementes)
                && (this.tictactoeField12.elementes == tictactoeField11.elementes)
                && this.tictactoeField10.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField20.elementes == this.tictactoeField21.elementes)
                && (this.tictactoeField22.elementes == tictactoeField21.elementes)
                && this.tictactoeField20.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField00.elementes == this.tictactoeField10.elementes)
                && (this.tictactoeField20.elementes == tictactoeField10.elementes)
                && this.tictactoeField20.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField01.elementes == this.tictactoeField11.elementes)
                && (this.tictactoeField21.elementes == tictactoeField11.elementes)
                && this.tictactoeField01.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField02.elementes == this.tictactoeField12.elementes)
                && (this.tictactoeField22.elementes == tictactoeField12.elementes)
                && this.tictactoeField02.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField00.elementes == this.tictactoeField11.elementes)
                && (this.tictactoeField22.elementes == tictactoeField11.elementes)
                && this.tictactoeField00.elementes != null)
            {
                return true;
            }

            if ((this.tictactoeField20.elementes == this.tictactoeField11.elementes)
                && (this.tictactoeField02.elementes == tictactoeField11.elementes)
                && this.tictactoeField20.elementes != null)
            {
                return true;
            }
            return false;
        }

        public enum TypeOfBox
        {
            Cross,
            Circle
        }
        public class TictactoeField : Button
        {
            public TypeOfBox? elementes { get; set; }

            public TictactoeField()
            {
                elementes = null;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tictactoeField00.Enabled = true;
            tictactoeField01.Enabled = true;
            tictactoeField02.Enabled = true;
            tictactoeField10.Enabled = true;
            tictactoeField11.Enabled = true;
            tictactoeField12.Enabled = true;
            tictactoeField20.Enabled = true;
            tictactoeField21.Enabled = true;
            tictactoeField22.Enabled = true;

            tictactoeField00.BackgroundImage = null;
            tictactoeField01.BackgroundImage = null;
            tictactoeField02.BackgroundImage = null;
            tictactoeField10.BackgroundImage = null;
            tictactoeField11.BackgroundImage = null;
            tictactoeField12.BackgroundImage = null;
            tictactoeField20.BackgroundImage = null;
            tictactoeField21.BackgroundImage = null;
            tictactoeField22.BackgroundImage = null;

            tictactoeField00.elementes = null;
            tictactoeField01.elementes = null;
            tictactoeField02.elementes = null;
            tictactoeField10.elementes = null;
            tictactoeField11.elementes = null;
            tictactoeField12.elementes = null;
            tictactoeField20.elementes = null;
            tictactoeField21.elementes = null;
            tictactoeField22.elementes = null;
        }
    }
}
