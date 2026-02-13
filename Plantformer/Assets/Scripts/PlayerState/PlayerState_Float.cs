using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Float", fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel_SO playerDefeatedEventChannel;

    public override void Enter()
    {
        base.Enter();

        playerDefeatedEventChannel.Broadcast();
    }

}
