using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();

        controller.SetVelocityY(jumpForce);
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
