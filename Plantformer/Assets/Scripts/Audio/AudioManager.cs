using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioType[] audioTypes;

    public Dictionary<string, AudioSource> audioDict = new Dictionary<string, AudioSource>();

    private void Start()
    {
        foreach (AudioType type in audioTypes)
        {
            type.Source = gameObject.AddComponent<AudioSource>();
            
            type.Source.clip = type.Clip;
            type.Source.name = type.Name;
            type.Source.volume = type.Volume;
            type.Source.pitch = type.Pitch;
            type.Source.loop = type.isLoop;

            if (type.Group is not null)
            {
                type.Source.outputAudioMixerGroup = type.Group;
            }

            if (!audioDict.ContainsKey(type.Source.name))
            {
                audioDict.Add(type.Source.name, type.Source);
            }
        }
    }

    #region 基础功能
    public void Play(string name)
    {
        if (audioDict.TryGetValue(name, out AudioSource audioSource))
        {
            audioDict[name].PlayOneShot(audioSource.clip);
        }
        else 
        {
            Debug.Log("不存在" + name);
        }
    }
    public void Pause(string name)
    {
        if (audioDict.ContainsKey(name))
        {
            audioDict[name].Pause();
        }
        else
        {
            Debug.Log("不存在" + name);
        }
    }
    public void Stop(string name)
    {
        if (audioDict.ContainsKey(name))
        {
            audioDict[name].Stop();
        }
        else
        {
            Debug.Log("不存在" + name);
        }
    }
    #endregion

    #region Play扩展
    public void PlayBGM(string bgmName)
    {
        if (audioDict.TryGetValue(name, out AudioSource audioSource))
        {
            audioDict[name].PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.Log("不存在" + name);
        }
    }
    public void PlaySFX(string sfxName)
    {
        if (audioDict.TryGetValue(name, out AudioSource audioSource))
        {
            audioDict[name].PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.Log("不存在" + name);
        }
    }
    public void PlayUIEffect(string uiName)
    {
        if (audioDict.TryGetValue(name, out AudioSource audioSource))
        {
            audioDict[name].PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.Log("不存在" + name);
        }
    }
    #endregion
}