using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
   
    public Transform groundCheck;
    
    bool isFacingRight = true;
    
    RaycastHit2D hit;

    //check if the enemy is hitting the gound
    private void Update(){
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);

    }

    
    private void FixedUpdate() {
        //if the enemy is on the ground move right, but switch directions if the sensor in front of the enemy detects there is no ground ahead of it
        if (hit.collider != false){
            Debug.Log("hitting ground");
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        //if the enemy is not on the ground then transform it to go left
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            Debug.Log("not hitting ground");
        }
    }

    //if the enemy collides with a bullet, destory the enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
