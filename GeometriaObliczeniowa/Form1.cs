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
    List<PointF> points = new List<PointF>();

    public Shape(ObjectTypes newType)
    {
        type = newType;
    }

    public void addPoint(float x, float y)
    {
        points.Add(new PointF(x, y));
    }

    public float giveX(int i)
    {
        return points[i].X;
    }
}

class ReadFromFile
{
    int counter = 0;
    ObjectTypes actualType;
    string line;

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

                float x = float.Parse(line.Substring(5, 11), System.Globalization.CultureInfo.InvariantCulture);
                float y = float.Parse(line.Substring(18, 11), System.Globalization.CultureInfo.InvariantCulture);

                shapes[counter - 1].addPoint(x, y);
            }

        }

        file.Close();
        Debug.WriteLine(counter);
//        Debug.WriteLine(shapes.Last.giveX[0]);
    }
}

