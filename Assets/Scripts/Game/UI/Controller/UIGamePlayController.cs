using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Controller
{
    public class UIGamePlayController: BasePanel
    {
        private static string name = "UIGamePlay";
        private static string path = "UI/Prefab/UIGamePlay";
        public static readonly UIType uitype = new UIType(path, name);
        
        public UIGamePlayController() : base(uitype)
        {
        }
        
        public override void OnStart()
        {
            base.OnStart();
        }

    }
}
