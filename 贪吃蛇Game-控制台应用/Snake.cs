using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    enum E_Snake_Dir
    {
        Up,
        Down,
        Left,
        Right
    }

    internal class Snake : IDraw
    {
        public SnakeBody[] bodys;
        public int nowNum;
        public E_Snake_Dir dir;
        public Snake(int x, int y)
        {
            bodys = new SnakeBody[200];
            bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            nowNum = 1;

            dir = E_Snake_Dir.Right;
        }

        public void Draw()
        {
            for (int i = 0; i < nowNum; i++)
            {
                bodys[i].Draw();
            }
        }

        public void ChangeDir(E_Snake_Dir dir)
        {
            if (dir == this.dir ||
                 nowNum > 1 &&
                (this.dir == E_Snake_Dir.Left && dir == E_Snake_Dir.Right ||
                 this.dir == E_Snake_Dir.Right && dir == E_Snake_Dir.Left ||
                 this.dir == E_Snake_Dir.Up && dir == E_Snake_Dir.Down ||
                 this.dir == E_Snake_Dir.Down && dir == E_Snake_Dir.Up))
            {
                return;
            }
            this.dir = dir;
        }

        public void Move()
        {
            Console.SetCursorPosition(bodys[nowNum - 1].position.x, bodys[nowNum - 1].position.y);
            Console.Write(" ");

            for(int i = nowNum-1; i > 0;  i--)
            {
                bodys[i].position = bodys[i - 1].position;
            }

            switch (dir)
            {
                case E_Snake_Dir.Left:
                    bodys[0].position.x -= 2;
                    break;
                case E_Snake_Dir.Right:
                    bodys[0].position.x += 2;
                    break;
                case E_Snake_Dir.Up:
                    bodys[0].position.y--;
                    break;
                case E_Snake_Dir.Down:
                    bodys[0].position.y++;
                    break;
            }
        }

        public bool isCheckBorder(Map map)
        {
            for(int i = 0; i < map.walls.Length; i++)
            {
                if(map.walls[i].position == bodys[0].position)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckFood(Food food)
        {
            if (bodys[0].position == food.position)
            {
                food.RandomPos(this);
                AddBody();
            }
        }
        public void AddBody()
        {
            SnakeBody body = bodys[nowNum - 1];
            bodys[nowNum] = new SnakeBody(E_SnakeBody_Type.Body, body.position.x, body.position.y);
            nowNum++;
        }

        public bool isCheckSamePos(Food food)
        {
            for (int i = 0; i < nowNum; i++)
            {
                if (bodys[i].position == food.position) return true;
            }
            return false;
        }
    }
}
