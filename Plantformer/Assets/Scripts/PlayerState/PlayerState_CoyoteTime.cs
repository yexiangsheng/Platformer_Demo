using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;

    [SerializeField] float coyoteTime = 0.1f;

    public override void Enter()
    {
        base.Enter();

        controller.SetUseGravity(false);
    }
    public override void Exit()
    {
        controller.SetUseGravity(true);
    }
    public override void LogicUpdate()
    {
        if (input.isJump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (coyoteTime < AnimationDuration || !input.isMove)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        
        

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        controller.Move(runSpeed);
    }
}
