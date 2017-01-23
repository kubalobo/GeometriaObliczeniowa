using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace GeometriaObliczeniowa
{
    abstract class Shape
    {
        public virtual void addPoint(double x, double y)
        { }

        public virtual void draw(PaintEventArgs e, double[] scale, Point move)
        { }
    }

    class PointShape : Shape
    {
        PointD cordPoint;

        public PointShape()
        { }

        public override void addPoint(double x, double y)
        {
            cordPoint = new PointD(x, y);
        }

        public override void draw(PaintEventArgs e, double[] scale, Point move)
        {
            //base.draw(e);

            int y = (int)((cordPoint.X - scale[1]) * scale[0]) - move.Y;
            int x = (int)((cordPoint.Y - scale[2]) * scale[0]) - move.X;
            
            e.Graphics.FillRectangle(Brushes.Black, x, y, 1, 1);
        }

    }

    class Polyline : Shape
    {
        List<PointD> points = new List<PointD>();

        public Polyline()
        { }

        public override void addPoint(double x, double y)
        {
            points.Add(new PointD(x, y));
        }

        public override void draw(PaintEventArgs e, double[] scale, Point move)
        {
            //base.draw(e);
            Point[] drawPoints = new Point[points.Count()];

            for (int i = 0; i < points.Count(); i++)
            { 
                drawPoints[i].Y = (int)((points[i].X - scale[1]) * scale[0]) - move.Y;
                drawPoints[i].X = (int)((points[i].Y - scale[2]) * scale[0]) - move.X;
            }

            //Debug.WriteLine(points.Count());

            // Wyjatek - bledne linie z tylko jednym punktem.
            if(drawPoints.Count() > 1)
                e.Graphics.DrawLines(Pens.Black, drawPoints);
        }
    }

    class Polygon : Shape
    {
        List<PointD> points = new List<PointD>();

        public Polygon()
        { }

        public override void addPoint(double x, double y)
        {
            points.Add(new PointD(x, y));
        }

        public override void draw(PaintEventArgs e, double[] scale, Point move)
        {
            //base.draw(e);
            Point[] drawPoints = new Point[points.Count()];

            for (int i = 0; i < points.Count(); i++)
            {
                drawPoints[i].Y = (int)((points[i].X - scale[1]) * scale[0]) - move.Y;
                drawPoints[i].X = (int)((points[i].Y - scale[2]) * scale[0]) - move.X;
            }

            //Debug.WriteLine(points.Count());

            // Wyjatek - bledne linie z tylko jednym punktem.
            if (drawPoints.Count() > 1)
                e.Graphics.DrawPolygon(Pens.Black, drawPoints);
        }
    }
}
