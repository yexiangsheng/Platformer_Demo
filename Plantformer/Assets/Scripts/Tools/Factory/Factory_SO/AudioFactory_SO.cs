using UnityEngine;
[CreateAssetMenu(menuName = "Factory/AudioFactory", fileName = "AudioFactory_")]
public class AudioFactory_SO : FactoryBase<AudioSource>
{
    public AudioSource prefab;

    public override AudioSource Create()
    {
        AudioSource gameObject = Instantiate(prefab);
        return gameObject;
    }

    public override AudioSource Create(Transform parent)
    {
        AudioSource gameObject = Instantiate(prefab, parent);
        return gameObject;
    }
}
