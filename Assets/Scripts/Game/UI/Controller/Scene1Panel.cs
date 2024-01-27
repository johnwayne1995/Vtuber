using GeoGame.Localization;
using Scene;
using UnityEngine.UI;

namespace Game.UI.Controller
{
    public class Scene1Panel: BasePanel
    {
        private static string name = "Scene1Panel";
        private static string path = "UI/Prefab/Scene1Panel";
        public static readonly UIType uitype = new UIType(path, name);
        
        public Scene1Panel() : base(uitype)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Load").onClick.AddListener(Load);
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "English").onClick.AddListener(SwitchEnglish);
            UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "French").onClick.AddListener(SwitchFrench);
        }

        private void SwitchEnglish()
        {
            LocalizationManager.Instance.ChangeLanguage("english");
        }

        private void SwitchFrench()
        {
            LocalizationManager.Instance.ChangeLanguage("french");
        }

        private void Load()
        {
            // GamePlay gamePlay = new GamePlay();
            // GameRoot.GetInstance().SceneControl_Root.SceneLoad(gamePlay.SceneName, gamePlay);
            // GameRoot.GetInstance().UIManager_Root.Push(new UIGamePlayController());
            Scene2 scene2 = new Scene2();
            GameRoot.GetInstance().SceneControl_Root.SceneLoad(scene2.SceneName, scene2);
            GameRoot.GetInstance().UIManager_Root.Push(new Scene2Panel());
        }
    }
}
