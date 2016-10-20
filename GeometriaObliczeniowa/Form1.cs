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
            Debug.WriteLine(filemon.scale(200, 200));

            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(50, 50, 100, 100));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filemon
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

