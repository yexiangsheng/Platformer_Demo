using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel", fileName = "VoidEventChannel_")]
public class VoidEventChannel_SO : ScriptableObject
{
    //使用C#原生的事件类性能更好
    event Action Delegate;

    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    public void AddListener(Action action)
    {
        Delegate += action;
    }
    public void RemoveListener(Action action)
    {
        Delegate -= action;
    }

}
