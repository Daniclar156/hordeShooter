using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hordeShooter
{
    public class Player
    {
        public int x, y, speed, health, points, width, height, angle;


        public Player(int _x, int _y, int _speed, int _points, int _width, int _height, int _angle)
        {
            x = _x;
            y = _y;
            speed = _speed;
            points = _points;
            width = _width;
            height = _height;
            angle = _angle;
        }

        public void Turn(string direction)
        {
            if (direction == "left")
            {
                angle -= speed;
            }
            else if (direction == "right")
            {
                angle += speed;
            }
        }
    }
}
