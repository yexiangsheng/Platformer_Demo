using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;
    PlayerController controller;
    PlayerInput input;
    [SerializeField] PlayerState[] states;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        controller = GetComponent<PlayerController>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator, controller, input, this);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        //反射获取状态的类型
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }




}
