using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        controller.SetVelocity(Vector3.zero);
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinish)
        {//µ±¶¯»­²¥·ÅÍê±ÏÇÐ»»Idle×´Ì¬
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }

        if (input.isMove && controller.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (input.isJump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
    }
}
