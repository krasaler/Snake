using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Snake
{
    public class Base : Snake
    {
        private int score;
        Timer t;
        
        public Base(int a, Control parents)
            : base(a,parents)
        {
            score = 0;
            parents.KeyDown += new KeyEventHandler(parents_KeyDown);
        }

        void parents_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case System.Windows.Forms.Keys.Left:
                    {
                        Left();
                        break;
                    }
                case System.Windows.Forms.Keys.Up:
                    {
                        Down();
                        break;
                    }
                case System.Windows.Forms.Keys.Right:
                    {
                        Rigth();
                        break;
                    }
                case System.Windows.Forms.Keys.Down:
                    {
                        Up();
                        break;
                    }

            }
        }
        public void start()
        {
            t = new Timer();
            t.Enabled = true;
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 150;
            t.Start();
            Bomb();
            Add(0, 1);
            Add(0, 2);
            Parent.Focus();
        }

        void t_Tick(object sender, EventArgs e)
        {
                switch (h)
                {
                    case 1:
                        Left();
                        break;
                    case 2:
                        Rigth();
                        break;
                    case 3:
                        Up();
                        break;
                    case 4:
                        Down();
                        break;

            }
            for (int i = 0; i < iMax; i++)
                for (int j = 0; j < jMax; j++)
                {
                    matrix[i, j] = 0;
                }
            for (int i = 0; i < SSnake; i++)
                matrix[snake[0, i], snake[1, i]] = 1;
            matrix[xBomb, yBomb] = 2;
            clearf();
            print();
            displayGraphics.DrawImage(bmp, ClientRectangle);
            Refresh();
        }

        public int Left()
        {
            if (h != 2)
            {
                int k = snake[0, 0];
                k--;
                if (k < 0)
                {
                    Game_over();
                    draw(0, snake[1, 0], Color.Black);
                    return 0;
                }
                if (k == xBomb && snake[1, 0] == yBomb)
                {
                    h = 1;
                    Add(xBomb, yBomb);
                    matrix[xBomb, yBomb] = 0;
                    Bomb();
                    score += 20;
                    Parent.Parent.Text="Игра Змея(score=" + score + ")";
                    return 0;
                }
                for (int i = 1; i >= 0; i--)
                    for (int j = SSnake - 1; j > 0; j--)
                        snake[i, j] = snake[i, j - 1];
                snake[0, 0] = k;
                if (matrix[snake[0, 0], snake[1, 0]] == 1)
                {
                    Game_over();
                    draw(snake[0, 0], snake[1, 0], Color.Black);
                    return 0;
                }
                h = 1;
            }
            else
            {
                h = 2;
            }
            return 0;
        }

        public int Rigth()
        {
            if (h != 1)
            {
                int k = snake[0, 0];
                k++;
                if (k >= (iMax))
                {
                    Game_over();
                    draw((iMax - 1), snake[1, 0], Color.Black);
                    return 0;
                }
                if (k == xBomb && snake[1, 0] == yBomb)
                {
                    h = 2;
                    Add(xBomb, yBomb);
                    Bomb();
                    score += 20;
                    Parent.Parent.Text = "Игра Змея(score=" + score + ")";
                    return 0;
                }
                for (int i = 1; i >= 0; i--)
                    for (int j = SSnake - 1; j > 0; j--)
                        snake[i, j] = snake[i, j - 1];
                snake[0, 0] = k;
                if (matrix[snake[0, 0], snake[1, 0]] == 1)
                {
                    draw(snake[0, 0], snake[1, 0], Color.Black);
                    Game_over();
                    return 0;
                }
                h = 2;
            }
            else
            {
                h = 1;
            }
            return 0;
        }

        public int Up()
        {
            if (h != 4)
            {
                int k = snake[1, 0];
                k++;
                if (k >= (jMax))
                {
                    Game_over();
                    draw(snake[0, 0], (jMax - 1), Color.Black);
                    return 0;
                }
                if (snake[0, 0] == xBomb && k == yBomb)
                {
                    h = 3;
                    Add(xBomb, yBomb);
                    Bomb();
                    score += 20;
                    Parent.Parent.Text = "Игра Змея(score=" + score + ")";
                    return 0;
                }
                for (int i = 1; i >= 0; i--)
                    for (int j = SSnake - 1; j > 0; j--)
                        snake[i, j] = snake[i, j - 1];
                snake[1, 0] = k;
                if (matrix[snake[0, 0], snake[1, 0]] == 1)
                {
                    Game_over();
                    draw(snake[0, 0], snake[1, 0], Color.Black);
                    return 0;
                }
                h = 3;
            }
            else
            {
                h = 4;
            }
            return 0;
        }

        public int Down()
        {
            if (h != 3)
            {
                int k = snake[1, 0];
                k--;
                if (k < 0)
                {
                    Game_over();
                    draw(snake[0, 0], 0, Color.Black);
                    return 0;
                }
                if (snake[0, 0] == xBomb && k == yBomb)
                {
                    h = 4;
                    Add(xBomb, yBomb);
                    Bomb();
                    score += 20;
                    Parent.Parent.Text = "Игра Змея(score=" + score + ")";
                    return 0;
                }
                for (int i = 1; i >= 0; i--)
                    for (int j = SSnake - 1; j > 0; j--)
                        snake[i, j] = snake[i, j - 1];
                snake[1, 0] = k;
                if (matrix[snake[0, 0], snake[1, 0]] == 1)
                {
                    Game_over();
                    draw(snake[0, 0], snake[1, 0], Color.Black);
                    return 0;
                }

                h = 4;
            }
            else
            {
                h = 3;
            }
            return 0;
        }

        public void Game_over()
        {
            Parent.Text = "GAME OVER(score=" + score + ")";
            t.Enabled = false;
            t.Stop();
            if (MessageBox.Show("Продолжть игру?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new_game();
            }
            else
            {
                MessageBox.Show("Ваш Score = " + score, "Предупреждение", MessageBoxButtons.OK);
                score = 0;
                SSnake = 0;
                clearf();
                displayGraphics.DrawImage(bmp, ClientRectangle);
                Refresh();
            }
        }

        public void new_game()
        {
            int i, j;
            score = 0;
            clearf();
            Parent.Parent.Text = "игра Змея(score=" + score + ")";
            SSnake = 0;
            snake = new int[2, 1];
            Add(0, 1);
            Add(0, 2);
            h = 3;
            for (i = 0; i < iMax; i++)
                for (j = 0; j < jMax; j++)
                {
                    matrix[i, j] = 0;
                }

            t.Enabled = true;
        }
    }
}
