using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class Food : GameObject
    {
        public Food(Snake snake)
        {
            RandomPos(snake);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("★");
        }

        public void RandomPos(Snake snake)
        {
            Random random = new Random();
            int x = random.Next(2, Game.w / 2 - 1) * 2;
            int y = random.Next(1, Game.h - 2);
            position = new Position(x, y);

            if(snake.isCheckSamePos(this))
            {
                RandomPos(snake);
            }
        }
    }
}
