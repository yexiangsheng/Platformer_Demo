using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//[CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : MonoBehaviour/*ScriptableObject, PlayerInputActions.IGameplayActions*/
{
    PlayerInputActions playerInputActions;

    //public event UnityAction<Vector2> onMove = delegate { };
    //public event UnityAction onStopMove = delegate { };
    //public event UnityAction onJump = delegate { };
    //public event UnityAction onStopJump = delegate { };


    Vector2 axes => playerInputActions.Gameplay.Move.ReadValue<Vector2>();
    public float AxesX => axes.x;
    public bool Move => AxesX != 0;
    public bool Jump => playerInputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.Gameplay.Jump.WasReleasedThisFrame();
         

    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();

        //playerInputActions.Gameplay.SetCallbacks(this);
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void EnableGameplayerInput()
    {
        playerInputActions.Gameplay.Enable();

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableAllInput()
    {
        playerInputActions.Gameplay.Disable();
    }



    //public void OnJump(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Started)
    //    {
    //        onJump.Invoke();
    //    }
    //    if (context.phase == InputActionPhase.Canceled)
    //    {
    //        onStopJump.Invoke();
    //    }
    //}

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        onMove.Invoke(context.ReadValue<Vector2>());
    //    }
    //    if (context.phase == InputActionPhase.Canceled)
    //    {
    //        onStopMove.Invoke();
    //    }
    //}

    
}
