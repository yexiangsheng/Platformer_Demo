using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;

    public override void Enter()
    {
        //”≈ªØ∂Øª≠
        //animator.Play("Run");
        base.Enter();

        currentSpeed = controller.CurrentSpeed;
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

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        controller.Move(currentSpeed);
    }
}
