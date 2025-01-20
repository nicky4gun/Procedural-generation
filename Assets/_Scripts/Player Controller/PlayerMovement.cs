using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        moveSpeed += SpeedBuff.speedBuffAmount;
    }
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
