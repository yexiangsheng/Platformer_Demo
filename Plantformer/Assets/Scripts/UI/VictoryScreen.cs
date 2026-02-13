using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearEventChannel;

    private void OnEnable()
    {
        levelClearEventChannel.AddListener(ShowUI);
    }
    private void OnDisable()
    {
        levelClearEventChannel.RemoveListener(ShowUI);
    }
    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }



}
