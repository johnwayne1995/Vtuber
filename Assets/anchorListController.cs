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
    private float lastTime;
    private float duration = 1;
    private int anchorIndex;
    private int anchorCount;
    private AnimationCurve curve;
    public Track track;

    // Start is called before the first frame update
    void Start()
    {
        anchorCount = anchorList.Count;
        lastTime = Time.fixedTime;
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
            return;
        }
        Dialog.gameObject.SetActive(false);
        Dialog.gameObject.SetActive(true);
        duration = track.TrackClips[anchorIndex].triggerTime - (anchorIndex == 0 ? 0 : track.TrackClips[anchorIndex - 1].triggerTime);
        
        // 更新经过的时间
        float elapsedTime = Time.time - lastTime;

        // 计算当前时间点的插值比例
        float t = anchorIndex == 0 ? 0 : elapsedTime / duration;
        
        float value = anchorIndex == 0 ? 0 : Mathf.PingPong((elapsedTime) / (0.5f * duration), 1f);
        float gapNext = anchorList[(anchorIndex + 1) % anchorCount].position.x - anchorList[anchorIndex % anchorCount].position.x ;
        indicator.transform.position =  new Vector3(anchorList[anchorIndex % anchorCount].position.x + gapNext * t, anchorList[0].position.y+100+value * 20f);
        if(Time.fixedTime - lastTime > duration)
        {
            anchorIndex++;
            lastTime = Time.fixedTime;
            if(anchorIndex + 1 < anchorCount)
                SetUnTransParent(anchorList[anchorIndex].GetComponent<Text>());
            Debug.Log("RefreshUI");
        }
    }
}
