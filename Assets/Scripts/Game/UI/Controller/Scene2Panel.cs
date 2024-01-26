using Scene;
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
        }

        private void Back()
        {
            Scene1 scene1 = new Scene1();
            // GameRoot.GetInstance().SceneControl_Root.dict_scene.Add("Scene1", new Scene1());
            GameRoot.GetInstance().SceneControl_Root.SceneLoad(scene1.SceneName, scene1);
            GameRoot.GetInstance().UIManager_Root.Push(new Scene1Panel());
        }
    }
}
