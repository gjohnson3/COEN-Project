using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20;
    public Transform feet;
    public LayerMask groundLayers;
    float mx;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")&&IsGrounded()){
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }
    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck!=null)
        {
            return true;
        }
        return false;
    }
}
