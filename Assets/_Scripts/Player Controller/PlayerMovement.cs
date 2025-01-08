using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public int moveSpeed = 5;

    public Rigidbody2D rb;
    Vector2 movement;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2 (moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
