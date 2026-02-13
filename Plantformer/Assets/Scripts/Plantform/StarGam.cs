using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class StarGam : MonoBehaviour
{
    [SerializeField] float resetTime = 5f;

    MeshRenderer meshRenderer;
    new Collider collider;

    WaitForSeconds waitForSeconds;

    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem fvxEffect;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        waitForSeconds = new WaitForSeconds(resetTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            //不要直接使用这个，因为此时挂载在这个gameObject上的脚本也会被禁用
            //gameObject.SetActive(false);
            player.CanDoubleJump = true;
            collider.enabled = false;
            meshRenderer.enabled = false;

            //播放音效与特效
            //SoundEffectPlay.AudioSource.PlayOneShot(audioClip);
            Instantiate(fvxEffect, transform.position, Quaternion.identity);

            //用协程性能更好
            //Invoke(nameof(Reset), resetTime);
            StartCoroutine(ResetCoroutine());
        }
    }

    void Reset()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }

    IEnumerator ResetCoroutine()
    {
        yield return waitForSeconds;

        Reset();
    }

}
