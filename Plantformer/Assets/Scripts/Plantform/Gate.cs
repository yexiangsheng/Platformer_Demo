using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] VoidEventChannel_SO gateTriggeredEventChannel;

    
    private void OnEnable()
    {
        gateTriggeredEventChannel.AddListener(Open);
    }
    private void OnDisable()
    {
        gateTriggeredEventChannel.RemoveListener(Open);
    }


    void Open()
    {
        Destroy(gameObject);
    }
}
