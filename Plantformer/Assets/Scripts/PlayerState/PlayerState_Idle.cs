using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        animator.Play("Idle");


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
    }
    public override void PhysicUpdate()
    {
        controller.StopMove();
    }
}
