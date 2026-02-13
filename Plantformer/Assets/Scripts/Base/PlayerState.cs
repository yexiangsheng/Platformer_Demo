using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理玩家的所有状态
/// </summary>
public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    int stateHash;

    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;

    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerController controller;
    protected PlayerInput input;

    protected float currentSpeed;

    //用时间戳获得当前动画时间
    protected bool IsAnimationFinish => AnimationDuration >= animator.GetCurrentAnimatorClipInfo(0).Length;
    protected float AnimationDuration => Time.time - startAnimationTime;
    private float startAnimationTime;

    [SerializeField] AudioClip audioClip;

    public void OnEnable()
    {
        //使用哈希值效率更高
        //StringToHash是静态函数
        stateHash = Animator.StringToHash(stateName);

        
    }

    public void Initialize(Animator animator, PlayerController controller, PlayerInput input,PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.controller = controller;
        this.input = input;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        //动画渐入渐出（使动画切换更加丝滑）
        animator.CrossFade(stateHash, transitionDuration);

        //当前状态动画开始时间戳
        startAnimationTime = Time.time;

        //播放音频
        if (controller.AudioSource == null)
        {
            Debug.Log("Failed to find audio clip!!!");
        }
        else
        {
            controller.AudioSource.PlayOneShot(audioClip);
        }
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
