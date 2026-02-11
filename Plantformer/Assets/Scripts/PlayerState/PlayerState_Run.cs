using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{

    [SerializeField] float runSpeed = 5f;

    public override void Enter()
    {
        animator.Play("Run");
    }
    public override void Exit()
    {

    }
    public override void LogicUpdate()
    {
        if (!input.isMove)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
    public override void PhysicUpdate()
    {
        controller.Move(runSpeed);
    }
}
