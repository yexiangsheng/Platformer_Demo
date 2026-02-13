using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;

    Rigidbody rb;

    public float CurrentSpeed => Mathf.Abs(rb.velocity.x);

    GroundDetector groundDetector;

    public bool IsGround => groundDetector.IsGround;
    public bool IsFalling => rb.velocity.y < 0f ;
    public bool CanDoubleJump { get; set; }

    public AudioSource AudioSource { get; set; }

    [SerializeField] VoidEventChannel_SO levelClearEventChannel;
    public bool IsVictory { get; set; }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        AudioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        playerInput.EnableGameplayerInput();

    }

    private void OnEnable()
    {
        levelClearEventChannel.AddListener(OnLevelClear);
    }
    private void OnDisable()
    {
        levelClearEventChannel.RemoveListener(OnLevelClear);
    }

    #region 游戏状态通知
    public void OnLevelClear()
    {
        IsVictory = true;
    }

    public void OnDefeated()
    {
        //禁用玩家输入
        playerInput.DisableGameplayInput();

        //禁止玩家移动与碰撞
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        rb.detectCollisions = false;

        //通知状态机，让玩家切换到失败状态
        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));

    }
    #endregion

    #region 移动的物理更新
    public void Move(float moveSpeed)
    {
        if (playerInput.isMove)//角色朝向
        {
            transform.localScale = new Vector3(playerInput.AxesX, 1f, 1f);
        }

        SetVelocityX(moveSpeed * playerInput.AxesX);
    }
    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector3 (velocityX,rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector3 (rb.velocity.x,velocityY);
    }
    public void SetUseGravity(bool value)
    {
        rb.useGravity = value;
    }
    #endregion
}
