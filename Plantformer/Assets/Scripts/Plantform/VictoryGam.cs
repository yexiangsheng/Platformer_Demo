using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGam : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem fvxEffect;

    private void OnTriggerEnter(Collider other)
    {
        SoundEffectPlay.AudioSource.PlayOneShot(audioClip);
        Instantiate(fvxEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);//this指脚本，gameObject指挂载这个脚本的物体
    }

}
