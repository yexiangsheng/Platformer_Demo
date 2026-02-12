using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime = 0.2f;

    public override void Enter()
    {
        base.Enter();

        controller.SetVelocity(Vector3.zero);

    }

    public override void LogicUpdate()
    {
        if (input.isJump || input.HasJumpInputBuffer)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        
        //增加下落时的硬直时间
        if (AnimationDuration < stiffTime)
        {
            return;
        }

        if (input.isMove && controller.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinish)
        {//当动画播放完毕切换Idle状态
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }

    }
}
