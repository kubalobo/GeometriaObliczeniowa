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
    Point[] points;
}

class ReadFromFile
{
    int counter = 0;
    int actual;
    ObjectTypes actualType;
    string line;

    List<Shape> shapes = new List<Shape>();

    System.IO.StreamReader file =
            new System.IO.StreamReader(@".\ObiektyTerenowe.MAP");

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

                shapes.Add(new Shape());

                counter++;
            }
            else if (line[0] == 'P')
            {

            }

        }

        file.Close();
        Debug.WriteLine(counter);
    }
}

