using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20;
    public Transform feet;
    public Transform armR;
    public Transform armL;
    public LayerMask groundLayers;
    float mx;
    bool isGrounded;

    [HideInInspector] public bool isFacingRight =true;

    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")&&((IsGrounded())||(OnWall()))){
            Jump();
        }
        
        if (mx > 0f){
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (mx < 0f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
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
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.15f, groundLayers);
        if (groundCheck!=null)
        {
            return true;
        }
        return false;
    }
    public bool OnWall()
    {
        Collider2D wallCheckL = Physics2D.OverlapCircle(armL.position, 0.15f, groundLayers);
        Collider2D wallCheckR = Physics2D.OverlapCircle(armR.position, 0.15f, groundLayers);
        if (wallCheckL != null)
        {
            return true;
        }
        else if(wallCheckR != null){
            return true;
        }
        return false;
    }
}
