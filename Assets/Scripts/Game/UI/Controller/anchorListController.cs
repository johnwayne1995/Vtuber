using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anchorListController : MonoBehaviour
{
    public Image indicator;
    public RectTransform Dialog;
    public List<Transform> anchorList;
    private Vector2 indicatorPos;
    private float beginTime;
    private float duration = 1;
    private int anchorIndex;
    private int anchorCount;
    private AnimationCurve curve;
    public Track track;
    private int lineProgress;
    private int BPM = 120;
    private float addTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        anchorCount = anchorList.Count;
        beginTime = Time.fixedTime;
        lineProgress = 1;
        var index = 0;
        foreach (var clip in track.TrackClips)
        {
            if(index != 0 )
                SetTransParent(anchorList[index].GetComponent<Text>());
            anchorList[index++].GetComponent<Text>().text = clip.word;
        }
        indicator.transform.position = new Vector3(anchorList[0].position.x, anchorList[0].position.y);
        indicatorPos = new Vector2(indicator.transform.position.x, indicator.transform.position.z);
        curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        EventManager.AddEvent("RestartDebug", RestartDebug);
        EventManager.AddEvent("OnNext", OnNext);
    }

    private void OnDestroy()
    {
        EventManager.RemoveEvent("RestartDebug", RestartDebug);
        EventManager.RemoveEvent("OnNext", OnNext);
    }

    private void OnNext()
    {
        Debug.Log(lineProgress);
        track = Resources.Load<Track>("Track"+(lineProgress+1));
        if (track == null)
        {
            Debug.LogWarning("结束了");
            EventManager.DispatchEvent("GameOver");
            return;
        }

        lineProgress++;
        addTime = 0;
        var index = 0;
        foreach (var clip in track.TrackClips)
        {
            if(index != 0 )
                SetTransParent(anchorList[index].GetComponent<Text>());
            anchorList[index++].GetComponent<Text>().text = clip.word;
        }
        anchorCount = track.TrackClips.Count;
        RestartDebug();
    }

    private void RestartDebug()
    {
        anchorIndex = 0;
    }

    private void SetTransParent(Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    private void SetUnTransParent(Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (anchorIndex + 1 == anchorCount)
        {
            OnNext();
            return;
        }
        Dialog.gameObject.SetActive(false);
        Dialog.gameObject.SetActive(true);
        duration = track.TrackClips[anchorIndex + 1].triggerTime -
                   track.TrackClips[anchorIndex].triggerTime;
        duration = duration * 60.0f / BPM;
        // 更新经过的时间
        float elapsedTime = Time.fixedTime - (beginTime + (lineProgress - 1)* 4 * 60f / BPM + addTime);

        // 计算当前时间点的插值比例
        float t = elapsedTime / duration;
        
        float value = Mathf.PingPong((elapsedTime), duration * 0.5f);
        if(anchorIndex == 0)
            value = Mathf.PingPong((elapsedTime) + duration, duration);
        if(anchorIndex == track.TrackClips.Count - 2)
            value = Mathf.PingPong((elapsedTime), duration);
        float gapNext = anchorList[(anchorIndex + 1) % anchorCount].position.x - anchorList[anchorIndex % anchorCount].position.x ;
        indicator.transform.position = new Vector3(anchorList[anchorIndex % anchorCount].position.x + gapNext * t,
            anchorList[0].position.y + 100 + value * 100f);
        if(elapsedTime > duration)
        {
            addTime += duration;
            anchorIndex++;
            if(anchorIndex + 1 < anchorCount)
                SetUnTransParent(anchorList[anchorIndex].GetComponent<Text>());
            if(anchorIndex == 1)
                Debug.Log("Begin:"+Time.fixedTime);
        }
    }
}
