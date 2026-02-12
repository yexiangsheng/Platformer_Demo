using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 5f;

    public override void Enter()
    {
        //animator.Play("Idle");
        base.Enter();


        currentSpeed = controller.CurrentSpeed;
    }
    public override void Exit()
    {

    }
    public override void LogicUpdate()
    {
        if (input.isMove)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (input.isJump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (!controller.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }


        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        controller.SetVelocityX(currentSpeed * controller.transform.localScale.x);
    }
}
