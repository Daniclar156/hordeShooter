using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hordeShooter
{
    public partial class GameScreen : UserControl
    {
        //determines whether a key is being pressed or not - DO NOT CHANGE
        Boolean leftArrowDown, aKeyDown, dKeyDown, sKeyDown, rightArrowDown, wKeyDown, spaceDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush healthBrush = new SolidBrush(Color.Red);
        Pen drawPen = new Pen(Color.Black);

        //bullet objects
        Bullet b;
        List<Bullet> bullets = new List<Bullet>();
        int bulletSpeed, bulletSize;

        //Monster objects
        Monster m;
        List<Monster> Monsters = new List<Monster>();
        int monSpeed = 5;
        Random ranPos = new Random();

        //player object
        Player p;
        public static int relativeX = 683;
        public static int relativeY = 384;
        int score = 0;

        //bgm player
        System.Windows.Media.MediaPlayer bgmPlayer;

        //round multiplyer 
        int roundMulti = 1;

        public static int backImageX = 0, backImageY = 0;

        public GameScreen()
        {
            InitializeComponent();

            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();

            bulletTimer.Enabled = true;
            bulletTimer.Start();

            bgmPlayer = new System.Windows.Media.MediaPlayer();
            bgmPlayer.Open(new Uri(Application.StartupPath + "/Resources/bgm.mp3"));
            bgmPlayer.Play();

            OnStart();
        }

        public void OnStart()
        {
            Form f = new Form();
            f.FindForm();
            f.TopMost = true;
            f.WindowState = FormWindowState.Maximized;

            //initial starting values for hero object
            int speedHero = 8;
            int turnspeedHero = 5;
            int widthHero = 40;
            int heightHero = 40;
            int heroAngle = 0;
            int heroPoints = 0;
            int xHero = 683;
            int yHero = 384;
            int healthHero = 300;
            p = new Player(xHero, yHero, speedHero, heroPoints, widthHero, heightHero, heroAngle, turnspeedHero, healthHero);

            //initial bullet values
            bulletSpeed = 5;
            bulletSize = 6;
           
        }


        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (bgmPlayer.Position == TimeSpan.Zero)
            {
                bgmPlayer.Play();
            }

            //border objects
            int topBorder = -8, bottomBorder = 1064, leftBorder = -5, rightBorder = 1900;
            #region movement
            //rotate left
            if (leftArrowDown)
            {
                p.Turn("left");
            }

            //rotate right
            if (rightArrowDown)
            {
                p.Turn("right");
            }

            //move up
            if (wKeyDown)
            {
                relativeY -= 8;
                if (relativeY > topBorder)//max top
                {
                    backImageY = backImageY + 8;
                    topBorder += 8;
                }
                else
                {
                    relativeY += 8;
                }
                foreach (Bullet b in bullets)
                {
                   b.y += 8;
                }
                foreach (Monster m in Monsters)
                {
                   m.y += 8;
                }
            }
            //move down
            if (sKeyDown)
            {
                relativeY += 8;
                if (relativeY < bottomBorder)//max bottom 
                {
                    backImageY = backImageY - 8;
                    topBorder -= 8;
                }
                else
                {
                    relativeY -= 8;
                }
                foreach (Bullet b in bullets)
                {
                   b.y -= 8;
                }
                foreach (Monster m in Monsters)
                {
                   m.y -= 8;
                }
            }
            //move left
            if (aKeyDown)
            {
                relativeX -= 8;
                if (relativeX > leftBorder)//max left 
                {
                    backImageX = backImageX + 8;
                    leftBorder += 8;
                }
                else
                {
                    relativeX += 8;
                }
                foreach (Bullet b in bullets)
                {
                   b.x += 8;
                }
                foreach (Monster m in Monsters)
                {
                   m.x += 8;
                }
            }
            //move right
            if (dKeyDown)
            {
                relativeX += 8;
                if (relativeX < rightBorder)//max right
                {
                    backImageX = backImageX - 8;
                    rightBorder -= 8;
                }
                else
                {
                    relativeX -= 8;
                }
                foreach (Bullet b in bullets)
                {
                   b.x -= 8;
                }
                foreach (Monster m in Monsters)
                {
                  m.x -= 8;
                }
            }

            foreach (Monster m in Monsters)
            {
                m.move();
            }


            //move bullet
            foreach (Bullet b in bullets)
            {
                b.Move();
            }
            #endregion

            #region collision
            //will contain index values of all bullets that have collided with a monster 
            List<int> bulletsToRemove = new List<int>();

            //will contain index values of all monsters that have collided with a bullet 
            List<int> monstersToRemove = new List<int>();
            foreach (Monster m in Monsters)
            {
                foreach (Bullet b in bullets)
                {
                    if (m.hit(b))
                    {

                        var squishPlayer = new System.Windows.Media.MediaPlayer();
                        squishPlayer.Open(new Uri(Application.StartupPath + "/Resources/squish.mp3"));
                        squishPlayer.Play();
                        if ((score % 20) == 0 && score != 0) //if score is multiple of 20
                        {
                            roundMulti++;
                            monSpeed++;
                        }

                        monstersToRemove.Add(Monsters.IndexOf(m));
                        bulletsToRemove.Add(bullets.IndexOf(b));
                    }
                }
            }

            foreach (Monster m in Monsters)
            {
                if(p.collide(m) && p.health != 0)
                {
                    p.health = p.health - 5; 
                }
                else if (p.health == 0)
                {
                    Application.Exit();
                }
            }
            //reverse list so when removing you do so from the end of the list first           
            bulletsToRemove.Reverse();
            monstersToRemove.Reverse();

            foreach (int i in bulletsToRemove)
            {
                try
                {
                    bullets.RemoveAt(i);
                }
                catch
                {
                  
                }
            }

            foreach (int i in monstersToRemove)
            {
                try
                {
                    Monsters.RemoveAt(i);
                }
                catch
                {

                }
                score = score + roundMulti;
            }

            monstersToRemove.Clear();
            bulletsToRemove.Clear();

            #endregion
            //paint the screen
            Refresh();
        }

        private void bulletTimer_Tick(object sender, EventArgs e)
        {
            //fire bullet
            if (spaceDown)//todo move into own timer
            {
                //theta measure for angle of fire, (float uses less memory)
                float thetaAngle = (0 - p.angle);

                // determine the end point for each hand (result must be a double)
                double xStep = Math.Cos(thetaAngle * Math.PI / 180.0);
                double yStep = Math.Sin(thetaAngle * Math.PI / 180.0);

                //bullet object requires float values to draw on screen
                Bullet b = new Bullet(p.x + p.width / 2 - bulletSize / 2,
                    p.y + p.height / 2 - bulletSize / 2,
                    bulletSize, bulletSpeed, (float)xStep, (float)-yStep);
                bullets.Add(b);


                var shotPlayer = new System.Windows.Media.MediaPlayer();
                shotPlayer.Open(new Uri(Application.StartupPath + "/Resources/shot.mp3"));
                shotPlayer.Play();
            }

            if (bullets.Count > 0)
            {
                //Use the OffScreen method from the first bullet since we know it exists.
                bullets[0].OffScreen(bullets, this);
            }

        }

        private void monsterTimer_Tick(object sender, EventArgs e)
        {
            //initial monster values
            int monX =  ranPos.Next(0, 1360);//rand x
            int monY = ranPos.Next(0, 760);//rand y
            
            int monHeight = 30;
            int monWidth = 30;
            int monHealth = 1;
            m = new Monster(monX, monY, monWidth, monHeight, monSpeed, monHealth);
            //todo while loop to make sure no more than correct amount of monsters per level is spawning

            Monsters.Add(m);

        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw moving background
            e.Graphics.DrawImage(Properties.Resources.lv1, backImageX, backImageY);

            //find the centre of the hero to set the origin point where rotation will happen
            e.Graphics.TranslateTransform(p.width / 2 + p.x, p.width / 2 + p.y);

            //rotate by the given angle for the hero
            e.Graphics.RotateTransform(p.angle);

            // draw the object in the middle of the rotated origin point
            e.Graphics.DrawImage(Properties.Resources.guy, 0 - p.width / 2, 0 - p.height / 2, p.width, p.height);

            //reset to original origin point
            e.Graphics.ResetTransform();

            //temp
            Font drawFont = new Font("Arial", 16);

            foreach (Bullet b in bullets)
            {
                e.Graphics.FillEllipse(drawBrush,
                    b.x, b.y,
                    bulletSize, bulletSize);
            }

            foreach (Monster m in Monsters)
            {
                int xDif = m.x - relativeX;
                int yDif = m.y - relativeY; 

                //draw monsters
                
                e.Graphics.DrawImage(Properties.Resources.enemy, Width / 2 + xDif, Height / 2 + yDif, m.width, m.height);
            }


            //player health
            e.Graphics.DrawRectangle(drawPen, 10, 728, 300, 20);

            Rectangle healthRec = new Rectangle(10, 728, p.health, 20);
            e.Graphics.FillRectangle(healthBrush, healthRec);

            //score
            e.Graphics.FillRectangle(drawBrush, 0, 0, 130, 30);
            string scoreString = "Score: " + score;
            e.Graphics.DrawString(scoreString, drawFont, healthBrush, 0, 0);
        }
    }
}
