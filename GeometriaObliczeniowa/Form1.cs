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


class ReadFromFile
{
    int counter = 0;
    string line;

    System.IO.StreamReader file =
            new System.IO.StreamReader(@".\ObiektyTerenowe.MAP");

    public void readLine()
    {
        while ((line = file.ReadLine()) != null)
        {
            //System.Console.WriteLine(line);
            if (line[0] == '*')
            {
                //switch line[1]

                counter++;
            }


        }

        file.Close();
        Debug.WriteLine(counter);
    }
}

