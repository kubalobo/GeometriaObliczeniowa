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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filemon.readLine();

            Debug.WriteLine(filemon.scale(800, 600));

            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            double[] scale =
                {
                    filemon.scale(800, 600),
                    filemon.getMinX(),
                    filemon.getMinY(),
                };

            for(int i = 0; i < filemon.getCount(); i++)
                filemon.getShape(i).draw(e, scale);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate(); // force Redraw the form
        }
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

