using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class Map : IDraw
    {
        public Wall[] walls;
        public Map()
        {
            walls = new Wall[Game.w + (Game.h - 2) * 2];
            int wallIndex = 0;
            for (int i = 0 ; i < Game.w; i+=2)
            {
                walls[wallIndex] = new Wall(i, 0);
                wallIndex++;
            }
            for (int i = 0; i < Game.w; i += 2)
            {
                walls[wallIndex] = new Wall(i, Game.h-1);
                wallIndex++;
            }
            for (int i = 1; i < Game.h - 1; i++)
            {
                walls[wallIndex] = new Wall(0, i);
                ++wallIndex;
            }

            for (int i = 1; i < Game.h - 1; i++)
            {
                walls[wallIndex] = new Wall(Game.w - 2, i);
                ++wallIndex;
            }
        }
        public void Draw()
        {
            for(int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
