using System;
using System.Drawing;
using System.Windows.Forms;

namespace labor1
{
    public class Form1 : Form
    {
        Label lblA;
        Label lblB;
        Label lblC;
        Label lblV;
        Label picBoxA;
        Label picBoxB;
        Label picBoxC;
        int LastClicked;
        bool PictureBoxClicked = false;
        int ClickedPictureBoxX, ClickedPictureBoxY;

        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "";
            this.BackColor = Color.LightGray;

            lblA = new Label();
            lblA.Text = "2+2=";
            lblA.Location = new Point(50, 370);
            lblA.Visible = true;
            lblA.Size = new Size(140, 70);
            lblA.BackColor = Color.Gray;
            lblA.TextAlign = ContentAlignment.MiddleCenter;

            lblB = new Label();
            lblB.Text = "3+3=";
            lblB.Location = new Point(270, 370);
            lblB.Visible = true;
            lblB.Size = new Size(140, 70);
            lblB.BackColor = Color.Gray;
            lblB.TextAlign = ContentAlignment.MiddleCenter;

            lblC = new Label();
            lblC.Text = "5+5=";
            lblC.Location = new Point(500, 370);
            lblC.Visible = true;
            lblC.Size = new Size(140, 70);
            lblC.BackColor = Color.Gray;
            lblC.TextAlign = ContentAlignment.MiddleCenter;

            lblV = new Label();
            lblV.Text = "";

            lblV.Location = new Point(500, 20);
            lblV.Visible = true;
            lblV.Size = new Size(50, 30);
            lblV.BackColor = Color.Gray;
            lblV.TextAlign = ContentAlignment.MiddleCenter;

            picBoxA = pictureboxMove("4", 10, 10, 70, 70);
            picBoxB = pictureboxMove("6", 220, 10, 70, 70);
            picBoxC = pictureboxMove("10", 380, 10, 70, 70);

            this.Controls.Add(lblC);
            this.Controls.Add(lblB);
            this.Controls.Add(lblA);
            this.Controls.Add(lblV);

            this.Controls.Add(picBoxA);
            this.Controls.Add(picBoxB);
            this.Controls.Add(picBoxC);

            picBoxA.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            picBoxB.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            picBoxC.MouseMove += new MouseEventHandler(PictureBox_MouseMove);

            picBoxA.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            picBoxB.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            picBoxC.MouseDown += new MouseEventHandler(PictureBox_MouseDown);

            picBoxA.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            picBoxB.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            picBoxC.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
        }

        private Label pictureboxMove(string text, int x, int y, int width, int height)
        {
            Label pictureBox = new Label();
            pictureBox.Text = text;
            pictureBox.ForeColor = Color.Black;
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(width, height);
            pictureBox.BackColor = Color.White;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            LastClicked_func();
            return pictureBox;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (PictureBoxClicked)
            {
                Label pictureBox = sender as Label;
                pictureBox.Left = e.X + pictureBox.Left - ClickedPictureBoxX;
                pictureBox.Top = e.Y + pictureBox.Top - ClickedPictureBoxY;
                LastClicked_func();
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBoxClicked = true;
            Label pictureBox = sender as Label;
            ClickedPictureBoxX = e.X;
            ClickedPictureBoxY = e.Y;
            LastClicked = 1;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBoxClicked = false;
            LastClicked_func();
        }

        private void LastClicked_func()
        {
            if (LastClicked == 1)
            {
                if ((lblA.Left < picBoxA.Right) && (lblA.Right > picBoxA.Left) &&
                    (lblA.Top < picBoxA.Bottom) && (lblA.Bottom > picBoxA.Top))
                {
                    lblV.Text = "Õige";
                }
                else
                {
                    lblV.Text = "";
                }
            }
        }
    }
}
