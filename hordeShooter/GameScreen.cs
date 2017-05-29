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
    public partial class GameScreen : UserControl
    {
        //determines whether a key is being pressed or not - DO NOT CHANGE
        Boolean leftArrowDown, aKeyDown, dKeyDown, sKeyDown, rightArrowDown, wKeyDown, spaceDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        //bullet objects
        List<Bullet> bullets = new List<Bullet>();
        int bulletSpeed, bulletSize;

        //Monster objects
        List<Monster> Monsters = new List<Monster>();

        //player object
        Player p;

        int backImageX = 0, backImageY = 0;

        public GameScreen()
        {
            InitializeComponent();

            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();

            OnStart();
        }

        public void OnStart()
        {
            Form f = new Form();
            f.FindForm();
            f.TopMost = true;
            f.WindowState = FormWindowState.Maximized;

            //initial starting values for hero object
            int speedHero = 6;
            int widthHero = 20;
            int heightHero = 20;
            int heroAngle = 0;
            int heroPoints = 0;
            int xHero = this.Width / 2 - widthHero / 2;
            int yHero = this.Height - 80;

            p = new Player(xHero, yHero, speedHero, heroPoints, widthHero, heightHero, heroAngle);

            bulletSpeed = 6;
            bulletSize = 6;
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
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
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
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
                p.move("up");
                backImageY = backImageY + 8;
            }
            //move down
            if (sKeyDown)
            {
                p.move("down");
                backImageY = backImageY - 8;
            }
            //move left
            if (aKeyDown)
            {
                p.move("left");
                backImageX = backImageX + 8;
            }
            //move right
            if (dKeyDown)
            {
                p.move("right");
                backImageX = backImageX - 8;
            }

            //fire bullet
            if (spaceDown)
            {
                //theta measure for angle of fire, (float uses less memory)
                float thetaAngle = (90 - p.angle);

                // determine the end point for each hand (result must be a double)
                double xStep = Math.Cos(thetaAngle * Math.PI / 180.0);
                double yStep = Math.Sin(thetaAngle * Math.PI / 180.0);

                //bullet object requires float values to draw on screen
                Bullet b = new Bullet(p.x, p.y, bulletSize, bulletSpeed, (float)xStep, (float)-yStep);
                bullets.Add(b);
            }

            //move bullet
            foreach (Bullet b in bullets)
            {
                b.Move();
            }

            if (bullets.Count > 0)
            {
                Form f = new Form();
                f.FindForm();
                //Use the OffScreen method from the first bullet since we know it exists.
                bullets[0].OffScreen(bullets, f);
            }

            //paint the screen
            Refresh();
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
            e.Graphics.FillRectangle(drawBrush, 0 - p.width / 2, 0 - p.width / 2, p.width, p.height);

            //reset to original origin point
            e.Graphics.ResetTransform();

            foreach (Bullet b in bullets)
            { 
                e.Graphics.FillEllipse(drawBrush,
                    b.x + p.width / 2 - bulletSize / 2, b.y + p.height / 2 - bulletSize / 2,
                    bulletSize, bulletSize);
            }
        }
    }
}
