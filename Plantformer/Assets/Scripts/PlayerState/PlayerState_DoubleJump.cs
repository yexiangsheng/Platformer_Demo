using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/DoubleJump", fileName = "PlayerState_DoubleJump")]
public class PlayerState_DoubleJump : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] ParticleSystem jumpVFX;

    public override void Enter()
    {
        base.Enter();

        controller.SetVelocityY(jumpForce);

        controller.CanDoubleJump = false;

        //实例化特效：特效prefab，挂载在player上的玩家控制类，四元数单位元（0，0，0）
        Instantiate(jumpVFX, controller.transform.position, Quaternion.identity);
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
