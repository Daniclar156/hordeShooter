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
    public partial class gameoverScreen : UserControl
    {
        public gameoverScreen()
        {
            InitializeComponent();
            scorelabel.Text = GameScreen.score.ToString();
        }

        int index = 1;
        int letterIndex1 = 0;
        int letterIndex2 = 0;
        int letterIndex3 = 0;
        bool upKeyDown, downKeyDown, rightKeyDown, leftKeyDown, spaceDown;

        private void gameoverScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //index = 1;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKeyDown = true;
                    break;
                case Keys.Down:
                    downKeyDown = true;
                    break;
                case Keys.Right:
                    rightKeyDown = true;
                    if (index < 6)
                    {
                        index++;
                    }

                    break;
                case Keys.Left:
                    leftKeyDown = true;
                    if (index > 0)
                    {
                        index--;
                    }
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
            }

            //selection
            if (letterIndex1 == -1)
            {
                letterIndex1++;
            }
            if (letterIndex2 == -1)
            {
                letterIndex2++;
            }
            if (letterIndex3 == -1)
            {
                letterIndex3++;
            }
            if (index == 1 && upKeyDown)
            {
                letterIndex1--;
            }
            if (index == 2 && upKeyDown)
            {
                letterIndex2--;
            }
            if (index == 3 && upKeyDown)
            {
                letterIndex3--;
            }
            if (index == 1 && downKeyDown)
            {
                letterIndex1++;
            }
            if (index == 2 && downKeyDown)
            {
                letterIndex2++;
            }
            if (index == 3 && downKeyDown)
            {
                letterIndex3++;
            }
            if (letterIndex1 == 26)
            {
                letterIndex1--;
            }
            if (letterIndex2 == 26)
            {
                letterIndex2--;
            }
            if (letterIndex3 == 26)
            {
                letterIndex3--;
            }

            if (index == 1)
            {
                changeable1.BackColor = Color.Red;
                changeable2.BackColor = Color.Silver;
                changeable3.BackColor = Color.Silver;
            }
            if (index == 2)
            {
                changeable1.BackColor = Color.Silver;
                changeable2.BackColor = Color.Red;
                changeable3.BackColor = Color.Silver;
            }
            if (index == 3)
            {
                changeable1.BackColor = Color.Silver;
                changeable2.BackColor = Color.Silver;
                changeable3.BackColor = Color.Red;
                quitToMenu.BackColor = Color.Black;
            }
            if (index == 4)
            {
                changeable3.BackColor = Color.Silver;
                quitToMenu.BackColor = Color.Red;
                quitToLeaderboards.BackColor = Color.Black;
                retry.BackColor = Color.Black;
            }
            if (index == 5)
            {
                quitToMenu.BackColor = Color.Black;
                quitToLeaderboards.BackColor = Color.Red;
                retry.BackColor = Color.Black;
            }
            if (index == 6)
            {
                quitToMenu.BackColor = Color.Black;
                quitToLeaderboards.BackColor = Color.Black;
                retry.BackColor = Color.Red;
            }

            //change letters
            switch (letterIndex1)
            {
                case 0:
                    changeable1.Text = "A";
                    break;
                case 1:
                    changeable1.Text = "B";
                    break;
                case 2:
                    changeable1.Text = "C";
                    break;
                case 3:
                    changeable1.Text = "D";
                    break;
                case 4:
                    changeable1.Text = "E";
                    break;
                case 5:
                    changeable1.Text = "F";
                    break;
                case 6:
                    changeable1.Text = "G";
                    break;
                case 7:
                    changeable1.Text = "H";
                    break;
                case 8:
                    changeable1.Text = "I";
                    break;
                case 9:
                    changeable1.Text = "J";
                    break;
                case 10:
                    changeable1.Text = "K";
                    break;
                case 11:
                    changeable1.Text = "L";
                    break;
                case 12:
                    changeable1.Text = "M";
                    break;
                case 13:
                    changeable1.Text = "N";
                    break;
                case 14:
                    changeable1.Text = "O";
                    break;
                case 15:
                    changeable1.Text = "P";
                    break;
                case 16:
                    changeable1.Text = "Q";
                    break;
                case 17:
                    changeable1.Text = "R";
                    break;
                case 18:
                    changeable1.Text = "S";
                    break;
                case 19:
                    changeable1.Text = "T";
                    break;
                case 20:
                    changeable1.Text = "U";
                    break;
                case 21:
                    changeable1.Text = "V";
                    break;
                case 22:
                    changeable1.Text = "W";
                    break;
                case 23:
                    changeable1.Text = "X";
                    break;
                case 24:
                    changeable1.Text = "Y";
                    break;
                case 25:
                    changeable1.Text = "Z";
                    break;
            }

            switch (letterIndex2)
            {
                case 0:
                    changeable2.Text = "A";
                    break;
                case 1:
                    changeable2.Text = "B";
                    break;
                case 2:
                    changeable2.Text = "C";
                    break;
                case 3:
                    changeable2.Text = "D";
                    break;
                case 4:
                    changeable2.Text = "E";
                    break;
                case 5:
                    changeable2.Text = "F";
                    break;
                case 6:
                    changeable2.Text = "G";
                    break;
                case 7:
                    changeable2.Text = "H";
                    break;
                case 8:
                    changeable2.Text = "I";
                    break;
                case 9:
                    changeable2.Text = "J";
                    break;
                case 10:
                    changeable2.Text = "K";
                    break;
                case 11:
                    changeable2.Text = "L";
                    break;
                case 12:
                    changeable2.Text = "M";
                    break;
                case 13:
                    changeable2.Text = "N";
                    break;
                case 14:
                    changeable2.Text = "O";
                    break;
                case 15:
                    changeable2.Text = "P";
                    break;
                case 16:
                    changeable2.Text = "Q";
                    break;
                case 17:
                    changeable2.Text = "R";
                    break;
                case 18:
                    changeable2.Text = "S";
                    break;
                case 19:
                    changeable2.Text = "T";
                    break;
                case 20:
                    changeable2.Text = "U";
                    break;
                case 21:
                    changeable2.Text = "V";
                    break;
                case 22:
                    changeable2.Text = "W";
                    break;
                case 23:
                    changeable2.Text = "X";
                    break;
                case 24:
                    changeable2.Text = "Y";
                    break;
                case 25:
                    changeable2.Text = "Z";
                    break;
            }

            switch (letterIndex3)
            {
                case 0:
                    changeable3.Text = "A";
                    break;
                case 1:
                    changeable3.Text = "B";
                    break;
                case 2:
                    changeable3.Text = "C";
                    break;
                case 3:
                    changeable3.Text = "D";
                    break;
                case 4:
                    changeable3.Text = "E";
                    break;
                case 5:
                    changeable3.Text = "F";
                    break;
                case 6:
                    changeable3.Text = "G";
                    break;
                case 7:
                    changeable3.Text = "H";
                    break;
                case 8:
                    changeable3.Text = "I";
                    break;
                case 9:
                    changeable3.Text = "J";
                    break;
                case 10:
                    changeable3.Text = "K";
                    break;
                case 11:
                    changeable3.Text = "L";
                    break;
                case 12:
                    changeable3.Text = "M";
                    break;
                case 13:
                    changeable3.Text = "N";
                    break;
                case 14:
                    changeable3.Text = "O";
                    break;
                case 15:
                    changeable3.Text = "P";
                    break;
                case 16:
                    changeable3.Text = "Q";
                    break;
                case 17:
                    changeable3.Text = "R";
                    break;
                case 18:
                    changeable3.Text = "S";
                    break;
                case 19:
                    changeable3.Text = "T";
                    break;
                case 20:
                    changeable3.Text = "U";
                    break;
                case 21:
                    changeable3.Text = "V";
                    break;
                case 22:
                    changeable3.Text = "W";
                    break;
                case 23:
                    changeable3.Text = "X";
                    break;
                case 24:
                    changeable3.Text = "Y";
                    break;
                case 25:
                    changeable3.Text = "Z";
                    break;
            }

            //presses
            if (spaceDown && index == 4)
            {
                MainMenu mm = new MainMenu();
                Form f = this.FindForm();
                f.Controls.Add(mm);
                f.Controls.Remove(this);
                //write score to list
                Form1.scores.Add(changeable1.Text + changeable2.Text + changeable3.Text + ": " + scorelabel.Text);
            }
            if (spaceDown && index == 5)
            {
                Leaderboards lb = new Leaderboards();
                Form f = this.FindForm();
                f.Controls.Add(lb);
                f.Controls.Remove(this);
                //write score to list
                Form1.scores.Add(changeable1.Text + changeable2.Text + changeable3.Text + ": " + scorelabel.Text);

            }
            if (spaceDown && index == 6)
            {
                GameScreen gs = new GameScreen();
                Form f = this.FindForm();
                f.Controls.Add(gs);
                f.Controls.Remove(this);
                //write score to list
                Form1.scores.Add(changeable1.Text + changeable2.Text + changeable3.Text + ": " + scorelabel.Text);
            }
        }

        private void gameoverScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKeyDown = false;
                    break;
                case Keys.Down:
                    downKeyDown = false;
                    break;
                case Keys.Right:
                    rightKeyDown = false;
                    break;
                case Keys.Left:
                    leftKeyDown = false;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
            }
        }
    }
}
