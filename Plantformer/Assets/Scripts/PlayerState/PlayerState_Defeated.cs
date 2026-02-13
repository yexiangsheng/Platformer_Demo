using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Defeated", fileName = "PlayerState_Defeated")]
public class PlayerState_Defeated : PlayerState
{
    [SerializeField] AudioClip[] clips;

    public override void Enter()
    {
        base.Enter();

        AudioClip deathClip = clips[Random.Range(0, clips.Length)];
        controller.AudioSource.PlayOneShot(deathClip);
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinish)
        {
            stateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }


}
