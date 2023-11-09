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
        Rectangle Rectangle = new Rectangle(10, 10, 200, 100);
        Rectangle Circle = new Rectangle(220, 10, 150, 150);
        Rectangle Square = new Rectangle(380, 10, 150, 150);


        bool RectangleClicked = false;
        int RectangleX, RectangleY;
        public Form1()
        {

            this.Height = 500;
            this.Width = 700;
            this.Text = "";
            this.BackColor = Color.LightGray;

            lblA = new Label();
            lblA.Text = "Вид";
            lblA.Location = new Point(50, 370);
            lblA.Visible = true;
            lblA.Size = new Size(140, 70);
            lblA.BackColor = Color.Gray;
            lblA.TextAlign = ContentAlignment.MiddleCenter;

            lblB = new Label();
            lblB.Text = "Форма";
            lblB.Location = new Point(270, 370);
            lblB.Visible = true;
            lblB.Size = new Size(140, 70);
            lblB.BackColor = Color.Gray;
            lblB.TextAlign = ContentAlignment.MiddleCenter;

            lblC = new Label();
            lblC.Text = "Форма";
            lblC.Location = new Point(500, 370);
            lblC.Visible = true;
            lblC.Size = new Size(140, 70);
            lblC.BackColor = Color.Gray;
            lblC.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblC);
            this.Controls.Add(lblB);
            this.Controls.Add(lblA);

            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, Circle);
            e.Graphics.FillRectangle(Brushes.Blue, Rectangle);
            e.Graphics.FillRectangle(Brushes.Green, Square);
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X < Rectangle.X + Rectangle.Width) && (e.X > Rectangle.X) &&
                (e.Y < Rectangle.Y + Rectangle.Height) && (e.Y > Rectangle.Y))
            {
                RectangleClicked = true;
                RectangleX = e.X - Rectangle.X;
                RectangleY = e.Y - Rectangle.Y;
                Invalidate(); 
            }
            else
            {
                RectangleClicked = false;
            }
        }
    }
}
