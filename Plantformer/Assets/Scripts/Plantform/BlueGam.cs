using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueGam : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem fvxEffect;

    [SerializeField] VoidEventChannel_SO gateTriggeredEventChannel;

    private void OnTriggerEnter(Collider other)
    {
        //事件频道类可将Gate类与BlueGam类解耦
        gateTriggeredEventChannel.Broadcast();

        //SoundEffectPlay.AudioSource.PlayOneShot(audioClip);
        Instantiate(fvxEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);//this指脚本，gameObject指挂载这个脚本的物体
    }
}
