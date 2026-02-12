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

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        groundDetector = GetComponentInChildren<GroundDetector>();
    }

    private void Start()
    {
        playerInput.EnableGameplayerInput();

    }

    private void OnEnable()
    {

    }

    /// <summary>
    /// 移动的物理更新
    /// </summary>
    /// <param name="moveSpeed"></param>
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
}
