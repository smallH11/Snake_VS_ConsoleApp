using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene()
        {
            strTitle = "贪吃蛇大作战";
            strSelectedOne = "开始游戏";
        }
        public override void EnterJDoSomething()
        {
            if(nowSelectedIndex == 0)
            {
                Game.ChangeScene(E_Scene_Type.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
