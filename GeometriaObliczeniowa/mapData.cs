using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeometriaObliczeniowa
{
    class MapData
    {
        int counter = 0;
        string line;

        double minX = 999999999, maxX = -999999999, minY = 999999999, maxY = -999999999;

        public List<Shape> shapes = new List<Shape>();

        System.IO.StreamReader file = new System.IO.StreamReader(@".\ObiektyTerenowe.MAP");

        public void readLine()
        {
            while ((line = file.ReadLine()) != null)
            {
                // Tworzenie nowych obiektow
                if (line[0] == '*')
                {
                    switch (line[1])
                    {
                        case '1':
                            shapes.Add(new PointShape());
                            break;
                        case '4':
                            shapes.Add(new Polyline());
                            break;
                        case '5':
                            shapes.Add(new Polygon());
                            break;
                    }

                    counter++;
                }
                // Dodawanie punktow do ksztaltu
                else if (line[0] == 'P')
                {

                    double x = Convert.ToDouble(line.Substring(5, 11), System.Globalization.CultureInfo.InvariantCulture);
                    double y = Convert.ToDouble(line.Substring(18, 11), System.Globalization.CultureInfo.InvariantCulture);

                    shapes[counter - 1].addPoint(x, y);

                    // Sprawdzenie punktow skrajnych
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

        // Wyliczenie skali
        public double scale(int width, int hight)
        {
            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            double s1 = hight / rangeX;
            double s2 = width / rangeY;

            if (s1 < s2)
                return s1;
            else
                return s2;
        }

        public Shape getShape(int i)
        {
            return shapes[i];
        }

        public int getCount()
        {
            return counter;
        }

        public double getMinX()
        {
            return minX;
        }

        public double getMinY()
        {
            return minY;
        }
    }
}
