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

    protected PlayerInput input;

    public void Initialize(Animator animator, PlayerInput input,PlayerStateMachine stateMachine)
    {
        this.animator = animator;
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
