using UnityEngine;
using UnityEngine.UI;

public class UIGamePlayController : BasePanel
{
    private static string name = "UIGamePlayController";
    private static string path = "UI/Prefab/UIGamePlayController";
    public static readonly UIType uitype = new UIType(path, name);
    
    public UIGamePlayController() : base(uitype)
    {
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Restart").onClick.AddListener(OnRestart);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Next").onClick.AddListener(OnNext);
    }

    private void OnNext()
    {
        Debug.Log("OnClickNext");
    }

    private void OnRestart()
    {
        Debug.Log("OnClickRestartDebug");
    }
}

