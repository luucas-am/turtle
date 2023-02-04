using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 moveInput;
    Collider2D playerCollider;
    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Move()
    {
        bool isTouchingWall = playerCollider.IsTouchingLayers(LayerMask.GetMask("Wall"));

        if (isTouchingWall)
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            playerRigidbody.velocity = playerVelocity;
        }
    }
}
