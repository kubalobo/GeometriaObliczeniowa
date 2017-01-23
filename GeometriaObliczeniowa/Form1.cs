using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

enum ObjectTypes
{
    Punkt,
    Lamana,
    Poligon
};

namespace GeometriaObliczeniowa
{

    public partial class Form1 : Form
    {
        MapData filemon = new MapData();

        int drawWidth = 800, drawHight = 600;
        Point move = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);

            this.MouseClick += new MouseEventHandler(Form1_MouseClick);


            //KeyPress += new KeyPressEventArgs(plusButton);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filemon.readLine();

            Debug.WriteLine(filemon.scale(800, 600));

            this.DoubleBuffered = true;
            //this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            double[] scale =
                {
                    filemon.scale(drawWidth, drawHight),
                    filemon.getMinX(),
                    filemon.getMinY(),
                };

            for(int i = 0; i < filemon.getCount(); i++)
                filemon.getShape(i).draw(e, scale, move);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawWidth = 800;
            drawHight = 600;
            move = new Point(0, 0);

            this.Paint += Form1_Paint;
            this.Invalidate(); // force Redraw the form
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Delta);
            drawWidth += e.Delta * 4;
            drawHight += e.Delta * 3;

            //move.X += System.Windows.Forms.Control.MousePosition.X - 512;
            //move.Y += System.Windows.Forms.Control.MousePosition.Y - 372;
            
            //this.Paint += Form1_Paint;
            this.Invalidate();

        }

        private Point MouseDownLocation, ClickLocation;


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                move.X -= (e.X - MouseDownLocation.X);
                move.Y -= (e.Y - MouseDownLocation.Y);

                this.Invalidate();


                MouseDownLocation = e.Location;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ClickLocation = e.Location;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.R):
                    {
                        drawWidth -= 40;
                        drawHight -= 30;

                        //move.X += System.Windows.Forms.Control.MousePosition.X - 512;
                        //move.Y += System.Windows.Forms.Control.MousePosition.X - 372;
                        //move.X -= 512;
                        //move.Y -= 372;

                        //this.Paint += Form1_Paint;
                        this.Invalidate();

                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }



        //void plusButton(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Enter key pressed
        //    }
        //}

    }


}



public struct PointD
{
    public double X;
    public double Y;

    public PointD(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Point ToPoint()
    {
        return new Point((int)X, (int)Y);
    }

    public override bool Equals(object obj)
    {
        return obj is PointD && this == (PointD)obj;
    }
    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
    public static bool operator ==(PointD a, PointD b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    public static bool operator !=(PointD a, PointD b)
    {
        return !(a == b);
    }
}

