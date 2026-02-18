using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.Play("audio_1");
    }
}
