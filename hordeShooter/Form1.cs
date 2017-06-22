using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace hordeShooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<string> scores = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            Form f = new Form();
            f = this.FindForm();

            MainMenu mm = new MainMenu();
            f.Controls.Add(mm);
            f.Controls.Remove(this);
        }
    }
}
