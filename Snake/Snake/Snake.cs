using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public class Snake : Matrix
    {
        protected int xBomb;
        protected int yBomb;
        protected int h;
        protected int[,] snake;
        protected bool c;
        protected int SSnake;

        public Snake(int k, Control parents)
            : base(k,parents)
        {
            SSnake = 0;
            snake = new int[2, 2];
            h = 3;
            c = true;
        }

        public void Add(int x, int y)
        {
            int[,] buf = new int[2, SSnake];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < SSnake; j++)
                    buf[i, j] = snake[i, j];
            snake = new int[2, ++SSnake];
            snake[0, 0] = x;
            snake[1, 0] = y;
            for (int i = 0; i < 2; i++)
                for (int k = 0, j = 1; j < SSnake; k++, j++)
                    snake[i, j] = buf[i, k];
            print();
            displayGraphics.DrawImage(bmp, ClientRectangle);
        }

        public void print()
        {
            int i, j;
            for (i = 0; i < iMax; i++)
                for (j = 0; j < jMax; j++)
                {
                    if (matrix[i, j] == 1)
                        draw(i, j, System.Drawing.Color.Red);
                    if (matrix[i, j] == 2)
                        draw(i, j, System.Drawing.Color.Blue);
                }

        }

        public void clearf()
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
        }

        public void Bomb()
        {
            Random rand = new Random();
            xBomb = rand.Next(iMax - 1);
            yBomb = rand.Next(jMax - 1);
            for (int i = 0; i < SSnake; i++)
            {
                if (xBomb == snake[0, i] && yBomb == snake[1, i])
                {
                    if (xBomb != 0 && yBomb != 0)
                    {
                        xBomb = 0;
                        yBomb = 0;
                    }
                    if (xBomb != iMax - 1 && yBomb != jMax - 1)
                    {
                        xBomb = iMax - 1;
                        yBomb = jMax - 1;
                    }
                }
            }
            matrix[xBomb, yBomb] = 2;
        }
    }
}
