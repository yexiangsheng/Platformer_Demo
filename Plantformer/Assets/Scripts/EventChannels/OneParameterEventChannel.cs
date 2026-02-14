using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OneParameterEventChannel<T> : ScriptableObject
{

    //使用C#原生的事件类性能更好
    event Action<T> Delegate;

    public void Broadcast(T obj)
    {
        Delegate?.Invoke(obj);
    }
    public void AddListener(Action<T> action)
    {
        Delegate += action;
    }
    public void RemoveListener(Action<T> action)
    {
        Delegate -= action;
    }
}
