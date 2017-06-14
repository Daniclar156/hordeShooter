using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace hordeShooter
{
    public class Monster
    {
        public int x, y, speed, health, width, height;

        public Monster(int _x, int _y, int _width, int _height, int _speed, int _health)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            health = _health;
        }

        public void move()
        {
            if (GameScreen.relativeX > x) { x+= speed;}
            if(GameScreen.relativeX < x) { x-= speed;}

            if (GameScreen.relativeY > y) { y+= speed;}

            if (GameScreen.relativeY < y) { y-= speed;}
        }


        public Boolean hit(Bullet b)//monster hit method
        {
            int xDif = x - GameScreen.relativeX;
            int yDif = y - GameScreen.relativeY;

            Rectangle monsterRec = new Rectangle(1366 / 2 + xDif, 768 / 2 + yDif, width, height);
            Rectangle bulletRec = new Rectangle(Convert.ToInt16(b.x), Convert.ToInt16(b.y), 6, 6);

            return monsterRec.IntersectsWith(bulletRec);
        }
    }
}
