using Game.UI.Controller;
using GeoGame.Localization;
using Scene;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;

    private UIManager1 UIManager;

    public UIManager1 UIManager_Root;

    private SceneControl SceneControl;
    public SceneControl SceneControl_Root { get => SceneControl; }
    public LocalizationManager localizationManager;

    public static GameRoot GetInstance() 
    {
        if (instance == null)  
        {
            Debug.LogWarning("GameRoot Ins is false!");
            return instance;
        }

        return instance;
    }

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }

        UIManager = new UIManager1();
        UIManager_Root = UIManager;
        SceneControl = new SceneControl();
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        UIObjFinder.Show();
#endif
        GameObject.Instantiate(localizationManager, this.transform);
        DontDestroyOnLoad(this);
        UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();

        #region StartScene设置

        SceneControl_Root.dict_scene.Add("Scene1", new Scene1());
        UIManager_Root.Push(new Scene1Panel());

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

