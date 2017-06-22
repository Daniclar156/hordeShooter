using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hordeShooter
{
    public partial class MainMenu : UserControl
    {
        //index for menu items
        int index = 0;
        int lastIndex = 0;

        public MainMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            playLabel.BackColor = Color.Red;
        }

        private void MainMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;
            Form form = this.FindForm();
            //to make sure that if you click to the bottom or top you will go to the other end instead of just stopping
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (index != 0)
                        index--;
                    else
                    {
                        index = 1;
                    }
                    break;
                case Keys.Down:
                    if (index != 1)
                        index++;
                    else
                    {
                        index = 0;
                    }
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;

                case Keys.Space:
                    switch (index)
                    {
                        //start button
                        case 0:
                            GameScreen gs = new GameScreen();

                            form.Controls.Add(gs);
                            form.Controls.Remove(this);

                            break;

                        //highscore button
                        case 1:
                            Leaderboards lb = new Leaderboards();
                            form.Controls.Add(lb);
                            form.Controls.Remove(this);
                            break;                    
                    }
                    break;
            }

            switch (lastIndex)
            {
                case 0:
                    playLabel.BackColor = Color.Black;
                    break;
                case 1:
                    leaderboardsLabel.BackColor = Color.Black;
                    break;
            }

            switch (index)
            {
                case 0:
                    playLabel.BackColor = Color.Red;
                    break;
                case 1:
                    leaderboardsLabel.BackColor = Color.Red;
                    break;
            }
        }
    }
}
