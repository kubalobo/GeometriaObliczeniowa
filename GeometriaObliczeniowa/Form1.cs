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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFromFile filemon = new ReadFromFile();

            filemon.readLine();
            
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(50, 50, 100, 100));
        }
    }

}

class Shape
{
    ObjectTypes type;
    List<PointD> points = new List<PointD>();

    public Shape(ObjectTypes newType)
    {
        type = newType;
    }

    public void addPoint(double x, double y)
    {
        points.Add(new PointD(x, y));
    }

    //public float getX(int i)
    //{
    //    return points[i].X;
    //}
}

class ReadFromFile
{
    int counter = 0;
    ObjectTypes actualType;
    string line;

    double  minX = 999999999, maxX = -999999999, minY = 999999999, maxY = -999999999;

    List<Shape> shapes = new List<Shape>();

    System.IO.StreamReader file = new System.IO.StreamReader(@".\ObiektyTerenowe.MAP");

    public void readLine()
    {
        while ((line = file.ReadLine()) != null)
        {
            if (line[0] == '*')
            {
                switch (line[1])
                {
                    case '1':
                        actualType = ObjectTypes.Punkt;
                        break;
                    case '4':
                        actualType = ObjectTypes.Lamana;
                        break;
                    case '5':
                        actualType = ObjectTypes.Poligon;
                        break;
                }

                shapes.Add(new Shape(actualType));

                counter++;
            }
            else if (line[0] == 'P')
            {

                double x = Convert.ToDouble(line.Substring(5, 11), System.Globalization.CultureInfo.InvariantCulture);
                double y = Convert.ToDouble(line.Substring(18, 11), System.Globalization.CultureInfo.InvariantCulture);

                shapes[counter - 1].addPoint(x, y);

                if (x > maxX)
                    maxX = x;
                if (x < minX)
                    minX = x;
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
            }

        }

        file.Close();
        Debug.WriteLine(counter);
        Debug.WriteLine(maxX);
        Debug.WriteLine(minX);
        Debug.WriteLine(maxY);
        Debug.WriteLine(minY);
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

