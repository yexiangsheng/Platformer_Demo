using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理玩家的所有状态
/// </summary>
public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;

    protected PlayerStateMachine stateMachine;

    protected PlayerController controller;

    protected PlayerInput input;

    protected float currentSpeed;

    public void Initialize(Animator animator, PlayerController controller, PlayerInput input,PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.controller = controller;
        this.input = input;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }

    
}
