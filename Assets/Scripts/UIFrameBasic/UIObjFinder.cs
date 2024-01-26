using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObjFinder : MonoBehaviour
{
    private static UIObjFinder _;

    public List<RaycastResult> _ray_list;
    public HashSet<string> IgnoreNames = new HashSet<string>()
    {
        //"ScreenArea"
    };
    public static void Show()
    {
        if (!Application.isPlaying)
            return;

        if (_ != null)
            return;

        GameObject obj = new GameObject("UIObjFinder");
        obj.hideFlags = HideFlags.HideInHierarchy;
        _ = obj.AddComponent<UIObjFinder>();
        Object.DontDestroyOnLoad(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LateUpdate()
    {
        //1. 检查
        if (!_get_mouse_input(out var mouse_pos))
            return;
        var event_system = EventSystem.current;
        if (event_system == null || !event_system.IsPointerOverGameObject())
            return;

        //2. 拼装 Event Data
        var event_data = new PointerEventData(event_system);
        event_data.pressPosition = mouse_pos;
        event_data.position = mouse_pos;

        //3. 获取所有的raycast list
        if (_ray_list == null)
            _ray_list = new List<RaycastResult>();
        _ray_list.Clear();
        event_system.RaycastAll(event_data, _ray_list);

        //4. 找到目标
        GameObject tar = _find(_ray_list, IgnoreNames);
        _ray_list.Clear();

        //5. 选中
        if (tar != null)
        {
            UnityEditor.EditorGUIUtility.PingObject(tar);
            UnityEditor.Selection.activeGameObject = tar;
        }
    }
    
    public GameObject _find(List<UnityEngine.EventSystems.RaycastResult> list, HashSet<string> ignore_set)
    {
        foreach (var p in list)
        {
            if (p.gameObject == null)
                continue;
            if (ignore_set.Count > 0 && ignore_set.Contains(p.gameObject.name))
                continue;
            return p.gameObject;
        }
        return null;
    }

    public bool _get_mouse_input(out Vector3 pos)
    {
        pos = Vector3.zero;
        var m = UnityEngine.InputSystem.Mouse.current;
        if (m == null)
            return false;
        if (m.middleButton.wasPressedThisFrame)
        {
            pos = m.position.ReadValue();
            return true;
        }
        return false;
    }
}
