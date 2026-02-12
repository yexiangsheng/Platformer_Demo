using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] ParticleSystem jumpVFX;

    public override void Enter()
    {
        base.Enter();

        controller.SetVelocityY(jumpForce);

        Instantiate(jumpVFX, controller.transform.position, Quaternion.identity);

        //玩家进入起跳状态时，跳跃缓冲为false
        input.HasJumpInputBuffer = false;
    }

    public override void LogicUpdate()
    {
        if (controller.IsFalling || input.isStopJump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }

    }

    public override void PhysicUpdate()
    {
        controller.Move(moveSpeed);
    }

}
