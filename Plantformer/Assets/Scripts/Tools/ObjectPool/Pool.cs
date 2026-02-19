using System.Collections.Generic;
using UnityEngine;
public class Pool<T> : ScriptableObject where T : Component
{
    [SerializeField] int size = 2;

    Queue<GameObject> queue;

    Transform parent;

    [SerializeField] FactoryBase<T> _factory;
    public FactoryBase<T> Factory
    {
        get => _factory;
        set => _factory = value;
    }

    #region 生成备用对象，并让这些对象入列
    public void Initialize(Transform parent)
    {
        //归类
        this.parent = parent;

        queue = new Queue<GameObject>();

        for (int i = 0;  i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }
    private GameObject Copy()
    {
        T _copy = Factory.Create(parent);

        GameObject copy = _copy.gameObject;

        copy.SetActive(false);

        return copy;
    }
    #endregion

    #region 从池中取出可用对象
    public GameObject Prewarm()
    {
        GameObject availableObject = null;

        if (queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }

        //让完成人物的对象返回对象池
        queue.Enqueue(availableObject);

        return availableObject;
    }
    #endregion

    #region 启用可用对象
    public GameObject Request()
    {
        GameObject preparedObject = Prewarm();

        preparedObject.SetActive(true);

        return preparedObject;
    }
    public GameObject Request(Vector3 position)
    {
        GameObject preparedObject = Prewarm();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;

        return preparedObject;
    }
    public GameObject Request(Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = Prewarm();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;

        return preparedObject;
    }
    public GameObject Request(Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        GameObject preparedObject = Prewarm();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localScale;

        return preparedObject;
    }
    #endregion
}
