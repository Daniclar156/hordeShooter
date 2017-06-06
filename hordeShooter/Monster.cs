using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hordeShooter
{
    class Monster
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

        public void hitPlayer(List<Monster> Monsters, Player p)
        {
            foreach (Monster m in Monsters)
            {
                if(m.x == GameScreen.relativeX && m.y == GameScreen.relativeY)
                {
                    p.health--;
                }
            }
        }

        public void move()
        {
            if (GameScreen.relativeX > x) { x+= speed;}
            if(GameScreen.relativeX < x) { x-= speed;}

            if (GameScreen.relativeY > y) { y+= speed;}

            if (GameScreen.relativeY < y) { y-= speed;}
        }
    }
}
