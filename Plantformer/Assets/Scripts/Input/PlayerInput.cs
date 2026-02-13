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

    public bool HasJumpInputBuffer { get; set; }
    [SerializeField] float jumpInputBufferTime = 0.2f;

    WaitForSeconds waitForSeconds;

    Vector2 axes => playerInputActions.Gameplay.Move.ReadValue<Vector2>();
    public float AxesX => axes.x;
    public bool isMove => AxesX != 0;
    public bool isJump => playerInputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool isStopJump => playerInputActions.Gameplay.Jump.WasReleasedThisFrame();

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        waitForSeconds = new WaitForSeconds(jumpInputBufferTime);
    }

    private void OnEnable()
    {

        //playerInputActions.Gameplay.SetCallbacks(this);

        //玩家松开跳跃按键时，跳跃缓冲为false
        playerInputActions.Gameplay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;

        };
    }

    private void OnGUI()
    {
        //显示屏
        Rect rect = new Rect(200, 200, 200, 200);
        //显示文字
        string message = "Has Jump Input Buffer ： " + HasJumpInputBuffer;
        //文字样式
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;
        style.fontStyle = FontStyle.Bold;
        //API
        GUI.Label(rect, message, style);
    }

    public void SetJumpInputBufferTimer()
    {
        //先停止后开始可以防止同一个协程重复开启
        StopCoroutine(JumpInputBufferCoroutine());
        StartCoroutine(JumpInputBufferCoroutine());
    }
    /// <summary>
    /// 限制跳跃缓冲时间
    /// </summary>
    /// <returns></returns>
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;

        yield return waitForSeconds;

        HasJumpInputBuffer = false;
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

    public void DisableGameplayInput()
    {
        playerInputActions.Gameplay.Disable();
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
