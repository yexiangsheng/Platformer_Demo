using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float moveSpeed = 5f;

    public override void Enter()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        if (controller.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.isJump)
        {
            if (controller.CanDoubleJump)
            {
                stateMachine.SwitchState(typeof(PlayerState_DoubleJump));
            }
        }
    }

    
    public override void PhysicUpdate()
    {
        //掉落速度曲线模拟
        controller.SetVelocityY(speedCurve.Evaluate(AnimationDuration));

        controller.Move(moveSpeed);
    }
}
