using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    struct Position
    {
        public int x; 
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Position left, Position right)
        {
            if (left.x == right.x && left.y == right.y)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Position left, Position right)
        {
            if (left.x == right.x && left.y == right.y)
            {
                return false;
            }
            return true;
        }
    }
}
