using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Snake
{
    public partial class Form1 : Form
    {

        Base obj;
        public Form1()
        {
            InitializeComponent();
            obj = new Base(20, panel1);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void обИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 Ab = new AboutBox1();
            Ab.ShowDialog();
        }
    }
}
