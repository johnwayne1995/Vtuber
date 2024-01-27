using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioType[] AudioTypes;
    private string BgmName = "BGM";
    private string ClickEffectName = "Effect";
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("UIManager is not exist");
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (var type in AudioTypes)
        {
            type.Source = gameObject.AddComponent<AudioSource>();

            type.Source.clip = type.Clip;
            type.Source.name = type.Name;
            type.Source.volume = type.Volume;
            type.Source.pitch = type.Pitch;
            type.Source.loop = type.Loop;

            if (type.Group != null)
            {
                type.Source.outputAudioMixerGroup = type.Group;
            }
        }
        
        Get(BgmName).Source.volume = 1;
        Get(ClickEffectName).Source.volume = 1;
        // Get(BgmName).Source.volume = float.Parse(UserSettings.GetInstance().GetSetting("Bgm"));
        // Get(ClickEffectName).Source.volume = float.Parse(UserSettings.GetInstance().GetSetting("musicEffect"));
        PlayBGM();
    }

    public AudioType Get(string name)
    {
        foreach (var type in AudioTypes)
        {
            if (type.Name == name)
            {
                return type;
            }
        }
        Debug.Log("没有找到"+name+"素材");
        return null;
    }
    
    public void PlayBGM()
    {
        Play(BgmName);
    }
    
    public void PlayClickEffect()
    {
        Play(ClickEffectName);
    }
    
    public void Play(string name)
    {
        foreach (var type in AudioTypes)
        {
            if (type.Name == name)
            {
                type.Source.Play();
                return;
            }
        }
        Debug.Log("没有找到"+name+"素材");
    }

    public void Pause(string name)
      {
        foreach (var type in AudioTypes)
        {
            if (type.Name == name)
            {
                type.Source.Pause();
                return;
            }
        }
        Debug.Log("没有找到"+name+"素材");
    }

    public void Stop(string name)
    {
        foreach (var type in AudioTypes)
        {
            if (type.Name == name)
            {
                type.Source.Stop();
                return;
            }
        }
        Debug.Log("没有找到"+name+"素材");
    }
}
