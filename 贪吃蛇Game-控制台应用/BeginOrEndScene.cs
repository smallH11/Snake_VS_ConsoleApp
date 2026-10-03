using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    abstract class BeginOrEndBaseScene : ISceneUpdate
    {
        protected string strTitle;
        protected string strSelectedOne;

        protected int nowSelectedIndex = 0;

        public abstract void EnterJDoSomething();
        public void Update()
        {
            Console.SetCursorPosition(Game.w / 2 - strTitle.Length, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(strTitle);

            Console.SetCursorPosition(Game.w / 2 - strSelectedOne.Length, 7);
            Console.ForegroundColor = nowSelectedIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(strSelectedOne);

            Console.SetCursorPosition(Game.w / 2 - 4, 9);
            Console.ForegroundColor = nowSelectedIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("退出游戏");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    nowSelectedIndex--;
                    if (nowSelectedIndex < 0) nowSelectedIndex = 0;
                    break;
                case ConsoleKey.S:
                    nowSelectedIndex++;
                    if (nowSelectedIndex > 1) nowSelectedIndex = 1;
                    break;
                case ConsoleKey.J:
                    EnterJDoSomething();
                    break;
            }

        }
    }
}
