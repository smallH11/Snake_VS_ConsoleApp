using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    abstract class GameObject : IDraw
    {
        public Position position;
        public abstract void Draw();
    }
}
