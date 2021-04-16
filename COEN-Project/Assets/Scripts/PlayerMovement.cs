using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20;
    public Transform feet;
    public Transform armR;
    public Transform armL;
    public LayerMask groundLayers;
    float mx;
    bool isGrounded;
    public float jumpRate = 0.5f;
    float timeUntilJump;

    [HideInInspector] public bool isFacingRight =true;

    void Update()
    {
        //allow to player to jump if they are on the ground or touching a wall
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && timeUntilJump < Time.time && ((IsGrounded())||(OnWall()))){
            Jump();
            timeUntilJump = Time.time + jumpRate;
        }
        //transform the sprite to face right if the player is moving right
        if (mx > 0f){
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        //transform the sprite to face left if the player is moving left
        else if (mx < 0f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
        //set the animation to running if the character is moving
        if (Mathf.Abs(mx) > 0.05f){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isGrounded", IsGrounded());
    }
    private void FixedUpdate()
    {
        //move the player
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
        //make the player jump
    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }
    public bool IsGrounded()
    {
        //check if the player is touching the ground by using a sensor at the character's feet
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.15f, groundLayers);
        if (groundCheck!=null)
        {
            return true;
        }
        return false;
    }
    public bool OnWall()
    {
        //check if the the character is on a wall with sensors on their right and left sides
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
