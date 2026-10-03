using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class GameScene : ISceneUpdate
    {
        int updateIndex = 0;

        Map map;
        Snake snake;
        Food food;
        public GameScene()
        {
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);
        }
        public void Update()
        {
            if(updateIndex % 5000 == 0)
            {
                map.Draw();
                food.Draw();

                snake.Move();
                snake.Draw();

                if(snake.isCheckBorder(map))
                {
                    Game.ChangeScene(E_Scene_Type.End);
                }

                snake.CheckFood(food);

                updateIndex = 1;
            }
            updateIndex++;

            if(Console.KeyAvailable)
            {
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_Snake_Dir.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_Snake_Dir.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_Snake_Dir.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_Snake_Dir.Right);
                        break;
                }
            }
        }
    }
}
