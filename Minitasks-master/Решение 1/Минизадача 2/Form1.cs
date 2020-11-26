using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Минизадача_2
{
    public partial class Form1 : Form
    {
        Вершины S;
        Point p;
        int CursorX;
        int CursorY;
        int shapenumb;
        bool beingDragged;
        bool Draw;
        int sdvigx;
        int sdvigy;
        public Form1()
        {
            InitializeComponent();
            квадратToolStripMenuItem.CheckOnClick = true;
            треугольникToolStripMenuItem.CheckOnClick = true;
            кругToolStripMenuItem.CheckOnClick = true;
            квадратToolStripMenuItem.Checked = true;
            S = new Квадрат(ClientSize.Width/2, ClientSize.Height / 2);
            beingDragged = false;
            Draw = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;
            e.Graphics.Clear(BackColor);
            if (Draw)
            {
                S.Point = new Point(CursorX, CursorY);
                S.DrawFigure(graf);
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(Draw && S.CheckArea(e.X, e.Y))
            {
                if(e.Button == MouseButtons.Left)
                {
                    sdvigx = e.X - S.Point.X;
                    sdvigy = e.Y - S.Point.Y;
                    beingDragged = true;
                }
                if (e.Button == MouseButtons.Right)
                {
                    S = null; Draw = false;
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
                        case (0): S = new Квадрат(CursorX, CursorY);  break;
                        case (1): S = new Треугольник(CursorX, CursorY); break;
                        case (2): S = new Круг(CursorX, CursorY); break;
                        default: S = new Круг(CursorX, CursorY); break;
                    }
                }
                Draw = true;
            }
            DoubleBuffered = true;
            Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            квадратToolStripMenuItem.Checked = true;
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
            if(beingDragged)
            {
                CursorX = e.X - sdvigx;
                CursorY = e.Y - sdvigy;
                DoubleBuffered = true;
                Refresh();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (beingDragged)
            {
                beingDragged = false;
                DoubleBuffered = true;
                Refresh();
            }
        }
    }
}


