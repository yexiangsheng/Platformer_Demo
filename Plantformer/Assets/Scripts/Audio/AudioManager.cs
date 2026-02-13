using UnityEditorInternal;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource audioSource;

    const float MIN_PITCH = 0.9f;
    const float MAX_PITCH = 1.1f;

    //Used for UI SFX
    public void PlaySFX(AudioData audioData)
    {
        //该函数不会覆盖正在播放中的其他音频
        audioSource.PlayOneShot(audioData.audioClip, audioData.volume);
    }
    //Used for repeat-play SFX
    public void PlayRandomSFX(AudioData audioData)
    {
        audioSource.pitch = Random.Range(MIN_PITCH, MAX_PITCH);
        PlaySFX(audioData);
    }
    //Used for select one SFX from many SFX
    public void PlayerRandomSFX(AudioData[] audioDatas)
    {
        PlayRandomSFX(audioDatas[Random.Range(0, audioDatas.Length)]);
    }
}
