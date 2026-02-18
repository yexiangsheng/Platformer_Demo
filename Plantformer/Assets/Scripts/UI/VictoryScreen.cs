using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel_SO levelClearEventChannel;
    [SerializeField] AudioClip[] retryAudioClips;

    //[SerializeField] Button finishButton;

    private void OnEnable()
    {
        levelClearEventChannel.AddListener(ShowUI);

        //finishButton.onClick.AddListener(SceneLoader.LoadNextScene);
    }
    private void OnDisable()
    {
        levelClearEventChannel.RemoveListener(ShowUI);

        //finishButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
    }
    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        //随机播放retry音效
        AudioClip retryClip = retryAudioClips[Random.Range(0, retryAudioClips.Length)];
        //SoundEffectPlay.AudioSource.PlayOneShot(retryClip);

        //解锁鼠标光标
        Cursor.lockState = CursorLockMode.None;
    }



}
