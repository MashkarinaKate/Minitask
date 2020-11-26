using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Минизадача_2
{
        abstract class Вершины
        {
            protected static int R;
            protected Point p;
            public abstract void DrawFigure(Graphics graf);
            public abstract int Radius { set; }
            public abstract Point Point { set; get; }
        public Вершины(int x, int y)
        {
            p.X = x;
            p.Y = y;
        }
        static Вершины()
        {
            R = 40;
        }
        public abstract bool CheckArea(int x, int y);
        }
        class Квадрат : Вершины
        {
            public Квадрат(int x, int y) :base(x, y){ }

            public override void DrawFigure(Graphics graf)
            {
                graf.FillRectangle(new SolidBrush(Color.Yellow), p.X - R / 2, p.Y - R / 2, R, R);
            }
            public override int Radius
            {
                set { R = value; }
            }
            public override Point Point
            {
                set { p = value; }
                get { return p; }
            }
            public override bool CheckArea(int x, int y)
            {
            if ((x >= p.X - R / 2 && x <= p.X + R/2) && (y >= p.Y - R/2 && y <= p.Y + R/2))
            {
                return true;
            }
            else return false;
            }
        }
        class Треугольник : Вершины
        {
        public Треугольник(int x, int y) : base(x, y) { }
        public override void DrawFigure(Graphics graf)
            {
                Point[] p3 = new Point[3];
                p3[0] = new Point(p.X + R / 2 - R / 2, p.Y - R / 2);
                p3[1] = new Point(p.X - R / 2, p.Y + R - R / 2);
                p3[2] = new Point(p.X + R - R / 2, p.Y + R - R / 2);
                graf.FillPolygon(new SolidBrush(Color.Yellow), p3);
            }
            public override int Radius
            {
                set { R = value; }
            }
            public override Point Point
            {
                set { p = value; }
                get { return p; }
            }
        public override bool CheckArea(int x, int y)
        {
            int a = (p.X + R / 2 - R / 2 - x) * (p.Y + R - R / 2 - (p.Y - R / 2)) - (p.X - R / 2 - (p.X + R / 2 - R / 2)) * (p.Y - R / 2 - y);
            int b = (p.X - R / 2 - x) * (p.Y + R - R / 2 - (p.Y + R - R / 2)) - (p.X + R - R / 2 - (p.X - R / 2)) * (p.Y + R - R / 2 - y);
            int c = (p.X + R - R / 2 - x) * (p.Y - R / 2 - (p.Y + R - R / 2)) - (p.X + R / 2 - R / 2 - (p.X + R - R / 2)) * (p.Y + R - R / 2 - y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            else return false;
        }
    }
        class Круг : Вершины
        {
        public Круг(int y, int x) : base(x,y) { }
        public override void DrawFigure(Graphics graf)
            {
                graf.FillEllipse(new SolidBrush(Color.Yellow), p.X - R / 2, p.Y - R / 2, R, R);
            }
            public override int Radius
            {
                set { R = value; }
            }
            public override Point Point
            {
                set { p = value; }
                get { return p; }
            }
        public override bool CheckArea(int x, int y)
        {
            if (Math.Pow(p.X - x, 2) + Math.Pow(p.Y - y, 2) <= Math.Pow(R/2, 2))
            {
                return true;
            }
            else return false;
        }
    }
    }
