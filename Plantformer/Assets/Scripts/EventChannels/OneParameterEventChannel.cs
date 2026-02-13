using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneParameterEventChannel<T> : ScriptableObject
{
    event UnityAction<T> Delegate;

    public void Broadcast(T obj)
    {
        Delegate?.Invoke(obj);
    }
    public void AddListener(UnityAction<T> action)
    {
        Delegate += action;
    }
    public void RemoveListener(UnityAction<T> action)
    {
        Delegate -= action;
    }
}
