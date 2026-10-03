using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class Wall : GameObject
    {
        public Wall(int x, int y)
        {
            position = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
    }
}
