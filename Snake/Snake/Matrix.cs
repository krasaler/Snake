using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public class Matrix : PictureBox
    {
        protected int iMax;
        protected int jMax;
        protected int N;
        protected int[,] matrix;
        protected Image bmp;
        protected Image bmp2;
        protected Pen pen;
        protected Font font;
        protected Graphics g;
        protected Graphics displayGraphics;

        public Matrix(int a,Control parents)
        {
            Width = parents.Width;
            Height = parents.Height;
            Dock = DockStyle.Fill;
            Parent = parents;
            N = a;
            iMax = Width / N;
            jMax = Height / N;
            matrix = new int[iMax, jMax];
            bmp = new Bitmap(Width, Height);
            pen = new Pen(Color.White,N);
            font = new Font("Times New Roman", 10, FontStyle.Regular);
            g = Graphics.FromImage(bmp);

            bmp2 = new Bitmap(Width, Height);
            displayGraphics = Graphics.FromImage(bmp2);
            Image = bmp2;
        }
        public void draw(int i, int j, Color Colors)
        {
            pen.Color = Colors;
            int x, y;
            x = i * N;// +i;
            y = j * N + N / 2;// +j + N / 2;
            g.DrawLine(pen, x, y, x + N, y);
            Refresh();
        }

        public void size()
        {
            iMax = ClientRectangle.Width / N;
            jMax = ClientRectangle.Height / N;
            matrix = new int[jMax, iMax];
            for (int i = 1; i < iMax; i++)
                for (int j = 0; j < jMax; j++)
                    matrix[i, j] = 0;
        }
    }
}
