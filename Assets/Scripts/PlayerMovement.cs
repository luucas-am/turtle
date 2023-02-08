using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

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
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Move()
    {
        bool isTouchingWall = playerCollider.IsTouchingLayers(LayerMask.GetMask("Wall"));

        if (isTouchingWall && playerRigidbody.velocity.magnitude <= Mathf.Epsilon)
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * speed * Time.deltaTime, moveInput.y * speed * Time.deltaTime);
            playerRigidbody.velocity = playerVelocity;
        }
    }
}
