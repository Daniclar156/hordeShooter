using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace hordeShooter
{
    public partial class Leaderboards : UserControl
    {
        public Leaderboards()
        {
            InitializeComponent();
            onload();
        }

        public void onload()
        {
            for (int i = 0; i == Form1.scores.Count(); i++)
            {
               // scoreList.Text += Form1.scores[i];
            }
        }

        private void Leaderboards_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           switch(e.KeyCode)
            {
                case Keys.Escape:
                    MainMenu mm = new MainMenu();
                    Form f = this.FindForm();
                    f.Controls.Add(mm);
                    f.Controls.Remove(this);
                    break;
            }
        }
    }
}
