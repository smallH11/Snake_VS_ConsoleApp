using System;
using System.Collections.Generic;
using System.Text;

namespace 贪吃蛇Game_控制台应用
{
    enum E_Scene_Type
    {
        Begin,
        Game,
        End
    }

    class Game
    {
        public const int w = 80, h = 20;
        public static ISceneUpdate sceneUpdate;
        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);

            ChangeScene(E_Scene_Type.Begin);
        }

        public void Start()
        {
            while(true)
            {
                sceneUpdate.Update();
            }
        }

        public static void ChangeScene(E_Scene_Type SceneType)
        {
            Console.Clear();
            switch (SceneType)
            {
                case E_Scene_Type.Begin:
                    sceneUpdate = new BeginScene();
                    break;
                case E_Scene_Type.Game:
                    sceneUpdate = new GameScene();
                    break;
                case E_Scene_Type.End:
                    sceneUpdate = new EndScene();
                    break;
            }

        }
    }
}
