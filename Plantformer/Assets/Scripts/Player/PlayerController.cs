using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;

    Rigidbody rb;

    public float CurrentSpeed => Mathf.Abs(rb.velocity.x);


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerInput.EnableGameplayerInput();

    }

    private void OnEnable()
    {
    }

    public void Move(float moveSpeed)
    {
        if (playerInput.isMove)
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
}
