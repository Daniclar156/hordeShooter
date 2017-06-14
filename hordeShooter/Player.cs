using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace hordeShooter
{
    public class Player
    {
        public int x, y, speed, health, points, width, height, angle, turnSpeed;


        public Player(int _x, int _y, int _speed, int _points, int _width, int _height, int _angle, int _turnSpeed, int _health)
        {
            x = _x;
            y = _y;
            speed = _speed;
            turnSpeed = _turnSpeed;
            points = _points;
            width = _width;
            height = _height;
            angle = _angle;
            health = _health;
        }

        public void Turn(string direction)
        {
            if (direction == "left")
            {
                angle -= turnSpeed;
            }
            else if (direction == "right")
            {
                angle += turnSpeed;
            }
        }

        public Boolean collide(Monster m)
        {
            int xDif = m.x - GameScreen.relativeX;
            int yDif = m.y - GameScreen.relativeY;

            Rectangle monsterRec = new Rectangle(1366 / 2 + xDif, 768 / 2 + yDif, 30, 30);
      
            Rectangle PlayerRec = new Rectangle(x, y, 30, 30);

            return PlayerRec.IntersectsWith(monsterRec);
        }
    }
}
