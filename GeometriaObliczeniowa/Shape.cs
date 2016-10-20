using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometriaObliczeniowa
{
    abstract class Shape
    {
        public virtual void addPoint(double x, double y)
        { }
    }

    class Point : Shape
    {
        PointD cordPoint;

        public Point()
        { }

        public override void addPoint(double x, double y)
        {
            cordPoint = new PointD(x, y);
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
    }
}
