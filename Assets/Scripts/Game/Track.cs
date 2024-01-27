using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Track", menuName = "ScriptableObjects/Track")]
public class Track : ScriptableObject
{
    [SerializeField]
    public List<TrackClip> TrackClips=new List<TrackClip>();
}

[Serializable]
public class TrackClip
{
    public float triggerTime;
    public string word;
    public bool isHide;
}
