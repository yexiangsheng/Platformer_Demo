using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel_SO levelStartEventChannel;

    public void LevelStart()
    {
        levelStartEventChannel?.Broadcast();

        gameObject.GetComponent<Canvas>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
    }




}
