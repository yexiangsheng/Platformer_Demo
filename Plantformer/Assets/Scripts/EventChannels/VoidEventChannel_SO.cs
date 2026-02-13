using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel", fileName = "VoidEventChannel_")]
public class VoidEventChannel_SO : ScriptableObject
{
    event UnityAction Delegate;

    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    public void AddListener(UnityAction action)
    {
        Delegate += action;
    }
    public void RemoveListener(UnityAction action)
    {
        Delegate -= action;
    }

}
