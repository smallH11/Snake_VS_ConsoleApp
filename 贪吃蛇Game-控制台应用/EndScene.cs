using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    internal class EndScene : BeginOrEndBaseScene
    {
        public EndScene()
        {
            strTitle = "游戏结束";
            strSelectedOne = "回到主界面";
        }
        public override void EnterJDoSomething()
        {
            if(nowSelectedIndex == 0)
            {
                Game.ChangeScene(E_Scene_Type.Begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
