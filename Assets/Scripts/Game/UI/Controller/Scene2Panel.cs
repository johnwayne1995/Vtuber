using Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Controller
{
    public class Scene2Panel: BasePanel
    {
        private static string name = "Scene2Panel";
        private static string path = "UI/Prefab/Scene2Panel";
        public static readonly UIType uitype = new UIType(path, name);
        
        public Scene2Panel() : base(uitype)
        {
        }
        
        public override void OnStart()
        {
            base.OnStart();
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
            
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Restart").onClick.AddListener(OnRestart);
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Next").onClick.AddListener(OnNext);
            EventManager.AddEvent("GameOver", Back);

        }

        private void OnRestart()
        {
            Debug.Log("OnRestart");
            EventManager.DispatchEvent("RestartDebug");
        }

        private void OnNext()
        {
            Debug.Log("OnNext");
            EventManager.DispatchEvent("OnNext");
        }

        private void Back()
        {
            Debug.Log("Back");
            Scene1 scene1 = new Scene1();
            // GameRoot.GetInstance().SceneControl_Root.dict_scene.Add("Scene1", new Scene1());
            GameRoot.GetInstance().SceneControl_Root.SceneLoad(scene1.SceneName, scene1);
            GameRoot.GetInstance().UIManager_Root.Push(new Scene1Panel());
        }
    }
}
