using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hordeShooter
{
    class Monster
    {
        public int x, y, speed, health;

        public Monster(int _x, int _y, int _speed, int _health)
        {
            x = _x;
            y = _y;
            speed = _speed;
            health = _health;
        }

        public void hitPlayer(List<Monster> Monsters, Player p)
        {
            foreach (Monster m in Monsters)
            {
                if(m.x == p.x && m.y == p.y)
                {
                    p.health--;
                }
            }
        }

        public void move(Player p)
        {
            if (p.x > x) { x++; }
            else if(p.x < x) { x--; }

            if (p.y > y) { y++; }

            if (p.y < y) { y--; }
        }
    }
}
