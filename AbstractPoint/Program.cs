using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPoint
{
    class Program
    {
        abstract class AbstractPoint
        {
            public abstract Point PointRepresentation();
            public abstract Point Rotate(int angle);
            public abstract Point Move(double dx, double dy);
        }
        class Point : AbstractPoint
        {
            double a, b;
            public Point(double n, double n2)
            {
                a = n;
                b = n2;
            }

            public override string ToString()
            {
                return (String.Format($"({a},{b})"));
            }
            public override Point PointRepresentation()
            {
                double r = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                double A = Math.Atan(b / a);
                // return new Point(r*Math.Cos(A) , r*Math.Sin(A));
                // return new Point(r, A);
                double angleRad = (Math.PI / 180.0) * (A - 90);
                double x = r * Math.Cos(angleRad);
                double y = r * Math.Sin(angleRad);
                Console.WriteLine($"Coordonatele carteziene,respectiv polare ale punctului P({a},{b}) sunt (a,b)[r,A]=({x},{y})[{r },{A }]");
                return new Point(x, y);
            }
            public override Point Rotate(int angle)
            {
                return new Point(a * Math.Cos(angle) - b * Math.Sin(angle), b * Math.Cos(angle) + a * Math.Sin(angle));
            }
            public override Point Move(double dx, double dy)
            {
                return new Point(a + dx, b + dy);
            }
            static void Main(string[] args)
            {
                int a = 2;
                int b = 1;
                var punct = new Point(a, b);

                Console.WriteLine($"Coordonatele carteziene sunt:{punct.PointRepresentation()}");
                Console.WriteLine($"Coordonatele punctului P({a},{b}) dupa rotatia de unghi=1 sunt :{punct.Rotate(1)}");
                Console.WriteLine($"Coordonatele punctului P({a},{b}) dupa translatie sunt :{punct.Move(3, 5)}");
            }
        }
    }
}
