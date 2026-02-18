using UnityEngine;

public abstract class FactoryBase<T> : ScriptableObject, IFactory<T>
{
    public abstract T Create();

    public abstract T Create(Transform parent);
}
