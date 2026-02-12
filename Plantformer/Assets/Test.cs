using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }


}
