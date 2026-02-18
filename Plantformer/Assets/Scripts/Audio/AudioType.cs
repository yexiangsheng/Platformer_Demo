using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class AudioType
{
    [HideInInspector]
    public AudioSource Source;

    public AudioClip Clip;
    public AudioMixerGroup Group;

    public string Name;
    public float Volume;
    public float Pitch;
    public bool isLoop;
}
