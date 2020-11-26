using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Машкарин_Иван_Минизадача3
{
    public partial class Form1 : Form
    {
        List<Вершины> S;
        int CursorX;
        int CursorY;
        int shapenumb;
        bool beingDragged;
        bool Draw;
        int sdvigx;
        int sdvigy;
        int i;
        public Form1()
        {
            InitializeComponent();
            квадратToolStripMenuItem.CheckOnClick = true;
            треугольникToolStripMenuItem.CheckOnClick = true;
            кругToolStripMenuItem.CheckOnClick = true;
            квадратToolStripMenuItem.Checked = true;
            S = new List<Вершины>();
            beingDragged = false;
            Draw = false;
            shapenumb = 0;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Draw)
            {
                for (int j = 0; j < S.Count; j++)
                {
                    S[j].DrawFigure(e.Graphics);
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            i = -1;
            while(i < S.Count - 1)
            {
                i++;
                if (S[i].CheckArea(e.X, e.Y))
                {
                    break;
                }
            }
            if(S.Count == 0)
            {
                Draw = false;
            }
                if (Draw && S[i].CheckArea(e.X, e.Y))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        sdvigx = e.X - S[i].Point.X;
                        sdvigy = e.Y - S[i].Point.Y;
                        beingDragged = true;
                }
                    if (e.Button == MouseButtons.Right)
                    {
                        S[i] = null; S.RemoveAt(i);
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        CursorX = e.X;
                        CursorY = e.Y;
                        switch (shapenumb)
                        {
                            case (0): S.Add(new Квадрат(CursorX, CursorY)); break;
                            case (1): S.Add(new Треугольник(CursorX, CursorY)); break;
                            case (2): S.Add(new Круг(CursorX, CursorY)); break;
                        }
                    i++;
                    S[i].Point = new Point(CursorX, CursorY);
                }
                    Draw = true;    
                }
            Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            квадратToolStripMenuItem.Checked = true;
            DoubleBuffered = true;
        }
        private void КвадратToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            shapenumb = 0;
            треугольникToolStripMenuItem.Checked = false;
            кругToolStripMenuItem.Checked = false;
        }

        private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapenumb = 1;
            квадратToolStripMenuItem.Checked = false;
            кругToolStripMenuItem.Checked = false;
        }

        private void КругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapenumb = 2;
            треугольникToolStripMenuItem.Checked = false;
            квадратToolStripMenuItem.Checked = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beingDragged)
            {
                CursorX = e.X - sdvigx;
                CursorY = e.Y - sdvigy;
                S[i].Point = new Point(CursorX, CursorY);
                Refresh();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (beingDragged)
            {
                beingDragged = false;
            }
        }
    }
}