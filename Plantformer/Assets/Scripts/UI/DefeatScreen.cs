using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel_SO playerDefeatedEventChannel;
    [SerializeField] AudioClip[] retryAudioClips;

    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;


    private void OnEnable()
    {
        playerDefeatedEventChannel.AddListener(ShowUI);

        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }
    private void OnDisable()
    {
        playerDefeatedEventChannel.RemoveListener(ShowUI);

        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
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
