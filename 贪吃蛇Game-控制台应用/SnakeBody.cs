using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    enum E_SnakeBody_Type
    {
        Head,
        Body
    }

    internal class SnakeBody : GameObject
    {
        public E_SnakeBody_Type type;

        public SnakeBody(E_SnakeBody_Type type,int x, int y)
        {
            this.type = type;
            position = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = type == E_SnakeBody_Type.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(type == E_SnakeBody_Type.Head ? "●" : "◎");
        }
    }
}
